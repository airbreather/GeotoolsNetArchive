#region SourceSafe Comments
/* 
 * $Header$
 * $Log$
 * 
 * 14    10/21/02 11:04a Rabergman
 * Made test match new formats for methods & properties.
 * 
 * 13    10/04/02 4:49p Rabergman
 * 
 * 12    10/04/02 1:09p Rabergman
 * changed test_SetEmpty due to changes made during code review.
 * 
 * 11    10/03/02 4:00p Rabergman
 * Removed test_ComputeEnvelopeInternal
 * 
 * 10    10/02/02 2:05p Rabergman
 * Daily check in
 * 
 * 9     9/25/02 12:30p Rabergman
 * Daily check in
 * 
 * 8     9/18/02 11:03a Rabergman
 * Added: test_GetGeometries & Test_ComputeEnvelopeInternal
 * 
 * 7     9/17/02 9:55a Rabergman
 * Removed test for Normalize.  Changed CompareToSameClass.
 * 
 * 6     9/09/02 1:46p Rabergman
 * Fixed tests that were not working due to parts of the class not having
 * been implemented - bondarydimension & numpoints.
 * 
 * 5     9/05/02 2:25p Rabergman
 * Added comapretosameclass
 * 
 * 4     9/04/02 1:04p Rabergman
 * added enumerator
 * 
 * 3     9/03/02 1:50p Rabergman
 * Fixed exception being thrown
 * 
 * 2     9/03/02 11:42a Rabergman
 * Added tests
 * 
 * 1     8/29/02 12:40p Rabergman
 * 
 */ 
#endregion

#region Using
using System;
using System.Collections;
using NUnit.Framework;
using Geotools.SimpleFeatures;
#endregion

namespace UrbansScience.Geographic.UnitTests.Geometries
{
	/// <summary>
	/// Summary description for GeometryCollectionTest.
	/// </summary>
	public class GeometryCollectionTest : TestCase
	{
		//set up needed variables
		PrecisionModel _precMod = new PrecisionModel(1.0, 2.0, 3.0);
		int _sRID = 3;

		/// <summary>
		/// Initializes a new instance of the GeometryCollectionTest class.
		/// </summary>
		public GeometryCollectionTest(String name) : base(name)
		{
		}

		protected override void SetUp()
		{
		}

		protected override void TearDown()
		{
		}

		private GeometryCollection CreateCollection()
		{
			//this is used to prevent having to rewrite this code over & over

			//create a new coordinate
			Coordinate coordinate = new Coordinate();
			//create a new point
			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
			Point point = gf.CreatePoint(coordinate);
			//create a new geometries array
			Geometry[] geom = new Geometry[10];
			//fill with points
			for(int i = 0; i < 10; i++)
			{
				//if this isn't here the coordinates for all the points are reset every time the coordinate is reset
				coordinate = new Coordinate();
				//make the x coordinate equal to the iterator
				coordinate.X = (double)i;
				//make the y coordinate equal to the iterator plus 10
				coordinate.Y = (double)i + 10;
				//create a new point to put in the geometry
				point = gf.CreatePoint(coordinate);
				//put the point in the geometies
				geom[i] = point;
			}
			//put the geometries into a geometry collection
			GeometryCollection geoColl = gf.CreateGeometryCollection(geom);

			return geoColl;
		}

		private GeometryCollection CreateCollection1()
		{
			//this is used to prevent having to rewrite this code over & over

			//create a new coordinate
			Coordinate coordinate = new Coordinate();
			//create a new point
			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
			Point point = gf.CreatePoint(coordinate);
			//create a new geometries array
			Geometry[] geom = new Geometry[10];
			int c = 0;
			//fill with points
			for(int i = 9; i >-1; i--)
			{
				//if this isn't here the coordinates for all the points are reset every time the coordinate is reset
				coordinate = new Coordinate();
				//make the x coordinate equal to the iterator
				coordinate.X = (double)i;
				//make the y coordinate equal to the iterator plus 10
				coordinate.Y = (double)i + 10;
				//create a new point to put in the geometry
				point = gf.CreatePoint(coordinate);
				//put the point in the geometies
				geom[c] = point;
				c++;
			}
			//put the geometries into a geometry collection
			GeometryCollection geoColl = gf.CreateGeometryCollection(geom);

			return geoColl;
		}

