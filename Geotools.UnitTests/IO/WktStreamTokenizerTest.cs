#region SourceSafe Comments
/* 
 * $Header$
 * $Log$
 * 
 * 2     10/31/02 11:01a Awcoats
 * changed namespace from UrbanScience.Geographic to Geotools.
 * 
 * 1     9/17/02 4:15p Awcoats
 * 
 */ 
#endregion

#region Using
using System;
using System.IO;
using NUnit.Framework;
using Geotools.IO;
#endregion

namespace Geotools.UnitTests
{
	/// <summary>
	/// Tests the basic functionality of the Geotools.UnitTests.CoordinateSystemWktWriterTest class
	/// </summary>
	public class WktStreamTokenizerTest : TestCase 
	{
		
		/// <summary>
		/// Initializes a new instance of the PointBaseTest class. 
		/// </summary>
		/// <param name="name">The name of the test.</param>
		public WktStreamTokenizerTest(String name) : base(name) 
		{
		}
	
		protected override void SetUp() 
		{
			
		}

		protected override void TearDown() 
		{
		}

		
		public void TestReadQuotedString1() 
		{
			StringReader reader = new StringReader("\"testA\"..");
			WktStreamTokenizer tokenizer = new WktStreamTokenizer(reader);
			string word=tokenizer.ReadDoubleQuotedWord();
			AssertEquals("test1","testA",word);
		}
		public void TestReadQuotedString2() 
		{
			StringReader reader = new StringReader("\"Two words\"..");
			WktStreamTokenizer tokenizer = new WktStreamTokenizer(reader);
			string word=tokenizer.ReadDoubleQuotedWord();
			AssertEquals("test1","Two words",word);
		}
		public void TestReadAuthority1() 
		{
			StringReader reader = new StringReader("AUTHORITY[\"EPSG\",\"9102\"]");
			WktStreamTokenizer tokenizer = new WktStreamTokenizer(reader);
			string authority="";
			string authorityCode=""; 
			tokenizer.ReadAuthority(ref authority, ref authorityCode);
			AssertEquals("test 1","EPSG",authority);
			AssertEquals("test 2","9102",authorityCode);
		}
		public void TestReadAuthority2() 
		{
			StringReader reader = new StringReader("OPPS[\"EPSG\",\"9102\"]");
			WktStreamTokenizer tokenizer = new WktStreamTokenizer(reader);
			string authority="";
			string authorityCode=""; 
			try
			{
				tokenizer.ReadAuthority(ref authority, ref authorityCode);
			}
			catch(ParseException)
			{

			}
		}
	
		
		

	}
}
