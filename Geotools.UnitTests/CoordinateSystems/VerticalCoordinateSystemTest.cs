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
 * 1     9/18/02 11:25a Awcoats
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
	/// Tests the basic functionality of the Geotools.UnitTests.CoordinateSystems.VerticalCoordinateSystemTest class
	/// </summary>
	public class VerticalCoordinateSystemTest : TestCase 
	{
		/// <summary>
		/// Initializes a new instance of the PointBaseTest class. 
		/// </summary>
		/// <param name="name">The name of the test.</param>
		public VerticalCoordinateSystemTest(String name) : base(name) 
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
//			VerticalDatum datum = VerticalDatum.Ellipsoidal;
//			IAxisInfo axis = AxisInfo.Altitude;
//			ILinearUnit unit = LinearUnit.Meters;
//			
//			VerticalCoordinateSystem vcs = new VerticalCoordinateSystem("test1",datum, axis, unit);
//			AssertEquals("Test1",datum, vcs.VerticalDatum);
//			AssertEquals("Test2",1.0,vcs.VerticalUnit.MetersPerUnit);
//			AssertEquals("ctor. 3",unit, vcs.VerticalUnit);
//			AssertEquals("ctor. 4",axis, vcs.GetAxis(0));
		}


		public void Test_StaticConstructor() 
		{
//(Note: Test must be commented out because this class has been made internal.  All test are functioning properly otherwise.)
//			IVerticalCoordinateSystem vcs = VerticalCoordinateSystem.Ellipsoidal;
//			AssertEquals("Test1","Ellipsoidal",vcs.Name);
		}

	}
}