		private GeometryCollection CreateCollection2()
		{
			//create a new geometries array
			Geometry[] geom = new Geometry[10];

			Coordinate coordinate = new Coordinate();
			Coordinates coords = new Coordinates();

			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
			LineString lineString = gf.CreateLineString(coords);

			for(int c = 0; c < 10; c++)
			{
				for(int i = c; i < c+10; i++)
				{
					//if this isn't here the coordinates for all the points are reset every time the coordinate is reset
					coordinate = new Coordinate();
					//make the x coordinate equal to the iterator
					coordinate.X = (double)i;
					//make the y coordinate equal to the iterator plus 10
					coordinate.Y = (double)i + 10;
					coords.Add(coordinate);
				}
				lineString = gf.CreateLineString(coords);
				geom[c] = lineString;
			}
			//put the geometries into a geometry collection
			GeometryCollection geoColl = gf.CreateGeometryCollection(geom);

			return geoColl;
		}

		private GeometryCollection CreateCollection3()
		{
			//create a new geometries array
			Geometry[] geom = new Geometry[10];

			Coordinate coordinate = new Coordinate();
			Coordinates coords = new Coordinates();
			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
			Point point = gf.CreatePoint(coordinate);

			LineString lineString = gf.CreateLineString(coords);

			for(int c = 0; c < 5; c++)
			{
				for(int i = c; i < c+5; i++)
				{
					//if this isn't here the coordinates for all the points are reset every time the coordinate is reset
					coordinate = new Coordinate();
					//make the x coordinate equal to the iterator
					coordinate.X = (double)i;
					//make the y coordinate equal to the iterator plus 10
					coordinate.Y = (double)i + 10;
					coords.Add(coordinate);
				}
				lineString = gf.CreateLineString(coords);
				geom[c] = lineString;
			}
			for(int i = 5; i < 10; i++)
			{
				//if this isn't here the coordinates for all the points are reset every time the coordinate is reset
				coordinate = new Coordinate();
				//make the x coordinate equal to the iterator
				coordinate.X = (double)i;
				//make the y coordinate equal to the iterator plus 10
				coordinate.Y = (double)i + 10;
				//create a new point to put in the geometry
				point = gf.CreatePoint(coordinate);
				//put the point in the geometies
				geom[i] = point;
			}
			//put the geometries into a geometry collection
			GeometryCollection geoColl = gf.CreateGeometryCollection(geom);

			return geoColl;
		}

		private GeometryCollection CreateCollection4()
		{
			//this is used to prevent having to rewrite this code over & over

			//create a new coordinate
			Coordinate coordinate = new Coordinate();
			//create a new point
			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
			Point point = gf.CreatePoint(coordinate);
			//create a new geometries array
			Geometry[] geom = new Geometry[10];
			int c = 0;
			//fill with points
			for(int i = 9; i < 19 ; i++)
			{
				//if this isn't here the coordinates for all the points are reset every time the coordinate is reset
				coordinate = new Coordinate();
				//make the x coordinate equal to the iterator
				coordinate.X = (double)i;
				//make the y coordinate equal to the iterator plus 10
				coordinate.Y = (double)i + 10;
				//create a new point to put in the geometry
				point = gf.CreatePoint(coordinate);
				//put the point in the geometies
				geom[c] = point;
				c++;
			}
			//put the geometries into a geometry collection
			GeometryCollection geoColl = gf.CreateGeometryCollection(geom);

			return geoColl;
		}

		public void test_Constructor()
		{
			//create a new collection
			GeometryCollection geoColl = CreateCollection();

			//make sure the geometrycollection isn't empty
			AssertEquals("Constructor-1: ", false, geoColl.IsEmpty());
			//it should have ten elements
			AssertEquals("Constructor-2: ", 10, geoColl.Count);

			//make sure all the elements are not empty
			for(int i = 0; i < geoColl.Count; i++)
			{
				AssertEquals("Constructor-3: ", false, geoColl.GetGeometryN(i).IsEmpty());
			}

			Coordinate coord = new Coordinate();
			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
			Point point = gf.CreatePoint(coord);
			//check that the contents are as expected
			for(int i = 0; i < geoColl.Count; i++)
			{
				point = geoColl.GetGeometryN(i) as Point;
				AssertEquals("Constructor-4: ", true, point.x.Equals((double)i));
				AssertEquals("Constructor-5: ", true, point.y.Equals((double)i+10));
			}
		}

		public void test_Clone()
		{
			//create a new collection
			GeometryCollection geoColl = CreateCollection();
			//clone the collection
			GeometryCollection geoColl2 = geoColl.Clone() as GeometryCollection;

			//make sure they are exactly the same
			AssertEquals("Clone-1: ", true, geoColl.Equals(geoColl2));
		}

