/*
 *  Copyright (C) 2002 Urban Science Applications, Inc. (translated from Java Topology Suite, 
 *  Copyright 2001 Vivid Solutions)
 *
 *  This library is free software; you can redistribute it and/or
 *  modify it under the terms of the GNU Lesser General Public
 *  License as published by the Free Software Foundation; either
 *  version 2.1 of the License, or (at your option) any later version.
 *
 *  This library is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 *  Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public
 *  License along with this library; if not, write to the Free Software
 *  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 *
 */

#region Using Statements
#endregion

namespace Geotools.SimpleFeatures
{
	/// <summary>A Coordinate filter can either record information 
	/// about each Coordinate or change the Coordinate in some way. Coordinate filters 
	/// implement the interface CoordinateFilter.
	/// </summary>
	/// <remarks>
	/// Geometry classes support the concept of applying a Coordinate filter to every 
	/// Coordinate in the Geometry. (CoordinateFilter is an example of 
	/// the Gang-of-Four Visitor pattern). Coordinate filters can be used to 
	/// implement such things as Coordinate transformations, centroid and envelope 
	/// computation, and many other functions.
	///</remarks>
	public interface ICoordinateFilter
	{
		/// <summary>
		/// Performs an operation with or on this coordinate.
		/// </summary>
		/// <param name="coord">The coordinate to which the filter is applied.</param>
		void Filter(Coordinate coord);
	}
}
