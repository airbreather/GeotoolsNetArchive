/* 
 * $Header$
 * $Log$
 * 
 * 6     10/31/02 11:01a Awcoats
 * changed namespace from UrbanScience.Geographic to Geotools.
 * 
 * 5     10/18/02 1:43p Awcoats
 * interface name change.
 * 
 * 4     9/25/02 2:00p Awcoats
 * 
 * 3     9/24/02 3:45p Awcoats
 * 
 * 2     9/13/02 8:43a Awcoats
 * 
 * 1     8/14/02 2:21p Awcoats
 * 
 */ 


#region Using
using System;
using System.Data;
using System.Data.SqlClient;
using Geotools.CoordinateReferenceSystems;
using Geotools.CoordinateTransformations;

using NUnit.Framework;
#endregion

namespace Geotools.UnitTests.CoordinateSystems
{
	/// <summary>
	/// Tests the basic functionality of the UrbanScience.OpenGIS.UnitTests.CoordinateSystems.CoordinateSystemEPSGFactoryTest class
	/// </summary>
	public class CoordinateSystemEPSGFactoryTest : TestCase 
	{
		CoordinateSystemEPSGFactory _factory;
		#region Standard NunitStuff

		/// <summary>
		/// Initializes a new instance of the PointBaseTest class. 
		/// </summary>
		/// <param name="name">The name of the test.</param>
		public CoordinateSystemEPSGFactoryTest(String name) : base(name) 
		{
		}
	
		protected override void SetUp() 
		{
			 _factory = new CoordinateSystemEPSGFactory(Global.GetEPSGDatabaseConnection());
		}

		protected override void TearDown() 
		{
		}
		#endregion

		#region Test Database stuff
		
		public void Test_Constructor1() 
		{
			try
			{
				CoordinateSystemEPSGFactory factory = new CoordinateSystemEPSGFactory(null);
				Fail("ArgumentNullException should be thrown");
			}
			catch (ArgumentNullException)
			{
			}
		}

		
		public void Test_Constructor2() 
		{
			CoordinateSystemEPSGFactory factory = CoordinateSystemEPSGFactory.UseDefaultDatabase();
			ILinearUnit linearUnit = factory.CreateLinearUnit("9001");
			AssertEquals("LinearUnit - untis per meter ",1.0,linearUnit.MetersPerUnit);
			AssertEquals("LinearUnit - Authority","EPSG",linearUnit.Authority);
			AssertEquals("LinearUnit - Remarks","Also known as International metre.",linearUnit.Remarks);
		}

		
		public void Test_TestAccessDB() 
		{
			IDbConnection connection = Global.GetEPSGDatabaseConnection();
			CoordinateSystemEPSGFactory factory = new CoordinateSystemEPSGFactory(connection);
			ILinearUnit linearUnit = factory.CreateLinearUnit("9001");
			AssertEquals("LinearUnit - untis per meter ",1.0,linearUnit.MetersPerUnit);
			AssertEquals("LinearUnit - Authority","EPSG",linearUnit.Authority);
			AssertEquals("LinearUnit - Remarks","Also known as International metre.",linearUnit.Remarks);
			connection.Close();
		}
		
		public void Test_TestSqlServer() 
		{
			string connectionString = @"initial catalog=EPSG;data source=localhost;Integrated Security=SSPI;";
			SqlConnection connection = new SqlConnection(connectionString);

			CoordinateSystemEPSGFactory factory = new CoordinateSystemEPSGFactory(connection);
			ILinearUnit linearUnit = factory.CreateLinearUnit("9001");
			AssertEquals("LinearUnit - untis per meter ",1.0,linearUnit.MetersPerUnit);
			AssertEquals("LinearUnit - Authority","EPSG",linearUnit.Authority);
			AssertEquals("LinearUnit - Remarks","Also known as International metre.",linearUnit.Remarks);
			connection.Close();
		}
		#endregion

		#region LinearUnit
		public void Test_LinearUnit()
		{
			try
			{
				ILinearUnit linearUnit = _factory.CreateLinearUnit("1");
				Fail("Linear Unit - Exception should be thrown.");
			}
			catch(ArgumentOutOfRangeException)
			{
			}
			
		}

		public void Test_LinearUnit2()
		{
			try
			{
				ILinearUnit linearUnit = _factory.CreateLinearUnit("9101");
				Fail("Linear Unit - Exception should be thrown because 9101 is an angular unit.");
			}
			catch(ArgumentException)
			{
			}
			
		}
		#endregion

		#region AngularUnit
		
		public void Test_TestAngularUnit() 
		{
	
			IAngularUnit angularUnit = _factory.CreateAngularUnit("9101");
			AssertEquals("AngularUnit - untis per meter ",1.0,angularUnit.RadiansPerUnit);
			AssertEquals("AngularUnit - Authority","EPSG",angularUnit.Authority);
			AssertEquals("AngularUnit - Remarks","SI standard unit.",angularUnit.Remarks);
		}