		public void test_geometry()
		{
			//create a new collection
			GeometryCollection geoColl = CreateCollection();

			//create a new coordinate
			Coordinate coord = new Coordinate(0.0, 10.0);
			//create a new point
			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
			Point point = gf.CreatePoint(coord);
			//make sure that geometry returns the expected points
			for(int count = 0; count < geoColl.Count; count++)
			{
				point = geoColl.GetGeometryN(count) as Point;
				AssertEquals("geometry-1: ", (double)count, point.x);
				AssertEquals("geometry-2: ", (double)count+10, point.y);
			}
		}

		public void test_SetEmpty()
		{
//(Note: this test is no longer valid, set empty 
//			//create a new collection
//			GeometryCollection geoColl = CreateCollection();
//
//			AssertEquals("SetEmpty-1: ", false, geoColl.IsEmpty());
//			try
//			{
//				geoColl.SetEmpty();
//				Fail("Exception should have been thrown");
//			}
//			catch(NotSupportedException)
//			{
//			}
		}

		public void test_Envelope()
		{
//(Note: Test must be commented out because this class has been made internal.  All test are functioning properly otherwise.)
//			//create a new collection
//			GeometryCollection geoColl = CreateCollection();
//
//			//put the envelope into a geometry
//			Geometry env = geoColl.Envelope() as Geometry;
//
//			//make sure there is something in the envelope
//			AssertEquals("Envelope-1: ", false, env.IsEmpty());
//            
//			Coordinates coords = env.Coordinates;
//			//check the first set of coordinates (minX, minY)
//			AssertEquals("Envelope-2: ", 0.0, coords[0].X);
//			AssertEquals("Envelope-3: ", 10.0, coords[0].Y);
//
//			//check the second set of coordinates (maxX, minY)
//			AssertEquals("Envelope-4: ", 9.0, coords[1].X);
//			AssertEquals("Envelope-5: ", 10.0, coords[1].Y);
//
//			//check the third set of coordinates (maxX, maxY)
//			AssertEquals("Envelope-6: ", 9.0, coords[2].X);
//			AssertEquals("Envelope-7: ", 19.0, coords[2].Y);
//
//			//check the forth set of coordinates (minX, maxY)
//			AssertEquals("Envelope-8: ", 0.0, coords[3].X);
//			AssertEquals("Envelope-9: ", 19.0, coords[3].Y);
//
//			//check the fifth set of coordinates (minX, minY)
//			AssertEquals("Envelope-10: ", 0.0, coords[4].X);
//			AssertEquals("Envelope-11: ", 10.0, coords[4].Y);
//
//			//create a null collection
//			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
//			geoColl = gf.CreateGeometryCollection(null);
//
//			//put the envelope into a geometry
//			env = geoColl.Envelope() as Geometry;
//
//			//make sure there is nothing in the envelope
//			AssertEquals("Envelope-12: ", true, env.IsEmpty());
		}

		public void test_Extent2D()
		{
//(Note: Extent2D was removed with OGIS)
//			//create a geomerty collection
//			GeometryCollection geoColl = CreateCollection();
//
//			//initalize all the out variables
//            double minX = double.NaN;
//			double minY = double.NaN;
//			double maxX = double.NaN;
//			double maxY = double.NaN;
//
//			//get the extent
//			geoColl.gete.Extent2D(out minX, out minY, out maxX, out maxY);
//
//			//check the return values
//			AssertEquals("Extent2D-1: ", 0.0, minX);
//			AssertEquals("Extent2D-2: ", 10.0, minY);
//			AssertEquals("Extent2D-3: ", 9.0, maxX);
//			AssertEquals("Extent2D-4: ", 19.0, maxY);
//
//			//now try it with a null geometry collection
//			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
//			geoColl = gf.CreateGeometryCollection(null);
//
//			//get the extent again
//			geoColl.Extent2D(out minX, out minY, out maxX, out maxY);
//
//			//check the return values (an empty envelope returns, 0,0,-1,-1)
//			AssertEquals("Extent2D-5: ", 0.0, minX);
//			AssertEquals("Extent2D-6: ", 0.0, minY);
//			AssertEquals("Extent2D-7: ", 0.0, maxX);
//			AssertEquals("Extent2D-8: ", 0.0, maxY);
		}

		public void test_Project()
		{
			//create a geomerty collection
			GeometryCollection geoColl = CreateCollection();

			//TODO: change this when project is working
			//AssertEquals("Project-1: ", null, geoColl.Project(null));
		}

		public void test_Count()
		{
			//create a geomerty collection
			GeometryCollection geoColl = CreateCollection();

			AssertEquals("Count-1: ", 10, geoColl.Count);

			//now try it with a null geometry collection
			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
			geoColl = gf.CreateGeometryCollection(null);

			AssertEquals("Count-2: ", 0, geoColl.Count);

			//now try it with a different geometry collection
			geoColl = CreateCollection2();

			AssertEquals("Count-3: ", 10, geoColl.Count);

			//now try it with a mixed geometry collection
			geoColl = CreateCollection3();

			AssertEquals("Count-4: ", 10, geoColl.Count);
		}

