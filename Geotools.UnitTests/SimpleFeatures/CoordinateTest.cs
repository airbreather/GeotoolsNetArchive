#region SourceSafe Comments
/* 
 * $Header$
 * $Log$
 * 
 * 4     10/21/02 11:04a Rabergman
 * Made test match new formats for methods & properties.
 * 
 * 3     10/15/02 11:42a Rabergman
 * Fixed the MakePrecise test
 * 
 * 2     9/25/02 12:30p Rabergman
 * Daily check in
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
	public class CoordinateTest : TestCase
	{
		PrecisionModel _pm = new PrecisionModel(1.0 ,2.0, 3.0);
		int _srid = 3;
		GeometryFactory _gf = new GeometryFactory();
		//set up variables that will be reused often.
		double testX = 1.0;
		double testY = 2.0;
		double testZ = 3.0;

		/// <summary>
		/// Initializes a new instance of the CoordinateTest class.
		/// </summary>
		public CoordinateTest(String name) : base(name)
		{
		}

		protected override void SetUp()
		{
		}

		protected override void TearDown()
		{
		}

		public void test_Constructor1()
		{
			//create a new coordinate
			Coordinate testCoord = new Coordinate(testX, testY, testZ);

			AssertEquals("Constructor1-X: ", 1.0, testCoord.X);
			AssertEquals("Constructor1-Y: ", 2.0, testCoord.Y);
			AssertEquals("Constructor1-Z: ", 3.0, testCoord.Z);
		}

		public void test_Constructor2()
		{
			//create a coordinate
			Coordinate testCoord1 = new Coordinate(testX, testY, testZ);
			//create a new coordinate using the first
			Coordinate testCoord2 = new Coordinate(testCoord1);

			AssertEquals("Constructor2-X: ", 1.0, testCoord2.X);
			AssertEquals("Constructor2-Y: ", 2.0, testCoord2.Y);
			AssertEquals("Constructor2-Z: ", 3.0, testCoord2.Z);
		}

		public void test_Constructor3()
		{
			//create a coordinate
			Coordinate testCoord = new Coordinate(testX, testY);

			AssertEquals("Constructor3-X: ", 1.0, testCoord.X);
			AssertEquals("Constructor3-Y: ", 2.0, testCoord.Y);
			AssertEquals("Constructor3-Z: ", double.NaN, testCoord.Z);
		}

		public void test_X()
		{
			//create a coordinate
			Coordinate coord = new Coordinate(testX, testY, testZ);

			//test the get property
			double X = coord.X;
			AssertEquals("X1: ", 1.0, X);

			//test the set property
			coord.X = 2.0;
			AssertEquals("X2: ", 2.0, coord.X);
		}
	
		public void test_Y()
		{
			//create a coordinate
			Coordinate coord = new Coordinate(testX, testY, testZ);

			//test the get property
			double Y = coord.Y;
			AssertEquals("Y1: ", 2.0, Y);

			//test the set property
			coord.Y = 1.0;
			AssertEquals("Y2: ", 1.0, coord.Y);
		}

		public void test_Z()
		{
			//create a coordinate
			Coordinate coord = new Coordinate(testX, testY, testZ);

			//test the get property
			double Z = coord.Z;
			AssertEquals("Z1: ", 3.0, Z);

			//test the set property
			coord.Z = 2.0;
			AssertEquals("Z2: ", 2.0, coord.Z);
		}

		public void test_Clone()
		{
			//create a coordinate
			Coordinate coord = new Coordinate(testX, testY, testZ);

			//create a new coordinate by cloning the first
			Coordinate coord2 = coord.Clone() as Coordinate;

			//check that the values are the same
			AssertEquals("Clone: ", true, coord.Equals(coord2));
		}

		public void test_CopyCoordinate()
		{
			//create a coordinate
			Coordinate coord = new Coordinate(testX, testY, testZ);
			//create another coordinate to copy to
			Coordinate coord2 = new Coordinate(5.0, 5.0, 5.0);

			//copy coord2's values into coord
			coord.CopyCoordinate(coord2);

			AssertEquals("CopyCoordinateX: ", 5.0, coord.X);
			AssertEquals("CopyCoordinateY: ", 5.0, coord.Y);
			AssertEquals("CopyCoordinateZ: ", 5.0, coord.Z);
		}

		public void test_Equals2D()
		{
			//create a coordinate
			Coordinate coord = new Coordinate(testX, testY, testZ);
			//create a coordinate that is equal
			Coordinate coord2 = new Coordinate(1.0, 2.0, 3.0);
			//create another coordinate that is equal (becuase the z value is not checked)
			Coordinate coord3 = new Coordinate(1.0, 2.0, 5.0);
			//create a coordinate that is not equal
			Coordinate coord4 = new Coordinate(5.0, 5.0, 5.0);
			//create another coordinate that is not equal
			Coordinate coord5 = new Coordinate(1.0, 5.0, 3.0);

			AssertEquals("Equals2D-T1: ", true, coord.Equals2D(coord2));
			AssertEquals("Equals2D-T2: ", true, coord.Equals2D(coord3));
			AssertEquals("Equals2D-F1: ", false, coord.Equals2D(coord4));
			AssertEquals("Equals2D-F2: ", false, coord.Equals2D(coord5));
		}

		public void test_Equals()
		{
			//create a coordinate
			Coordinate coord = new Coordinate(testX, testY, testZ);
			//create a coordinate that is equal
			Coordinate coord2 = new Coordinate(1.0, 2.0, 3.0);
			//create a coordinate that is not equal
			Coordinate coord3 = new Coordinate(5.0, 5.0, 5.0);
			//create another coordinate that is not equal (becuase the z value is checked)
			Coordinate coord4 = new Coordinate(1.0, 2.0, 5.0);

			AssertEquals("Equals-T: ", true, coord.Equals(coord2));
			AssertEquals("Equals-F1: ", false, coord.Equals(coord3));
			AssertEquals("Equals-F2: ", false, coord.Equals(coord4));
		}

		public void test_GetHashCode()
		{
			//create a coordinate
			Coordinate coord = new Coordinate(testX, testY, testZ);
			//create an equal coordinate
			Coordinate coord2 = new Coordinate(1.0, 2.0, 3.0);
			//create a different coordinate
			Coordinate coord3 = new Coordinate(2.0, 2.0, 3.0);

			AssertEquals("GetHashCode-T1: ", true, coord.GetHashCode()==coord2.GetHashCode());
			AssertEquals("GetHashCode-F1: ", false, coord.GetHashCode()==coord3.GetHashCode());
		}

		public void test_CompareTo()
		{
			//create a coordinate (the z value is not used so there is no need to create it)
			Coordinate coord = new Coordinate(testX, testY);
			//create an equal coordinate
			Coordinate coord2 = new Coordinate(1.0, 2.0);
			//create a coordinate where X is greater & Y is equal
			Coordinate coord3 = new Coordinate(2.0, 2.0);
			//create a coordinate where Y is greater & x is equal
			Coordinate coord4 = new Coordinate(1.0, 3.0);
			//create a coordinate where both X & Y are greater
			Coordinate coord5 = new Coordinate(2.0, 3.0);
			//create a coordinate where X is less & Y is equal
			Coordinate coord6 = new Coordinate(0.0, 2.0);
			//create a coordinate where Y is less & X is equal
			Coordinate coord7 = new Coordinate(1.0, 1.0);
			//create a coordinate where both are less
			Coordinate coord8 = new Coordinate(0.0, 0.0);

			//create a point to send to throw the exception
			_gf = new GeometryFactory(_pm, _srid);
			Point point = _gf.CreatePoint(coord);

			AssertEquals("CompareTo1: ", 0, coord.CompareTo(coord2));
			AssertEquals("CompareTo2: ", -1, coord.CompareTo(coord3));
			AssertEquals("CompareTo3: ", -1, coord.CompareTo(coord4));
			AssertEquals("CompareTo4: ", -1, coord.CompareTo(coord5));
			AssertEquals("CompareTo5: ", 1, coord.CompareTo(coord6));
			AssertEquals("CompareTo6: ", 1, coord.CompareTo(coord7));
			AssertEquals("CompareTo7: ", 1, coord.CompareTo(coord8));

			try
			{
				coord.CompareTo(point);
				Fail("ArgumentException should have been thrown");
			}
			catch(ArgumentException)
			{
			}
		}

		public void test_Equals3D()
		{
			//create a coordinate
			Coordinate coord = new Coordinate(testX, testY, testZ);
			//create a coordinate that is equal
			Coordinate coord2 = new Coordinate(1.0, 2.0, 3.0);
			//create a coordinate that is not equal(X)
			Coordinate coord3 = new Coordinate(0.0, 2.0, 3.0);
			//create another coordinate that is not equal(Y)
			Coordinate coord4 = new Coordinate(1.0, 1.0, 3.0);
			//create another coordinate that is not equal(Z)
			Coordinate coord5 = new Coordinate(1.0, 2.0, 0.0);
			//create another coordinate that is not equal(all)
			Coordinate coord6 = new Coordinate(0.0, 0.0, 0.0);

			AssertEquals("Equals3D1: ", true, coord.Equals3D(coord2));
			AssertEquals("Equals3D2: ", false, coord.Equals3D(coord3));
			AssertEquals("Equals3D3: ", false, coord.Equals3D(coord4));
			AssertEquals("Equals3D4: ", false, coord.Equals3D(coord5));
			AssertEquals("Equals3D5: ", false, coord.Equals3D(coord6));
		}

		public void test_ToString()
		{
			//create a coordinate
			Coordinate coord = new Coordinate(testX, testY, testZ);

			AssertEquals("ToString: ", "(1, 2, 3)", coord.ToString());
		}

		public void test_MakePrecise()
		{
			//create a coordinate
			Coordinate coord = new Coordinate(1.7, 2.3, 3.5);

			coord.MakePrecise();

			AssertEquals("MakePrecise1: ", 2.0, coord.X);
			AssertEquals("MakePrecise2: ", 2.0, coord.Y);
			//doesn't work for the Z value so it should return what was sent
			AssertEquals("MakePrecise3: ", 3.5, coord.Z);
		}

		public void test_Distance()
		{
			//create a coordinate
			Coordinate coord = new Coordinate(testX, testY, testZ);
			//create another coordinate
			Coordinate coord2 = new Coordinate(1.0, 2.0, 3.0);

			AssertEquals("Distance: ", 0.0, coord.Distance(coord2));
		}
	}
}
