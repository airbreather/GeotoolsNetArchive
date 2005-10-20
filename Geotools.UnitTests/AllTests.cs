using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace Geotools.UnitTests 
{
	public class Global
	{
		public static IDbConnection GetEPSGDatabaseConnection()
		{
			string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+GetUnitTestRootDirectory()+@"\Database\EPSG_v61.mdb";
			OleDbConnection connection = new OleDbConnection(connectionString);
			return connection;
		}

		public static string GetUnitTestRootDirectory()
		{
			// gets the filename of the dll (as it was originally compiled).
			// we can then determine the root.
			/*string dll = Assembly.GetExecutingAssembly().CodeBase.ToLower();
			string dir = dll.Replace("/bin/debug/geotools.unittests.dll","");
			dir = dir.Replace("file:///","");*/
			string dir = @"d:\Projects\Geotools\Geotools.UnitTests";
			return dir;
		}
	}
	// This class bundles all tests into a single suite.
	/*public class AllTests 
	{
	
		public static ITest Suite 
		{
			get  
			{
				TestSuite suite = new TestSuite("Build Server Tests");

				// Use reflection to automagically scan all the classes that 
				// inherit from TestCase and add them to the suite.
				Assembly assembly = Assembly.GetExecutingAssembly();
				foreach(Type type in assembly.GetTypes()) 
				{
					if (type.IsSubclassOf(typeof(TestCase)) && !type.IsAbstract) 
					{
						suite.AddTestSuite(type);
					}
				}
				return suite;
			}
		}
	}*/
}