		/// <summary>
		/// Should not find this record so throw an exception.
		/// </summary>
		public void Test_TestAngularUnit2() 
		{
			try
			{
				IAngularUnit angularUnit3 = _factory.CreateAngularUnit("-1");
				Fail("Angular Unit - Exception should be thrown.");
			}
			catch(ArgumentOutOfRangeException)
			{
			}
		}

		/// <summary>
		/// Try creating a unit that is not 'angular'.
		/// </summary>
		public void Test_TestAngularUnit3() 
		{
			try
			{
				IAngularUnit angularUnit3 = _factory.CreateAngularUnit("9001");
				Fail("Angular Unit - Exception should be thrown. 9001 is a linear unit.");
			}
			catch(ArgumentException)
			{
			}
		}
		#endregion

		#region PrimeMeridian
		public void Test_PrimeMeridian()
		{
			IPrimeMeridian primeMeridian = _factory.CreatePrimeMeridian("8902");
			AssertEquals("PrimeMeridian - degress from Greenwich",-9.0754862, primeMeridian.Longitude);
			AssertEquals("PrimeMeridian - remarks","",primeMeridian.Remarks);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Test_PrimeMeridian2()
		{
			try
			{
				IPrimeMeridian primeMeridian2 = _factory.CreatePrimeMeridian("1");
				Fail("Prime Meridian - Exception should be thrown.");
			}
			catch(ArgumentOutOfRangeException)
			{
			}
		}
		#endregion

		#region HorizontalDatum
		public void Test_CreateHorizontalDatum()
		{	
			try
			{
				IHorizontalDatum horizontalDatum = _factory.CreateHorizontalDatum("-1");
				Fail("Create Horizontal Datum 1.");
			}
			catch(ArgumentException)
			{
			}

			try
			{
				IHorizontalDatum horizontalDatum = _factory.CreateHorizontalDatum(null);
				Fail("Create Horizontal Datum 2.");
			}
			catch(ArgumentNullException)
			{
			}
		}
		#endregion

		#region Ellipsoid
		public void Test_Ellipsoid()
		{
			IEllipsoid ellipsoid = _factory.CreateEllipsoid("7001");
			AssertEquals("Ellipsoid Remarks","Original definition is a=20923713 and b=20853810 feet of 1796.   For the 1936 retriangulation OSGB defines the relationship of feet of 1796 to the International metre through log(1.48401603) exactly [=0.3048007491...]. 1/f is given to 7 decimal places.",ellipsoid.Remarks);
			AssertEquals("Ellipsoid Name","Airy 1830", ellipsoid.Name);
			AssertEquals("Ellipsoid Major Axis","6377563.396", ellipsoid.SemiMajorAxis.ToString());
			AssertEquals("Ellipsoid Minor Axis","6356256.90923729", ellipsoid.SemiMinorAxis.ToString());
			AssertEquals("Ellipsoid flattening",299.3249646, ellipsoid.InverseFlattening);
			AssertEquals("Ellipsoid IVF Definitive", true, ellipsoid.IsIvfDefinitive() );
		}
		#endregion

		#region CreateCompoundCoordinateSystem
		public void Test_CreateCompoundCoordinateSystem()
		{
			//TODO.
		}
		#endregion

		#region CreateProjectedCoordinateSystem
		public void TestCreateProjectedCoordinateSystem1()
		{
			
			try
			{
				_factory.CreateProjectedCoordinateSystem(null);
				Fail("Should not allow a null parameter");
			}
			catch(ArgumentNullException)
			{
			}

			// 4141 is a geographic 2d CRS Kind and thus should not work when trying to create a projected coordinate system.
			try
			{
				_factory.CreateProjectedCoordinateSystem("-1");
				Fail("Should not allow a null parameter");
			}
			catch(ArgumentException)
			{
			}

		}
		public void TestCreateProjectedCoordinateSystem2()
		{
	
			//4326 is a geographic 2d coordinate system - this should throw an ArgumentException
			
			try
			{
				IProjectedCoordinateSystem test = _factory.CreateProjectedCoordinateSystem("4326");
			}
			catch(ArgumentException)
			{
			}
		}
		public void TestCreateProjectedCoordinateSystem3()
		{
			IProjectedCoordinateSystem uknationalgrid = _factory.CreateProjectedCoordinateSystem("27700");
			IProjectedCoordinateSystem utm32 = _factory.CreateProjectedCoordinateSystem("32206");
		}
		#endregion

		#region CreateGeographicCoordinateSystem
		public void TestCreateGeographicCoordinateSystem1()
		{
			
			try
			{
				_factory.CreateGeographicCoordinateSystem(null);
				Fail("Should not allow a null parameter");
			}
			catch(ArgumentNullException)
			{
			}
			try
			{
				_factory.CreateGeographicCoordinateSystem("-1");
				Fail("Should not find this record.");
			}
			catch(ArgumentException)
			{
			}
		}
		public void TestCreateGeographicCoordinateSystem2()
		{
			//27700 is a projected coordinate system - this should throw an exception
			try
			{
				IGeographicCoordinateSystem geographicCoordSystem = _factory.CreateGeographicCoordinateSystem("27700");
			}
			catch(ArgumentException)
			{
			}
		}
		#endregion

		#region TestCreateVerticalCoordinateSystem
		public void TestCreateVerticalCoordinateSystem1()
		{
			IVerticalCoordinateSystem vcs = _factory.CreateVerticalCoordinateSystem("5701");
			AssertEquals("vcs ctor. 1", "Newlyn", vcs.Name);
			AssertEquals("vcs ctor. 2","Ordnance Datum Newlyn", vcs.VerticalDatum.Name);
		}

		public void TestCreateVerticalCoordinateSystem2()
		{
			try
			{
				IVerticalCoordinateSystem vcs = _factory.CreateVerticalCoordinateSystem(null);
				Fail("ArguementNullException should be thrown.");
			}
			catch (ArgumentNullException)
			{
			}
		}

		public void TestCreateVerticalCoordinateSystem3()
		{
			try
			{
				IVerticalCoordinateSystem vcs = _factory.CreateVerticalCoordinateSystem("-1");
				Fail("ArguementException should be thrown.");
			}
			catch (ArgumentException)
			{
			}
		}
		#endregion

		#region CreateVerticalDatum
		public void TestCreateVerticalDatumTest1()
		{
			IVerticalDatum verticalDatum = _factory.CreateVerticalDatum("5101");
			AssertEquals("VeticalDatum ctor1.","Ordnance Datum Newlyn",verticalDatum.Name);
		}
		#endregion

		#region CreateCompoundCoordinateSystem
		public void TestCompoundCoordinateSysem1()
		{
			try
			{
				_factory.CreateCompoundCoordinateSystem("-1");
			}
			catch (ArgumentException)
			{
			}

		}
		public void TestCompoundCoordinateSysem2()
		{
			try
			{
				_factory.CreateCompoundCoordinateSystem(null);
			}
			catch (ArgumentException)
			{
			}

		}
		public void TestCompoundCoordinateSysem3()
		{
			ICompoundCoordinateSystem compoundsCRS = _factory.CreateCompoundCoordinateSystem("7405");

			AssertEquals("ctor 1.","OSGB36 / British National Grid + ODN",compoundsCRS.Name);
			AssertEquals("ctor 2.","OSGB 1936 / British National Grid",compoundsCRS.HeadCS.Name);
			AssertEquals("ctor 3.","Newlyn",compoundsCRS.TailCS.Name);


		}
		#endregion


		#region Helper functions

		public void Test_GetParameters1()
		{
			// parameters for UK National Grid.
			ParameterList parameterList = _factory.GetParameters("19916");//,"9807");
			
			AssertEquals("Test 1",49.0,parameterList.GetDouble("latitude_of_natural_origin") );
			AssertEquals("Test 2",-2.0,parameterList.GetDouble("longitude_of_natural_origin") );
			AssertEquals("Test 3",0.999601272,parameterList.GetDouble("scale_factor_at_natural_origin") );
			AssertEquals("Test 4",400000.0,parameterList.GetDouble("false_easting") );
			AssertEquals("Test 5",-100000.0,parameterList.GetDouble("false_northing") );
		}


		public void Test_GetAxisInfo1()
		{
			IAxisInfo[] axisinfos = _factory.GetAxisInfo("4400");
			AssertEquals("0 Axis",AxisOrientation.East,axisinfos[0].Orientation);
			AssertEquals("0 Axis","Easting",axisinfos[0].Name);
			AssertEquals("1 Axis",AxisOrientation.North,axisinfos[1].Orientation);
			AssertEquals("1 Axis","Northing",axisinfos[1].Name);
		
		}
		public void Test_GetAxisInfo2()
		{
			try
			{
				IAxisInfo[] axisinfos = _factory.GetAxisInfo("-1");
				Fail("Should not find axis info of -1.");
			}
			catch(ArgumentException)
			{
			}
		
		}

		public void Test_GetCoordinateSystemType()
		{
			string coordSysType = _factory.GetCoordinateSystemType("24100");
			AssertEquals("GetCoordinateSystemType","projected",coordSysType);

		}

		public void Test_GetOrientation1()
		{
			AxisOrientation orientation = _factory.GetOrientation("North");
			AssertEquals("GetOrientation North",AxisOrientation.North,orientation);
		}

		public void Test_GetOrientation2()
		{
			AxisOrientation orientation = _factory.GetOrientation("Up");
			AssertEquals("GetOrientation Up",AxisOrientation.Up,orientation);
		}
		#endregion
	}
}
