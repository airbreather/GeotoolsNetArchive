/*
 *  Copyright (C) 2002 Urban Science Applications, Inc. (translated from Java Topology Suite, 
 *  Copyright 2001 Vivid Solutions)
 *
 *  This library is free software; you can redistribute it and/or
 *  modify it under the terms of the GNU Lesser General Public
 *  License as published by the Free Software Foundation; either
 *  version 2.1 of the License, or (at your option) any later version.
 *
 *  This library is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 *  Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public
 *  License along with this library; if not, write to the Free Software
 *  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 *
 */

#region Using statements
using System;
using Geotools.Geometries;
#endregion

namespace Geotools.Algorithms
{

	/// <summary>
	/// Computes the centroid of a linear geometry.
	/// </summary>
	/// <remarks>
	/// Compute the average of the midpoints
	/// of all line segments weighted by the segment length.
	/// </remarks>
	public class CentroidLine
	{
		private Coordinate _centSum = new Coordinate();
		private double _totalLength = 0.0;

		public CentroidLine()
		{
		}

		/// <summary>
		/// Adds the linestring(s) defined by a Geometry to the centroid total.
		/// If the geometry is not linear it does not contribute to the centroid
		/// </summary>
		/// <param name="geom">geom the geometry to add.</param>
		public void Add(Geometry geom)
		{
			if (geom is LineString) 
			{
				Add(geom.GetCoordinates());
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

		/// <summary>
		/// Adds the length defined by an array of coordinates.
		/// </summary>
		/// <param name="pts">pts an array of {@link Coordinate}s</param>
		public void Add(CoordinateCollection pts)
		{
			for (int i = 0; i < pts.Count - 1; i++) 
			{
				double segmentLen = pts[i].Distance(pts[i + 1]);
				_totalLength += segmentLen;

				double midx = (pts[i].X + pts[i + 1].X) / 2;
				_centSum.X += segmentLen * midx;
				double midy = (pts[i].Y + pts[i + 1].Y) / 2;
				_centSum.Y += segmentLen * midy;
			}
		}

		public Coordinate GetCentroid()
		{
			Coordinate cent = new Coordinate();
			cent.X = _centSum.X / _totalLength;
			cent.Y = _centSum.Y / _totalLength;
			return cent;
		}

	}
}