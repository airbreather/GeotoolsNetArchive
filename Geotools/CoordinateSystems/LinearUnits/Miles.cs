using System;

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// A strongly typed Miles class.
	/// </summary>
	public class Miles : LinearUnit	
	{
		public Miles() : base( 1609.344 )
		{
		
		}	

		public Miles(double value) : base(1609.344, value)
		{
					
		}	
	}
}
