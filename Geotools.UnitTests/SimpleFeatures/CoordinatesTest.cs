#region SourceSafe Comments
/* 
 * $Header$
 * $Log$
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
	public class CoordinatesTest : TestCase
	{
		/// <summary>
		/// Initializes a new instance of the CoordinatesTest class.
		/// </summary>
		public CoordinatesTest(String name) : base(name)
		{
		}

		protected override void SetUp()
		{
		}

		protected override void TearDown()
		{
		}

		private Coordinates Coords1()
		{
			Coordinates coords = new Coordinates();
			Coordinate coord = new Coordinate();
			for(int i = 0; i< 10; i++)
			{
				coord = new Coordinate(i, i+10);
				coords.Add(coord);
			}
			return coords;
		}

		public void test_Constructor()
		{
			Coordinates coords = new Coordinates();
			AssertEquals("Constructor-1: ", 0, coords.Count);

			coords = Coords1();
			AssertEquals("Constructor-2: ", 10, coords.Count);
		}

		public void test_Count()
		{
			Coordinates coords = Coords1();
			AssertEquals("Constructor-2: ", 10, coords.Count);
		}

		public void test_Add()
		{
			Coordinates coords = Coords1();
			Coordinate coord = new Coordinate(4.0, 2.0);
			coords.Add(coord);
			AssertEquals("Add-1: ", 11, coords.Count);
			AssertEquals("Add-2: ", 4.0, coords[10].X);
			AssertEquals("Add-3: ", 2.0, coords[10].Y);

			coord = new Coordinate();
			coords.Add(coord);
			AssertEquals("Add-4: ", 12, coords.Count);
			//Zeros are added for null coordinates
			AssertEquals("Add-5: ", 0.0, coords[11].X);
			AssertEquals("Add-6: ", 0.0, coords[11].Y);
		}

		public void test_this()
		{
			Coordinates coords = Coords1();

			AssertEquals("this-1: ", 1.0, coords[1].X);
			AssertEquals("this-2: ", 11.0, coords[1].Y);
		}

		public void test_GetEnumerator()
		{
			Coordinates coords = Coords1();

			int counter = 0;
			foreach(Coordinate coord in coords)
			{
				if(coord != null)
				{
					counter++;
				}
			}
			AssertEquals("GetEnumerator: ", true, counter > 0);
		}

		public void test_ToString()
		{
			Coordinates coords = new Coordinates();
			Coordinate coord = new Coordinate(2.0, 4.1);
			coords.Add(coord);
			coord = new Coordinate(6.2, 8.4);
			coords.Add(coord);

			AssertEquals("ToString-1: ", "(2, 4.1, NaN),(6.2, 8.4, NaN)", coords.ToString());
		}

		public void test_ReverseCoordinateOrder()
		{
			Coordinates coords = Coords1();
			Coordinates coordsReverse = coords.ReverseCoordinateOrder();
			for(int i = 0; i < coords.Count; i++)
			{
				AssertEquals("ReverseCoordinateOrder: ", true, coords[i].Equals(coordsReverse[9-i]));
			}
		}
	}
}
