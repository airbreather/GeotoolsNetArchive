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
 * 3     10/18/02 12:40p Rabergman
 * Removed tests due to internal classes
 * 
 * 2     9/24/02 3:45p Awcoats
 * 
 * 1     8/02/02 11:01a Awcoats
 * 
 */ 
#endregion

#region Using
using System;
using NUnit.Framework;
using Geotools.CoordinateReferenceSystems;

#endregion

namespace Geotools.UnitTests.CoordinateSystems
{
	/// <summary>
	/// Tests the basic functionality of the UrbanScience.OpenGIS.UnitTests.AngularUnitTest class
	/// </summary>
	public class AngularUnitTest : TestCase 
	{
	
		public AngularUnitTest(String name) : base(name) 
		{
		}
	
		protected override void SetUp() 
		{
		}

		protected override void TearDown() 
		{
		}

	
		public void Test_Constructor() 
		{
//(Note: Test must be commented out because this class has been made internal.  All test are functioning properly otherwise.)
//			OGC.CoordinateSystems.IAngularUnit angularunit = new AngularUnit(1.0,"remarks","authority","authoritycode","name","alias","abbreviation");
//			AssertEquals("ctor 1. ", "abbreviation", angularunit.Abbreviation);
//			AssertEquals("ctor 2. ", "alias", angularunit.Alias);
//			AssertEquals("ctor 3. ", "authority", angularunit.Authority);
//			AssertEquals("ctor 4. ", "authoritycode", angularunit.AuthorityCode);
//			AssertEquals("ctor 5. ", "name", angularunit.Name);
//			AssertEquals("ctor 6. ", 1.0, angularunit.RadiansPerUnit);
//			AssertEquals("ctor 7. ", "remarks", angularunit.Remarks);
//			//AssertEquals("ctor 8. ", null, angularunit.WKT);
//			//AssertEquals("ctor 9. ", null, angularunit.XML);		
		}

	
		public void Test_Constructor2() 
		{
//(Note: Test must be commented out because this class has been made internal.  All test are functioning properly otherwise.)
//			OGC.CoordinateSystems.IAngularUnit angularunit = new AngularUnit(1.0);
//			AssertEquals("ctor 1. ", 1.0, angularunit.RadiansPerUnit);
		}
	}
}

