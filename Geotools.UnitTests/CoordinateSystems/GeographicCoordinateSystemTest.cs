#region SourceSafe Comments
/* 
 * $Header$
 * $Log$
 * 
 * 5     10/31/02 11:01a Awcoats
 * changed namespace from UrbanScience.Geographic to Geotools.
 * 
 * 4     10/18/02 1:43p Awcoats
 * interface name change.
 * 
 * 3     10/18/02 12:54p Rabergman
 * Removed tests due to internal classes
 * 
 * 2     9/24/02 3:45p Awcoats
 * 
 * 1     8/14/02 2:21p Awcoats
 * 
 */ 
#endregion

#region Using
using System;
using NUnit.Framework;

using Geotools.CoordinateReferenceSystems;
#endregion

namespace UrbanScience.OpenGIS.UnitTests.CoordinateSystems
{
	/// <summary>
	/// Tests the basic functionality of the UrbanScience.OpenGIS.UnitTests.CoordinateSystems.GeographicCoordinateSystemTest class
	/// </summary>
	public class GeographicCoordinateSystemTest : TestCase 
	{
		/// <summary>
		/// Initializes a new instance of the PointBaseTest class. 
		/// </summary>
		/// <param name="name">The name of the test.</param>
		public GeographicCoordinateSystemTest(String name) : base(name) 
		{
		}
	
		protected override void SetUp() 
		{
		}

		protected override void TearDown() 
		{
		}

		/// <summary>
		/// Tests the constructor
		/// </summary>
		public void Test_Constructor() 
		{
//(Note: Test must be commented out because this class has been made internal.  All test are functioning properly otherwise.)
//			ICoordinateSystemFactory csFactory = new CoordinateSystemFactory();
//			IAngularUnit angularUnit = new AngularUnit(1);
//			ILinearUnit linearUnit = new LinearUnit(1);
//			IEllipsoid ellipsoid = csFactory.CreateFlattenedSphere("test",1,2, linearUnit );
//			IAxisInfo axis0 = new IAxisInfo();
//			axis0.Name="axis0name";
//			IAxisInfo axis1 = new IAxisInfo();
//			axis1.Name="axis1name";
//			IWGS84ConversionInfo wgs = new IWGS84ConversionInfo();
//			
//			IPrimeMeridian primeMeridian = csFactory.CreatePrimeMeridian("name", angularUnit,2.0);
//			IHorizontalDatum horizontalDatum = csFactory.CreateHorizontalDatum("datum",IDatumType.IHD_Geocentric,ellipsoid, ref wgs);
//			IGeographicCoordinateSystem gcs = csFactory.CreateGeographicCoordinateSystem("name",angularUnit, horizontalDatum, primeMeridian, ref axis0, ref axis1);
//
//			AssertEquals("ctor 1","name",gcs.Name);
//			AssertEquals("ctor 2",angularUnit,gcs.AngularUnit);
//			AssertEquals("ctor 3",horizontalDatum,gcs.HorizontalDatum);
//			AssertEquals("ctor 4",primeMeridian,gcs.PrimeMeridian);
//			AssertEquals("ctor 5",axis0,gcs.GetAxis(0));
//			AssertEquals("ctor 5",axis1,gcs.GetAxis(1));


		}
	}
}

