#region SourceSafe Comments
/* 
 * $Header$
 * $Log$
 * 
 * 3     10/31/02 11:01a Awcoats
 * changed namespace from UrbanScience.Geographic to Geotools.
 * 
 * 2     9/24/02 3:45p Awcoats
 * 
 * 1     9/18/02 5:23p Awcoats
 * 
 */ 
#endregion

#region Using
using System;
using NUnit.Framework;
using Geotools.CoordinateTransformations;
#endregion

namespace Geotools.UnitTests.CoordinateSystems
{
	/// <summary>
	/// Tests the basic functionality of the Geotools.UnitTests.CoordinateSystems.ParameterList class
	/// </summary>
	public class ParameterListTest : TestCase 
	{
		/// <summary>
		/// Initializes a new instance of the PointBaseTest class. 
		/// </summary>
		/// <param name="name">The name of the test.</param>
		public ParameterListTest(String name) : base(name) 
		{
		}
	
		protected override void SetUp() 
		{
		}

		protected override void TearDown() 
		{
		}

		public void Test_Test1()
		{
			ParameterList paramList = new ParameterList();
			paramList.Add("central_meridian",34.0);
			double centralMeridian1 = paramList.GetDouble("central_meridian");
			AssertEquals("Get 1",34.0,centralMeridian1);
			double centralMeridian2 = paramList.GetDouble("central_meridianmissing",4.0);
			AssertEquals("Get 1",4.0,centralMeridian2);
		}
	}
}

