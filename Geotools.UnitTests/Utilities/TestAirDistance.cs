using System;
using NUnit.Framework;
using System.Drawing;
using com.vividsolutions.jts.geom;
using Geotools.Utilities;
namespace Geotools.UnitTests.Utilities
{
	[TestFixture]
	public class TestAirDistance
	{
  
		public TestAirDistance()
		{
		}
    
		[SetUp]
		public void SetUp()
		{
		}
    

		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestValidCoordinate1X()
		{
			Coordinate coord1 = new Coordinate(-191,0);
			Coordinate coord2 = new Coordinate(0,0);
			AirDistance.Calculate(coord1, coord2);
		}

		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestValidCoordinate1X2()
		{
			Coordinate coord1 = new Coordinate(181,0);
			Coordinate coord2 = new Coordinate(0,0);
			AirDistance.Calculate(coord1, coord2);
		}

		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestValidCoordinate1Y()
		{
			Coordinate coord1 = new Coordinate(0,-91);
			Coordinate coord2 = new Coordinate(0,0);
			AirDistance.Calculate(coord1, coord2);
		}

		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestValidCoordinate1Y2()
		{
			Coordinate coord1 = new Coordinate(0,91);
			Coordinate coord2 = new Coordinate(0,0);
			AirDistance.Calculate(coord1, coord2);
		}

	}
}