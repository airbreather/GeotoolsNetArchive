#region SourceSafe Comments
/* 
 * $Header$
 * $Log$
 * 
 * 2     10/21/02 12:19p Rabergman
 * Completed tests
 * 
 * 1     9/30/02 11:36a Rabergman
 * 
 * 1     9/17/02 3:07p Rabergman
 * 
 * 1     8/21/02 2:49p Rabergman
 * 
 */ 
#endregion

#region Using
using System;
using NUnit.Framework;
using Geotools.SimpleFeatures;
#endregion

namespace Geotools.UnitTests.Geometries
{
	/// <summary>
	/// Summary description for CoordinateTest.
	/// </summary>
	public class LinearRingTest : TestCase
	{
		PrecisionModel _precMod = new PrecisionModel(1.0, 2.0, 3.0);
		int _sRID = 3;
		Coordinates _coords = new Coordinates();

		/// <summary>
		/// Method to create a Simple LinearRing for testing purposes
		/// </summary>
		/// <returns>A LinearRing</returns>
		private LinearRing Simple()
		{
			Coordinates coords = new Coordinates();
			Coordinate coord ;//Coordinate(0, 0);

			coord = new Coordinate(10, 13);
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

			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
			LinearRing lr = gf.CreateLinearRing(coords);
			return lr;
		}

		/// <summary>
		/// Method to create a NonSimple LinearRing for testing purposes
		/// </summary>
		/// <returns>A LinearRing</returns>
		private LinearRing NonSimple()
		{
			Coordinates coords = new Coordinates();
			Coordinate coord = new Coordinate(0, 0);

			coord = new Coordinate(2, 2);
			coords.Add(coord);
			coord = new Coordinate(3, 1);
			coords.Add(coord);
			coord = new Coordinate(4, 2);
			coords.Add(coord);
			coord = new Coordinate(5, 3);
			coords.Add(coord);
			coord = new Coordinate(6, 4);
			coords.Add(coord);
			coord = new Coordinate(7, 5);
			coords.Add(coord);
			coord = new Coordinate(7, 6);
			coords.Add(coord);
			coord = new Coordinate(7, 7);
			coords.Add(coord);
			coord = new Coordinate(7, 8);
			coords.Add(coord);
			coord = new Coordinate(7, 9);
			coords.Add(coord);
			coord = new Coordinate(6, 10);
			coords.Add(coord);
			coord = new Coordinate(5, 11);
			coords.Add(coord);
			coord = new Coordinate(6, 12);
			coords.Add(coord);
			coord = new Coordinate(7, 13);
			coords.Add(coord);
			coord = new Coordinate(8, 14);
			coords.Add(coord);
			coord = new Coordinate(9, 13);
			coords.Add(coord);
			coord = new Coordinate(10, 12);
			coords.Add(coord);
			coord = new Coordinate(10, 11);
			coords.Add(coord);
			coord = new Coordinate(10, 10);
			coords.Add(coord);
			coord = new Coordinate(10, 9);
			coords.Add(coord);
			coord = new Coordinate(9, 8);
			coords.Add(coord);
			coord = new Coordinate(8, 7);
			coords.Add(coord);
			coord = new Coordinate(7, 7);
			coords.Add(coord);
			coord = new Coordinate(6, 7);
			coords.Add(coord);
			coord = new Coordinate(5, 8);
			coords.Add(coord);
			coord = new Coordinate(4, 8);
			coords.Add(coord);
			coord = new Coordinate(3, 7);
			coords.Add(coord);
			coord = new Coordinate(2, 6);
			coords.Add(coord);
			coord = new Coordinate(1, 5);
			coords.Add(coord);
			coord = new Coordinate(2, 4);
			coords.Add(coord);
			coord = new Coordinate(1, 3);
			coords.Add(coord);
			coord = new Coordinate(2, 2);
			coords.Add(coord);

			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
			LinearRing lr = gf.CreateLinearRing(coords);
			return lr;
		}

		private LinearRing ThrowsException()
		{
			Coordinates coords = new Coordinates();
			Coordinate coord ;//Coordinate(0, 0);

			coord = new Coordinate(10, 13);
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

			GeometryFactory gf = new GeometryFactory(_precMod, _sRID);
			LinearRing lr = gf.CreateLinearRing(coords);
			return lr;
		}

		/// <summary>
		/// Initializes a new instance of the LinearRingTest class.
		/// </summary>
		public LinearRingTest(String name) : base(name)
		{
		}

		protected override void SetUp()
		{
		}

		protected override void TearDown()
		{
		}

		public void test_Constructor()
		{
		}

		public void test_Coordinates()
		{
			LinearRing lr = Simple();
			AssertEquals("Constructor1: ", false, lr.Equals(null));

			lr = NonSimple();
			AssertEquals("Constructor1: ", false, lr.Equals(null));

			try
			{
				//create a linearRing that is not closed
				LinearRing ls = ThrowsException();
				Fail("should never reach here");
			}
			catch(ArgumentException)
			{
			}
		}

		public void test_IsSimple()
		{
			LinearRing lr = Simple();
			AssertEquals("IsSimple: ", true, lr.IsSimple());
		}

		public void test_GetGeometryType()
		{
			LinearRing lr = Simple();
			AssertEquals("GetGeometryType: ", "LinearRing", lr.GetGeometryType());
		}

		public void test_IsClosed()
		{
			LinearRing lr = Simple();
			AssertEquals("IsClosed: ", true, lr.IsClosed());
		}

		public void test_Clone()
		{
			LinearRing lr = Simple();
			LinearRing lr2 = (LinearRing)lr.Clone();

			AssertEquals("Clone-1: ", false, lr == lr2);
			AssertEquals("Clone-2: ", true, lr.Equals(lr2));
		}
	}
}
