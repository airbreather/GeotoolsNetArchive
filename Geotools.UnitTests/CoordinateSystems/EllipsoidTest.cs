#region SourceSafe Comments
/* 
 * $Header$
 * $Log$
 * 
 * 8     10/31/02 11:01a Awcoats
 * changed namespace from UrbanScience.Geographic to Geotools.
 * 
 * 7     10/18/02 1:43p Awcoats
 * interface name change.
 * 
 * 6     10/18/02 12:54p Rabergman
 * Removed tests due to internal classes
 * 
 * 5     9/24/02 3:45p Awcoats
 * 
 * 4     9/13/02 8:43a Awcoats
 * 
 * 3     8/15/02 11:21a Awcoats
 * 
 * 2     8/14/02 2:22p Awcoats
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

namespace UrbanScience.OpenGIS.UnitTests.CoordinateSystems
{
	/// <summary>
	/// Tests the basic functionality of the UrbanScience.OpenGIS.UnitTests.CoordinateSystems.EllipsoidTest class
	/// </summary>
	public class EllipsoidTest : TestCase 
	{
		/// <summary>
		/// Initializes a new instance of the PointBaseTest class. 
		/// </summary>
		/// <param name="name">The name of the test.</param>
		public EllipsoidTest(String name) : base(name) 
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
		public void Test_Constructor1() 
		{
//(Note: Test must be commented out because this class has been made internal.  All test are functioning properly otherwise.)
//			ICoordinateSystemFactory csFactory = new CoordinateSystemFactory();
//			IEllipsoid ellipsoid = new Ellipsoid(20926348,-1.0,294.26068,true, new LinearUnit(1));
//			AssertEquals("ctor. 2 ",20926348.0,ellipsoid.SemiMajorAxis);
//			AssertEquals("ctor. 3 ",20855233.000877455, ellipsoid.SemiMinorAxis);
		}
	
	}
}