		public void test_GetGeometries()
		{
//			//create a geomerty collection
//			GeometryCollection geoColl = CreateCollection();
//
//			Geometry[] geom =  geoColl.GetGeometries;
//			AssertEquals("GetGeometries-1: ", 10, geom.Length);
//			for(int i = 0; i < geom.Length; i++)
//			{
//				foreach(Coordinate coord in geom[i].Coordinates)
//				{
//					AssertEquals("GetGeometries-loopX: ", true, coord.X == (double)i);
//					AssertEquals("GetGeometries-loopY: ", true, coord.Y == (double)i+10);
//				}
//			}
		}

		public void test_NumGeometries()
		{
			//create a geomerty collection
			GeometryCollection geoColl = CreateCollection();

			AssertEquals("NumGeometries-1: ", 10, geoColl.GetNumGeometries());

			//now try it with a null geometry collection
			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
			geoColl = gf.CreateGeometryCollection(null);

			AssertEquals("NumGeometries-2: ", 0, geoColl.GetNumGeometries());

			//now try it with a different geometry collection
			geoColl = CreateCollection2();

			AssertEquals("NumGeometries-3: ", 10, geoColl.GetNumGeometries());

			//now try it with a mixed geometry collection
			geoColl = CreateCollection3();

			AssertEquals("NumGeometries-4: ", 10, geoColl.GetNumGeometries());
		}

		public void test_IsEmpty()
		{
			//create a geomerty collection
			GeometryCollection geoColl = CreateCollection();

			AssertEquals("IsEmpty()-1: ", false, geoColl.IsEmpty());

			//now try it with a null geometry collection
			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
			geoColl = gf.CreateGeometryCollection(null);

			AssertEquals("IsEmpty()-2: ", true, geoColl.IsEmpty());

			//now try it with a different geometry collection
			geoColl = CreateCollection2();

			AssertEquals("IsEmpty()-3: ", false, geoColl.IsEmpty());

			//now try it with a mixed geometry collection
			geoColl = CreateCollection3();

			AssertEquals("IsEmpty()-4: ", false, geoColl.IsEmpty());
		}

		public void test_Dimension()
		{
			//create a geomerty collection
			GeometryCollection geoColl = CreateCollection();

			//returns 0 because a point has a dimension of 0 & that is the largest dimesion in the collection
			AssertEquals("Dimension-1: ", 0, geoColl.GetDimension());

			//now try it with a null geometry collection
			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
			geoColl = gf.CreateGeometryCollection(null);

			//returns -1 because the collection is empty
			AssertEquals("Dimension-2: ", -1, geoColl.GetDimension());

			//now try it with a different geometry collection
			geoColl = CreateCollection2();

			//returns 1 because linestring has a dimension of 1 & that is the largest dimension in the collection
			AssertEquals("Dimension-3: ", 1, geoColl.GetDimension());

			//returns 1 because linestring has a dimension of 1 & that is the largest dimension in the collection
			geoColl = CreateCollection3();

			AssertEquals("Dimension-4: ", 1, geoColl.GetDimension());
		}

		public void test_IsSimple()
		{
//			//create a geomerty collection
//			GeometryCollection geoColl = CreateCollection();
//
//			//returns 0 because a point has a dimesion of 0 & that is the largest dimesion in the collection
//			AssertEquals("IsSimple-1: ", true, geoColl.IsSimple);
//
//			//now try it with a null geometry collection
//			geoColl = new GeometryCollection(null, _precMod, _sRID);
//
//			AssertEquals("IsSimple-2: ", true, geoColl.IsSimple);
//
//			//now try it with a different geometry collection
//			geoColl = CreateCollection2();
//
//			AssertEquals("IsSimple-3: ", false, geoColl.IsSimple);
//
//			//now try it with a mixed geometry collection
//			geoColl = CreateCollection3();
//
//			AssertEquals("IsSimple-4: ", false, geoColl.IsSimple);
		}

		public void test_Coordinates()
		{
			//create a geomerty collection
			GeometryCollection geoColl = CreateCollection();

			//this geometry conatins 10 sets of coordinates
			AssertEquals("Coordinates-1: ", 10, geoColl.GetCoordinates().Count);

			//now try it with a null geometry collection
			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
			geoColl = gf.CreateGeometryCollection(null);

			AssertEquals("Coordinates-2: ", 0, geoColl.GetCoordinates().Count);

			//now try it with a different geometry collection
			geoColl = CreateCollection2();

			//1000 sets of coordinates
			AssertEquals("Cordinates-3: ", 1000, geoColl.GetCoordinates().Count);

			//now try it with a mixed geometry collection
			geoColl = CreateCollection3();

			AssertEquals("Coordinates-4: ", 130, geoColl.GetCoordinates().Count);
		}

