#region SourceSafe Comments
/* 
 * $Header$
 * $Log$
 * 
 * 3     10/31/02 11:01a Awcoats
 * changed namespace from UrbanScience.Geographic to Geotools.
 * 
 * 2     10/08/02 12:15p Awcoats
 * 
 * 1     9/19/02 9:39a Awcoats
 * 
 */ 
#endregion

#region Using
using System;
using System.IO;
#endregion

namespace Geotools.UnitTests.Utilities
{
	/// <summary>
	/// Summary description for FileCompare.
	/// </summary>
	public class Compare
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the FileCompare class.
		/// </summary>
		public static bool CompareAgainstString(string filename, string compareString)
		{
			StreamReader tr = new StreamReader(filename);
			string filestring=  tr.ReadToEnd();
			tr.Close();
			string s1= filestring.Trim();
			string s2= compareString.Trim();
			bool same = filestring.TrimEnd()==compareString.TrimEnd();
			return same;
		}

		/// <summary>
		/// Compares strings ignoring spaces and case.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static bool WktStrings(string a, string b)
		{
			string a1=a.Replace(" ","").ToUpper();
			string b1=b.Replace(" ","").ToUpper();
			a1=a1.Replace("\n","");
			b1=b1.Replace("\n","");
			a1=a1.Replace("\t","");
			b1=b1.Replace("\t","");
			return a1==b1;
		}
		#endregion
	}
}
