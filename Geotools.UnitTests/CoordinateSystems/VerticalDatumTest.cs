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
 * 2     10/18/02 12:54p Rabergman
 * Removed tests due to internal classes
 * 
 * 1     9/24/02 3:44p Awcoats
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
	/// Tests the basic functionality of the Geotools.UnitTests.CoordinateSystems.VerticalDatumTest class
	/// </summary>
	public class VerticalDatumTest : TestCase 
	{
		/// <summary>
		/// Initializes a new instance of the PointBaseTest class. 
		/// </summary>
		/// <param name="name">The name of the test.</param>
		public VerticalDatumTest(String name) : base(name) 
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
//			VerticalDatum verticalDatum = new VerticalDatum(IDatumType.IHD_Geocentric,"remarks","authoritycode","authority","name","alias","abbreviation");
//			AssertEquals("ctor1.","remarks",verticalDatum.Remarks);
//			AssertEquals("ctor2.","authority",verticalDatum.Authority);
//			AssertEquals("ctor3.","authoritycode",verticalDatum.AuthorityCode);
//			AssertEquals("ctor4.","name",verticalDatum.Name);
//			AssertEquals("ctor5.","alias",verticalDatum.Alias);
//			AssertEquals("ctor6.","abbreviation",verticalDatum.Abbreviation);
//			AssertEquals("ctor7.",IDatumType.IHD_Geocentric,verticalDatum.DatumType);
		}

	}
}

