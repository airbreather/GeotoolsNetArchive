#region SourceSafe Comments
/* 
 * $Header$
 * $Log$
 * 
 * 5     10/25/02 12:26p Rabergman
 * Removed all references to OGC
 * 
 * 4     10/21/02 11:15a Rabergman
 * added ocg stuff back in temporarily.
 * 
 * 3     10/21/02 11:04a Rabergman
 * Made test match new formats for methods & properties.
 * 
 * 2     10/15/02 11:43a Rabergman
 * Changed numbering on multipoint tests & fixed multipoint test 5
 * 
 * 1     10/09/02 1:40p Awcoats
 * 
 */ 
#endregion

#region Using
using System;
using System.Data;
using NUnit.Framework;
using Geotools.IO;
using Geotools.SimpleFeatures;
using Geotools.CoordinateTransformations;
using Geotools.UnitTests.Utilities;
#endregion

namespace Geotools.UnitTests.Geometries
{
	/// <summary>
	/// Tests the basic functionality of the Geotools.UnitTests.Geometries.ProjectTest class
	/// </summary>
	public class ProjectTest : TestCase 
	{
		CoordinateTransformationEPSGFactory _CTfactory;
		PrecisionModel _pm = new PrecisionModel(1.0, 0.0, 0.0);
		ICoordinateTransformation _UKNationalGrid1;
		GeometryFactory _geometryFactory;
		/// <summary>
		/// Initializes a new instance of the PointBaseTest class. 
		/// </summary>
		/// <param name="name">The name of the test.</param>
		public ProjectTest(String name) : base(name) 
		{
		}

		public bool Compare(string wkt, string expectedProjectedWkt)
		{
			Geometry geometry =(Geometry)_geometryFactory.CreateFromWKT(wkt);
			Geometry projectedGeometry = (Geometry)geometry.Project(_UKNationalGrid1);
			string actualProjectedWkt=projectedGeometry.ToText();
			return Geotools.UnitTests.Utilities.Compare.WktStrings(expectedProjectedWkt,actualProjectedWkt);
		}
		public void Test1()
		{
			IDbConnection connection = Global.GetEPSGDatabaseConnection();
			_CTfactory = new CoordinateTransformationEPSGFactory(connection);
			_UKNationalGrid1 = _CTfactory.CreateFromTransformationCode("1681");
			_geometryFactory = new GeometryFactory(_pm,4326);
			string wkt = "POINT ( -2.0 49.0 )";
			AssertEquals("Point 1",true,Compare(wkt,"POINT (400000 -100000)"));

			wkt = "MULTIPOINT( -2 49, -1 50)";
			AssertEquals("Multipoint 1",true,Compare(wkt,"MULTIPOINT (400000 -100000, 471659.59027931013 11644.492008123649)"));

			wkt = "MULTIPOINT EMPTY";
			AssertEquals("Multipoint 2",true,Compare(wkt,"MULTIPOINT EMPTY"));

			wkt = "LINESTRING(50 31, 54 31, 54 29, 50 29, 50 31 )";
			AssertEquals("LineString 1 1",true,Compare(wkt,"LINESTRING (-7.5557896002384908 49.766496583001434, -7.555734311078294 49.766499242352, -7.5557322582139372 49.76648133658518, -7.5557875473539609 49.7664786772363, -7.5557896002384908 49.766496583001434)"));

			wkt = "POLYGON( ( 50 31, 54 31, 54 29, 50 29, 50 31) )";
			AssertEquals("Multipoint 3",true,Compare(wkt,"POLYGON ((-7.5557896002384908 49.766496583001434, -7.555734311078294 49.766499242352, -7.5557322582139372 49.76648133658518, -7.5557875473539609 49.7664786772363, -7.5557896002384908 49.766496583001434))"));


			wkt = "POLYGON( ( 1 1, 10 1, 10 10, 1 10, 1 1),(4 4, 5 4, 5 5, 4 5, 4 4 ))";
			AssertEquals("Multipoint 4",true,Compare(wkt,"POLYGON ((-7.5564360950250204 49.76619541764267, -7.5563116953103844 49.766201401812275, -7.5563209340852389 49.7662819776865, -7.5564453340041196 49.766275993499939, -7.5564360950250204 49.76619541764267),"+ 
																	"(-7.5563977080904809 49.766224271001896, -7.5563838858929149 49.7662249359119, -7.55638491243555 49.7662338887858, -7.5563987346356365 49.766233223875588, -7.5563977080904809 49.766224271001896))"));

			wkt = "MULTILINESTRING (( 10.05  10.28 , 20.95  20.89 ),( 20.95  20.89, 31.92 21.45)) ";
			AssertEquals("Multipoint 5",false,Compare(wkt,"MULTILINESTRING ((-7.5563209340852389 49.7662819776865, -7.556192977006396 49.766378155393944),"+ 
																	"(-7.556192977006396 49.766378155393944, -7.556041958756 49.766394421940312))"));

			wkt = "MULTIPOLYGON (((10 10, 10 20, 20 20, 20 15 , 10 10), (50 40, 50 50, 60 50, 60 40, 50 40)))";
			AssertEquals("Multipoint 6",true,Compare(wkt,"MULTIPOLYGON (((-7.5563209340852389 49.7662819776865, -7.5563311994394464 49.766371506432854, -7.556192977006396 49.766378155393944, -7.5561878444489494 49.766333391010683, -7.5563209340852389 49.7662819776865),"+ 
																	"(-7.5557988382443027 49.766577158943079, -7.5558091027440151 49.766666687764328, -7.5556708793489991 49.766673336131227, -7.5556606151014512 49.766583807289045, -7.5557988382443027 49.766577158943079)))"));

			wkt = "GEOMETRYCOLLECTION(POINT ( 3 4 ),LINESTRING(50 31, 54 31, 54 29, 50 29, 50 31 ))";
			AssertEquals("Multipoint 7",true,Compare(wkt,"GEOMETRYCOLLECTION (POINT (955682.872367636 -5083270.4404414054),"+
														"LINESTRING (-7.5557896002384908 49.766496583001434, -7.555734311078294 49.766499242352, -7.5557322582139372 49.76648133658518, -7.5557875473539609 49.7664786772363, -7.5557896002384908 49.766496583001434))"));

		}	
	}
}

