using System;

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// A strongly typed Kilometers class.
	/// </summary>
	public class Kilometers : LinearUnit	
	{
		public Kilometers() : base(1000)
		{
			
		}	
		public Kilometers(double value) : base(1000, value)
		{
			
		}	
	}
}
