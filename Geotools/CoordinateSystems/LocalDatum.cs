using System;

namespace Geotools.CoordinateReferenceSystems
{
	/// <summary>
	/// A local datum.
	/// </summary>
	public class LocalDatum : Datum, ILocalDatum
	{
		/// <summary>
		/// Initializes a new instance of the LocalDatum class with the specified propeties.
		/// </summary>
		/// <param name="name">The name of the datum.</param>
		/// <param name="datumType">The Datum type.</param>
		internal LocalDatum(string name, DatumType datumType) : base(name, datumType)
		{
		}
	}
}
