#region SourceSafe Comments
/* 
 * $Header$
 * $Log$
 * 
 * 4     10/31/02 11:01a Awcoats
 * changed namespace from UrbanScience.Geographic to Geotools.
 * 
 * 3     10/18/02 1:43p Awcoats
 * interface name change.
 * 
 * 2     10/16/02 12:28p Rabergman
 * Removed i=0
 * 
 * 1     9/25/02 2:17p Awcoats
 * 
 */ 
#endregion

#region Using
using System;
using Geotools.SimpleFeatures;
using Geotools.IO;
using NUnit.Framework;
#endregion

namespace Geotools.UnitTests.IO
{
	/// <summary>
	/// Tests the basic functionality of the Geotools.UnitTests.IO.GeometryWktWriterTest class
	/// </summary>
	public class GeometryWktWriterTest : TestCase 
	{
		GeometryFactory _factory = new GeometryFactory();
		GeometryWKTWriter _writer = new GeometryWKTWriter();
		/// <summary>
		/// Initializes a new instance of the GeometryWktWriterTest class. 
		/// </summary>
		/// <param name="name">The name of the test.</param>
		public GeometryWktWriterTest(String name) : base(name) 
		{
		}
	
		protected override void SetUp() 
		{
		}

		protected override void TearDown() 
		{
		}

		#region Point
		public void TestPoint1()
		{
			Coordinate cooordinate = new Coordinate(1.0,2.0);
			IPoint point = _factory.CreatePoint( cooordinate );
			string wkt = _writer.WriteFormatted(point);
			AssertEquals("point wkt1","POINT (1 2)",wkt);
		}

		public void TestPoint2()
		{
			Coordinate cooordinate = new Coordinate(1.2,2.3);
			IPoint point = _factory.CreatePoint( cooordinate );
			string wkt = _writer.WriteFormatted(point);
			AssertEquals("point wkt1","POINT (1.2 2.3)",wkt);
		}
		#endregion

		#region MultiPoint
		public void TestMultiPoint1()
		{
			Coordinates coordinates = new Coordinates();
			coordinates.Add( new Coordinate(1,2) );
			coordinates.Add( new Coordinate(1.2,2.3) );
			MultiPoint multipoint = _factory.CreateMultiPoint( coordinates );
			string wkt = _writer.WriteFormatted(multipoint);
			AssertEquals("multi point","MULTIPOINT (1 2, 1.2 2.3)",wkt);
		}
		#endregion

		#region LineString

		public void TestLineString1()
		{
			Coordinates coordinates = new Coordinates();
			coordinates.Add( new Coordinate(1,2) );
			coordinates.Add( new Coordinate(1.2,2.3) );
			LineString linestring = _factory.CreateLineString( coordinates );
			string wkt = _writer.WriteFormatted(linestring);
			AssertEquals("multi point","LINESTRING (1 2, 1.2 2.3)",wkt);
		}
		#endregion

		#region POLYGON
		//TOD: write POLYGON to WKT
		#endregion

		#region MULTILINESTRING
		//TOD: write MULTILINESTRING to WKT
		#endregion

		#region MULTIPOLYGON
		//TOD: write MULTIPOLYGON to WKT
		#endregion

		#region GEOMETRY
		//TOD: write GEOMETRY to WKT
		#endregion

		#region LINEARRING
		//TOD: write LINEARRING to WKT
		#endregion

		#region GEOMETRYCOLLECTION
		//TOD: write GEOMETRYCOLLECTION to WKT
		#endregion
	}
}

