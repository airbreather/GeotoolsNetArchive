#region SourceSafe Comments
/* 
 * $Header$
 * $Log$
 * 
 * 2     10/21/02 11:04a Rabergman
 * Made test match new formats for methods & properties.
 * 
 * 1     10/08/02 12:24p Rabergman
 * 
 * 2     9/27/02 3:04p Rabergman
 * Daily check in
 * 
 * 1     9/25/02 3:01p Rabergman
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
	/// Summary description for MultiLineStringTest.
	/// </summary>
	public class MultiPolygonTest : TestCase
	{
		//set up needed variables
		PrecisionModel _precMod = new PrecisionModel(1.0, 2.0, 3.0);
		int _sRID = 3;
		MultiLineString _mls1;

		/// <summary>
		/// Initializes a new instance of the MultiPolygonTest class.
		/// </summary>
		public MultiPolygonTest(String name) : base(name)
		{
		}

		protected override void SetUp()
		{
		}

		protected override void TearDown()
		{
		}

		private MultiPolygon CreateMP1()
		{
			Polygon[] polygons = new Polygon[2];
			LineString[] rings = new LineString[2];

			Coordinates coords = new Coordinates();
			Coordinate coord = new Coordinate(5, 1);
			coords.Add(coord);
			coord = new Coordinate(6, 2);
			coords.Add(coord);
			coord = new Coordinate(7, 3);
			coords.Add(coord);
			coord = new Coordinate(6, 4);
			coords.Add(coord);
			coord = new Coordinate(5, 5);
			coords.Add(coord);
			coord = new Coordinate(4, 4);
			coords.Add(coord);
			coord = new Coordinate(3, 3);
			coords.Add(coord);
			coord = new Coordinate(4, 2);
			coords.Add(coord);
			coord = new Coordinate(5, 1);
			coords.Add(coord);

			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);

            LinearRing exterior1 = gf.CreateLinearRing(coords);
			polygons[0] = gf.CreatePolygon(exterior1);
			rings[0] = exterior1 as LineString;

			coords = new Coordinates();
			coord = new Coordinate(5, 1);
			coords.Add(coord);
			coord = new Coordinate(6, 2);
			coords.Add(coord);
			coord = new Coordinate(7, 3);
			coords.Add(coord);
			coord = new Coordinate(6, 4);
			coords.Add(coord);
			coord = new Coordinate(5, 5);
			coords.Add(coord);
			coord = new Coordinate(4, 4);
			coords.Add(coord);
			coord = new Coordinate(3, 3);
			coords.Add(coord);
			coord = new Coordinate(4, 2);
			coords.Add(coord);
			coord = new Coordinate(5, 1);
			coords.Add(coord);

			LinearRing exterior2 = gf.CreateLinearRing(coords);
			polygons[1] = gf.CreatePolygon(exterior2);
			rings[1] = exterior2;

			_mls1 = gf.CreateMultiLineString(rings);

			return gf.CreateMultiPolygon(polygons);
		}

		private MultiPolygon CreateMP2()
		{
			Polygon[] polygons = new Polygon[2];

			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);

			Coordinates coords = new Coordinates();
			Coordinate coord = new Coordinate(10, 13);
			coords.Add(coord);
			coord = new Coordinate(11, 13);
			coords.Add(coord);
			coord = new Coordinate(12, 13);
			coords.Add(coord);
			coord = new Coordinate(13, 14);
			coords.Add(coord);
			coord = new Coordinate(14, 15);
			coords.Add(coord);
			coord = new Coordinate(15, 16);
			coords.Add(coord);
			coord = new Coordinate(15, 17);
			coords.Add(coord);
			coord = new Coordinate(15, 18);
			coords.Add(coord);
			coord = new Coordinate(14, 19);
			coords.Add(coord);
			coord = new Coordinate(13, 20);
			coords.Add(coord);
			coord = new Coordinate(12, 21);
			coords.Add(coord);
			coord = new Coordinate(11, 21);
			coords.Add(coord);
			coord = new Coordinate(10, 21);
			coords.Add(coord);
			coord = new Coordinate(9, 20);
			coords.Add(coord);
			coord = new Coordinate(8, 19);
			coords.Add(coord);
			coord = new Coordinate(7, 18);
			coords.Add(coord);
			coord = new Coordinate(7, 17);
			coords.Add(coord);
			coord = new Coordinate(7, 16);
			coords.Add(coord);
			coord = new Coordinate(8, 15);
			coords.Add(coord);
			coord = new Coordinate(9, 14);
			coords.Add(coord);
			coord = new Coordinate(10, 13);
			coords.Add(coord);

			LinearRing exterior = gf.CreateLinearRing(coords);

			coords = new Coordinates();
			coord = new Coordinate(10, 16);
			coords.Add(coord);
			coord = new Coordinate(11, 17);
			coords.Add(coord);
			coord = new Coordinate(10, 18);
			coords.Add(coord);
			coord = new Coordinate(9, 17);
			coords.Add(coord);
			coord = new Coordinate(10, 16);
			coords.Add(coord);

			LinearRing interior = gf.CreateLinearRing(coords);
			LinearRing[] linearRings = new LinearRing[1];
			linearRings[0] = interior;

			polygons[0] = gf.CreatePolygon(exterior, linearRings);

			coords = new Coordinates();
			coord = new Coordinate(5, 1);
			coords.Add(coord);
			coord = new Coordinate(6, 2);
			coords.Add(coord);
			coord = new Coordinate(7, 3);
			coords.Add(coord);
			coord = new Coordinate(6, 4);
			coords.Add(coord);
			coord = new Coordinate(5, 5);
			coords.Add(coord);
			coord = new Coordinate(4, 4);
			coords.Add(coord);
			coord = new Coordinate(3, 3);
			coords.Add(coord);
			coord = new Coordinate(4, 2);
			coords.Add(coord);
			coord = new Coordinate(5, 1);
			coords.Add(coord);

			exterior = gf.CreateLinearRing(coords);
			polygons[1] = gf.CreatePolygon(exterior);

			return gf.CreateMultiPolygon(polygons);
		}

		public void test_Constructor()
		{
			//create a geomerty collection
			MultiPolygon mp1 = CreateMP1();
			MultiPolygon mp2 = CreateMP2();

			AssertEquals("Constructor-1: ", false, mp1.IsEmpty());
			AssertEquals("Constructor-2: ", false, mp2.IsEmpty());
		}

		public void test_GeometryType()
		{
			MultiPolygon mp1 = CreateMP1();

			AssertEquals("GeometryType: ", "MultiPolygon", mp1.GetGeometryType());
		}

		public void test_Coordinates()
		{
			MultiPolygon mp1 = CreateMP1();
			AssertEquals("Coordinates-1: ", 18, mp1.GetCoordinates().Count);

			MultiPolygon mp2 = CreateMP2();
			AssertEquals("Coordinates-2: ", 35, mp2.GetCoordinates().Count);
		}

		public void test_GetBoundary()
		{
			MultiPolygon mp1 = CreateMP1();
			MultiLineString mls = mp1.GetBoundary() as MultiLineString;
			for(int i = 0 ; i < mls.GetNumGeometries(); i++)
			{
				AssertEquals("GetBoundary: ", true, mls[i].GetCoordinates().Equals(_mls1[i].GetCoordinates()));
			}
		}


	}
}
