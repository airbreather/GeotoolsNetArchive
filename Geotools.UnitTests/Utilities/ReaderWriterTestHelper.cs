#region SourceSafe Comments
/* 
 * $Header$
 * $Log$
 * Revision 1.2  2003/01/02 20:38:20  awcoats
 * *** empty log message ***
 *
 * 
 * 4     11/04/02 3:20p Rabergman
 * Changed using namespaces
 * 
 * 3     10/31/02 11:01a Awcoats
 * changed namespace from UrbanScience.Geographic to Geotools.
 * 
 * 2     10/21/02 2:23p Rabergman
 * Changed call to CreateFromWkt to match new signature.
 * 
 * 1     10/11/02 5:04p Rabergman
 * 
 */ 
#endregion

#region Using
using System;
using System.IO;
using Geotools.Geometries;
using Geotools.IO;
#endregion

namespace Geotools.UnitTests.Utilities
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class ReaderWriterTestHelper
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the Class1 class.
		/// </summary>
		public ReaderWriterTestHelper() 
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Properties
		#endregion

		#region Methods
		public static bool TestHelper(string wkt)
		{
			PrecisionModel pm = new PrecisionModel(1, 0, 0);
			GeometryFactory fact = new GeometryFactory(pm, 0);

			//read wkt
			Geometry a = (Geometry)fact.CreateFromWKT(wkt);

			//write wkb
			FileStream fs = new FileStream("TestFile.wkb", FileMode.Create);
			BinaryWriter bw = new BinaryWriter(fs);
			GeometryWkbWriter bWriter = new GeometryWkbWriter(fact);
			bWriter.Write(a, bw, (byte)1);
			bw.Close();
			fs.Close();

			//read wkb
			fs = new FileStream("TestFile.wkb", FileMode.Open);
			byte[] bytes = new byte[fs.Length];
			for(int i = 0; i < fs.Length; i++)
			{
				bytes[i] = (byte)fs.ReadByte();
			}
			GeometryWkbReader bReader = new GeometryWkbReader(fact);
			Geometry geom = bReader.Create(bytes);
			fs.Close();

			//write to wkt & compare with original text.
			bool results = ( Compare.WktStrings(wkt,a.ToText()));
			return results;
		}
		#endregion

	}
}