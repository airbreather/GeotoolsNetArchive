#region SourceSafe Comments
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
 * 4     10/18/02 12:47p Rabergman
 * Removed tests due to internal classes
 * 
 * 3     9/24/02 3:45p Awcoats
 * 
 * 2     9/13/02 8:43a Awcoats
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
	/// Tests the basic functionality of the UrbanScience.OpenGIS.UnitTests.DatumTest class
	/// </summary>
	public class DatumTest : TestCase 
	{
		/// <summary>
		/// Initializes a new instance of the PointBaseTest class. 
		/// </summary>
		/// <param name="name">The name of the test.</param>
		public DatumTest(String name) : base(name) 
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
//			OGC.CoordinateSystems.IDatum datum = new Datum(IDatumType.IHD_Geocentric,"remarks","authority","authoritycode","name","alias","abbreviation");
//			AssertEquals("ctor 0. ", IDatumType.IHD_Geocentric, datum.DatumType);
//			AssertEquals("ctor 1. ", "abbreviation", datum.Abbreviation);
//			AssertEquals("ctor 2. ", "alias", datum.Alias);
//			AssertEquals("ctor 3. ", "authority", datum.Authority);
//			AssertEquals("ctor 4. ", "authoritycode", datum.AuthorityCode);
//			AssertEquals("ctor 5. ", "name", datum.Name);
//			AssertEquals("ctor 6. ", "remarks", datum.Remarks);
//			//AssertEquals("ctor 7. ", null, datum.WKT);
//			//AssertEquals("ctor 8. ", null, datum.XML);	
		}

		/// <summary>
		/// Test getting and setting the properties
		/// </summary>
		public void Test_TestConstructor2()
		{
//			OGC.CoordinateSystems.IDatum datum = new Datum(IDatumType.IHD_Geocentric);
//			AssertEquals("ctor 0. ", IDatumType.IHD_Geocentric, datum.DatumType);
		}
	}
}

