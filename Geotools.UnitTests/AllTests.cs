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
			string dir = @"Geotools.UnitTests\bin\Debug";
			string startDir = Directory.GetCurrentDirectory();
			if (startDir.IndexOf(dir)>=0)
			{
				// we are executing from with NUnitGUI, so change the directory.
				startDir = startDir.Replace(dir,"");
				// remove trailing \
				char[] c= new char[]{'\\'};
				startDir = startDir.TrimEnd(c);
			}
			else
			{
				// we are in the Construction directory.
			}
			//return @"C:\Projects\OGISv1\4CONSTRUCTION\Geotools.UnitTests";
			// need to determine working directory.
			//
			//Console.WriteLine("startdir"+System.Web.HttpUtility.HtmlEncode(Directory.GetCurrentDirectory()));
			return @"C:\CC\GeotoolsNetCVSBuild\GeotoolsNet\Geotools.UnitTests";
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
