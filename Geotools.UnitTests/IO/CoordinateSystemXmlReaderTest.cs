#region SourceSafe Comments
/* 
 * $Header$
 * $Log$
 * 
 * 6     10/31/02 11:01a Awcoats
 * changed namespace from UrbanScience.Geographic to Geotools.
 * 
 * 5     10/18/02 2:31p Awcoats
 * chaned names of interfaces. Removed CT_ prefix, and added I
 * 
 * 4     10/18/02 1:43p Awcoats
 * interface name change.
 * 
 * 3     9/25/02 9:18a Awcoats
 * 
 * 2     9/18/02 5:20p Awcoats
 * 
 * 1     9/17/02 4:15p Awcoats
 * 
 */ 
#endregion

#region Using
using System;
using System.IO;
using System.Xml;
using NUnit.Framework;
using Microsoft.XmlDiffPatch;
using Geotools.CoordinateReferenceSystems;
using Geotools.IO;
#endregion

namespace Geotools.UnitTests.IO
{
	/// <summary>
	/// Tests the basic functionality of the Geotools.UnitTests.IO.CoordinateSystemXmlReaderTest class
	/// </summary>
	public class CoordinateSystemXmlReaderTest : TestCase 
	{
		/* tests the reader and the writer by round-tripping an xml file
		 * 
		 * */


		XmlDiff _xmlDiff=null;
		/// <summary>
		/// Initializes a new instance of the PointBaseTest class. 
		/// </summary>
		/// <param name="name">The name of the test.</param>
		public CoordinateSystemXmlReaderTest(String name) : base(name) 
		{
			XmlDiffOptions ignoreMost = XmlDiffOptions.IgnoreChildOrder | 
				XmlDiffOptions.IgnoreComments | 
				XmlDiffOptions.IgnoreDtd | 
				XmlDiffOptions.IgnorePI |
				XmlDiffOptions.IgnoreWhitespace |
				XmlDiffOptions.IgnoreXmlDecl ;

			_xmlDiff = new XmlDiff(ignoreMost);
		}
	
		protected override void SetUp() 
		{
			
		}

		protected override void TearDown() 
		{
		}

		private bool Test(string filename)
		{
			StreamReader tr = new StreamReader(Global.GetUnitTestRootDirectory()+@"\IO\"+filename);
			string xml1= tr.ReadToEnd();
			IInfo info = (IInfo)CoordinateSystemXmlReader.Create(xml1);
			string xml2 = info.XML;

			StringReader textReader1 = new StringReader(xml1);
			XmlTextReader xmlReader1 = new XmlTextReader(textReader1);
			StringReader textReader2 = new StringReader(xml2);
			XmlTextReader xmlReader2 = new XmlTextReader(textReader2);
			return _xmlDiff.Compare(xmlReader1,xmlReader2);
		}

		
		public void TestReadLinearUnit1()
		{
		
			bool same = Test("LinearUnit.xml");
			AssertEquals("LinearUnit Xml compare",true,same);
		}
		public void TestReadAngularUnit1()
		{
			bool same = Test("AngularUnit.xml");
			AssertEquals("AngularUnit Xml compare",true,same);
		}
		public void TestReadWGS84ConversionInfo()
		{
			// can't use the Test() method here because IWGS84ConversionInfo is a struct 
			// and does not implement the IInfo interface.
			string filename="WGS84ConversionInfo.xml";
			
			StreamReader tr = new StreamReader(Global.GetUnitTestRootDirectory()+@"\IO\"+filename);
			string xml1= tr.ReadToEnd();
			WGS84ConversionInfo info = (WGS84ConversionInfo)CoordinateSystemXmlReader.Create(xml1);
			string xml2 = CoordinateSystemXmlWriter.Write(info);

			StringReader textReader1 = new StringReader(xml1);
			XmlTextReader xmlReader1 = new XmlTextReader(textReader1);
			StringReader textReader2 = new StringReader(xml2);
			XmlTextReader xmlReader2 = new XmlTextReader(textReader2);
			bool same= _xmlDiff.Compare(xmlReader1,xmlReader2);
			AssertEquals("WGS84ConversionInfo",true,same);

		}
		public void TestReadPrimeMeridian()
		{
			bool same = Test("PrimeMeridian.xml");
			AssertEquals("PrimeMeridian Xml compare",true,same);
		}

		public void TestReadEllipsoid()
		{
			bool same = Test("Ellipsoid.xml");
			AssertEquals("Ellipsoid Xml compare",true,same);
		}
		public void TestReadHorizontalDatum()
		{
			bool same = Test("HorizontalDatum.xml");
			AssertEquals("HorizontalDatum Xml compare",true,same);
		}
		
		public void TestReadVerticalDatum()
		{
			bool same = Test("VerticalDatum.xml");
			AssertEquals("VerticalDatum Xml compare",true,same);
		}
		public void TestVerticalCoordinateSystem()
		{
			bool same = Test("VerticalCoordinateSystem.xml");
			AssertEquals("VerticalCoordinateSystem Xml compare",true,same);
		}

		public void TestGeographicCoordinateSystem()
		{
			bool same = Test("GeographicCoordinateSystem.xml");
			AssertEquals("GeographicCoordinateSystem Xml compare",true,same);
		}
		public void TestProjection()
		{
			bool same = Test("Projection.xml");
			AssertEquals("Projection  Xml compare",true,same);
		}
		
		public void TestProjectedCoordinateSystem()
		{
			bool same = Test("ProjectedCoordinateSystem.xml");
			AssertEquals("ProjectedCoordinateSystem Xml compare",true,same);
		}
		public void TestCompoundCoordinateSystem()
		{
			bool same = Test("CompoundCoordinateSystem.xml");
			AssertEquals("CompoundCoordinateSystem Xml compare",true,same);
		}
	}
}

