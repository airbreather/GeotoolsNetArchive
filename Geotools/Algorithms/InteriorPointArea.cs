#region Using statements
using System;
using Geotools.Geometries;
#endregion
namespace Geotools.Algorithms
{


	/**
	 * Computes a point in the interior of an area geometry.
	 *
	 * <h2>Algorithm</h2>
	 * <ul>
	 *   <li>Find the intersections between the geometry
	 *       and the horizontal bisector of the area's envelope
	 *   <li>Pick the midpoint of the largest intersection (the intersections
	 *       will be lines and points)
	 * </ul>
	 *
	 * <b>
	 * Note: If a fixed precision model is used,
	 * in some cases this method may return a point
	 * which does not lie in the interior.
	 * </b>
	 */
	public class InteriorPointArea 
	{

		private static double Avg(double a, double b)
		{
			return (a + b) / 2.0;
		}

		private GeometryFactory _factory;
		private Coordinate _interiorPoint = null;
		private double _maxWidth = 0.0;

		public InteriorPointArea(Geometry g)
		{
			_factory = new GeometryFactory(g.PrecisionModel, g.GetSRID());
			Add(g);
		}
		public Coordinate InteriorPoint
		{
			get
			{
				return _interiorPoint;
			}
		}

		/**
		 * Tests the interior vertices (if any)
		 * defined by a linear Geometry for the best inside point.
		 * If a Geometry is not of dimension 1 it is not tested.
		 * @param geom the geometry to add
		 */
		private void Add(Geometry geom)
		{
			if (geom is Polygon) 
			{
				AddPolygon(geom);
			}
			else if (geom is GeometryCollection) 
			{
				GeometryCollection gc = (GeometryCollection) geom;
				for (int i = 0; i < gc.GetNumGeometries(); i++) 
				{
					Add(gc[i]);
				}
			}
		}

		/**
		 * Finds a reasonable point at which to label a Geometry.
		 * @param geometry the geometry to analyze
		 * @return the midpoint of the largest intersection between the geometry and
		 * a line halfway down its envelope
		 */
		public void AddPolygon(Geometry geometry) 
		{
			LineString bisector = HorizontalBisector(geometry);

			Geometry intersections = bisector.Intersection(geometry);
			Geometry widestIntersection = WidestGeometry(intersections);

			double width = widestIntersection.GetEnvelopeInternal().Width;
			if (_interiorPoint == null || width > _maxWidth) 
			{
				_interiorPoint = Centre(widestIntersection.GetEnvelopeInternal());
				_maxWidth = width;
			}
		}

		//@return if geometry is a collection, the widest sub-geometry; otherwise,
		//the geometry itself
		protected Geometry WidestGeometry(Geometry geometry) 
		{
			if (!(geometry is GeometryCollection)) 
			{
				return geometry;
			}
			return WidestGeometry((GeometryCollection) geometry);
		}

		private Geometry WidestGeometry(GeometryCollection gc) 
		{
			if (gc.IsEmpty()) 
			{
				return gc;
			}

			Geometry widestGeometry = gc.GetGeometryN(0);
			for (int i = 1; i < gc.GetNumGeometries(); i++) 
			{ //Start at 1
				if (gc[i].GetEnvelopeInternal().Width >
					widestGeometry.GetEnvelopeInternal().Width) 
				{
					widestGeometry = gc[i];
				}
			}
			return widestGeometry;
		}

		protected LineString HorizontalBisector(Geometry geometry) 
		{
			Envelope envelope = geometry.GetEnvelopeInternal();

			// Assert: for areas, minx <> maxx
			double avgY = Avg(envelope.MinimumY, envelope.MaximumY);

			CoordinateCollection coords = new CoordinateCollection();
			coords.Add(	 new Coordinate(envelope.MinimumX, avgY) );
			coords.Add(  new Coordinate(envelope.MinimumX, avgY) );
															
			return _factory.CreateLineString(coords);
		
		}

		/**
		 * Returns the centre point of the envelope.
		 * @param envelope the envelope to analyze
		 * @return the centre of the envelope
		 */
		public Coordinate Centre(Envelope envelope) 
		{
			/*return new Coordinate(avg(envelope.getMinX(),
				envelope.getMaxX()),
				avg(envelope.getMinY(), envelope.getMaxY()));*/
			return new Coordinate(Avg(envelope.MinimumX, envelope.MaximumX), Avg(envelope.MinimumY, envelope.MinimumY));
		}

	}
}