		public void test_GetBoundaryDimension()
		{
			//create a geomerty collection
			GeometryCollection geoColl = CreateCollection();

			AssertEquals("GetBoundaryDimension-1: ", -1, geoColl.GetBoundaryDimension());

			//now try it with a null geometry collection
			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
			geoColl = gf.CreateGeometryCollection(null);

			AssertEquals("GetBoundaryDimension-2: ", -1, geoColl.GetBoundaryDimension());

			//now try it with a different geometry collection
			geoColl = CreateCollection2();

			AssertEquals("GetBoundaryDimension-3: ", 0, geoColl.GetBoundaryDimension());

			//now try it with a mixed geometry collection
			geoColl = CreateCollection3();

			AssertEquals("GetBoundryDimension-4: ", 0, geoColl.GetBoundaryDimension());
		}

		public void test_NumPoints()
		{
			//create a geomerty collection
			GeometryCollection geoColl = CreateCollection();

			AssertEquals("NumPoints-1: ", 10, geoColl.GetNumPoints());

			//now try it with a null geometry collection
			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
			geoColl = gf.CreateGeometryCollection(null);

			AssertEquals("NumPoints-2: ", 0, geoColl.GetNumPoints());

			//now try it with a different geometry collection
			geoColl = CreateCollection2();

			AssertEquals("NumPoints-3: ", 1000, geoColl.GetNumPoints());

			//now try it with a mixed geometry collection
			geoColl = CreateCollection3();

			AssertEquals("NumPoints-4: ", 130, geoColl.GetNumPoints());
		}

		public void test_GeometryType()
		{
			//create a geomerty collection
			GeometryCollection geoColl = CreateCollection();

			AssertEquals("GeometryType-1: ", "GeometryCollection", geoColl.GetGeometryType());
		}

		public void test_Apply1()
		{
			//can't be tested
		}

		public void test_Apply2()
		{
			//can't be tested
		}

		public void test_EqualExact()
		{
			//create a geomerty collection
			GeometryCollection geoColl1 = CreateCollection();
			//create another geometry collection that is null
			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
			GeometryCollection geoColl2 = gf.CreateGeometryCollection(null);
			//create another geometry collection that is different
			GeometryCollection geoColl3 = CreateCollection2();
			//create another geometry collection that is different
			GeometryCollection geoColl4 = CreateCollection3();
			//create another geometry collection that is the same as the first
			GeometryCollection geoColl5 = CreateCollection();

			AssertEquals("Equals-1: ", true , geoColl1.Equals(geoColl5));
			AssertEquals("Equals-2: ", false, geoColl1.Equals(geoColl2));
			AssertEquals("Equals-3: ", false, geoColl1.Equals(geoColl3));
			AssertEquals("Equals-4: ", false, geoColl1.Equals(geoColl4));
		}
		
		public void test_GetBoundary()
		{
		}

		public void test_Enumeration()
		{
			//create a geometry collection
			GeometryCollection geoColl = CreateCollection();
            Coordinates coords = new Coordinates();

			int i = 0;
			foreach(Geometry geom in geoColl)
			{
				coords = geom.GetCoordinates();
				foreach(Coordinate coord in coords)
				{
					AssertEquals("Enumeration-1: ", (double)i, coord.X);
					AssertEquals("Enumeration-2: ", (double)i+10, coord.Y);
				}
				i++;
			}
		}

		public void test_CompareToSameClass()
		{
			//create a geometry collection
			GeometryCollection geoColl1 = CreateCollection();

			//create another geometry collection
			GeometryCollection geoColl2 = CreateCollection1();

			//create another geometry collection
			GeometryCollection geoColl3 = CreateCollection4();

			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
			GeometryCollection geoColl4 = gf.CreateGeometryCollection(null);

			AssertEquals("CompareToSameClass1: ", 0, geoColl1.CompareToSameClass(geoColl1));
			AssertEquals("CompareToSameClass2: ", -1, geoColl1.CompareToSameClass(geoColl3));
			AssertEquals("CompareToSameClass3: ", 1, geoColl3.CompareToSameClass(geoColl1));
			AssertEquals("CompareToSameClass4: ", -1, geoColl4.CompareToSameClass(geoColl1));
		}
	}
}
