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

//TODO add cast of Coordinate[] to Coordinates

#region Using
using System;
using System.Collections;
using System.Text;
using Geotools.Utilities;
#endregion

namespace Geotools.Geometries
{
	/// <summary>
	/// Coordinates class is a typed collection class for the Coordinate class.
	/// </summary>
	public class CoordinateCollection : CollectionBase
	{
		#region Constructors
		/// <summary>
		/// Creates a new, empty instance of Coordinates, with a default initial capacity.
		/// </summary>
		public CoordinateCollection()
		{
		}

		/// <summary>
		/// Creates a new, empty instance of Coordinates that is empty and has the specified initial capacity.
		/// </summary>
		public CoordinateCollection(int capacity)
		{
			InnerList.Capacity = capacity;
		}

		/// <summary>
		/// Creates a new instance of Coordinates adding each coordinate in coords to this instance.
		/// </summary>
		/// <param name="coordinates">The set of coordinates to be used to create this set.</param>
		public CoordinateCollection(CoordinateCollection coordinates)
		{
			for(int i = 0; i < coordinates.Count; i++)
			{
				Add(coordinates[i]);
			}
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the number of elements that the CoordinateCollection can contain.
		/// </summary>
		public int Capacity
		{
			get
			{
				return InnerList.Capacity;
			}
			set
			{
				InnerList.Capacity=value;
			}
		}
		/// <summary>
		/// Represents the Coordinate object entry at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index of the entry to locate in the collection.</param>
		public Coordinate this [int index]
		{
			get
			{
				return (Coordinate)InnerList[index];
			}
			set
			{
				InnerList[index]=value;
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Adds a new coordinate to this set of coordinates.
		/// </summary>
		/// <remarks>Succesive duplicate coordinates are allowed.</remarks>
		/// <param name="coord">The coordinate to be added to the set.</param>
		/// <returns>An integer containing the index of the newly added coordinate.</returns>
		public int Add(Coordinate coord)
		{
			return InnerList.Add(coord);
		}

		/// <summary>
		/// Adds a new coordinate to this set of coordinates.
		/// </summary>
		/// <param name="coord">The coordinate to be added to the set.</param>
		/// <param name="allowRepeated">
		/// A flag used to determine if repeat coordinates will be added to the set.
		/// </param>
		/// <returns>If the add is successful, an integer containing the index of the newly added coordinate.
		///   If repeats are not allowed and the coordinate to be added is a repeat a -1 is returned.</returns>
		public int Add(Coordinate coord, bool allowRepeated)
		{
			if (!allowRepeated)
			{
				if (this.Count>=1)
				{
					Coordinate last = this[this.Count-1];
					if (last.Equals(coord)) 
					{
						return -1;
					}
				}
			}
			return Add(coord);
		}
		public void AddRange(CoordinateCollection coordinates)
		{
			InnerList.AddRange(coordinates);
		}
		public void AddRange(Coordinate[] coordinates)
		{
			InnerList.AddRange(coordinates);
		}

		/// <summary>
		/// Creates a deep copy of these coordinates.
		/// </summary>
		/// <returns>A new set of coordinates containing the same coordinates as the original.</returns>
		public CoordinateCollection Clone()
		{
			return new CoordinateCollection(this);
		}
		/// <summary>
		/// Determines whether a Coordinate is in the CoordinateCollection.
		/// </summary>
		/// <param name="coordinate">The Coordinate to locate in the collection</param>
		/// <returns></returns>
		public bool Contains(Coordinate coordinate)
		{
			return InnerList.Contains(coordinate);
		}
		/// <summary>
		/// Copies the Coordinates into a one-dimensional Coordinate array, starting at the beginning of the target array.
		/// </summary>
		/// <param name="coordinates">The coordinate array to be populated.  Must have 0 based indexing.</param>
		public void CopyTo(Coordinate[] coordinates)
		{
			InnerList.CopyTo(coordinates);
		}

		/// <summary>
		/// Copies the entire CoordinateCollection to a one-dimensional Coordinate Array, starting at the specified index of the target array.
		/// </summary>
		/// <param name="coordinates">The one-dimensional Array that is the destination of the elements copied from Coordinate Collection. The Array must have zero-based indexing. </param>
		/// <param name="arrayIndex">The zero-based index in coordinates at which copying begins. </param>
		public void CopyTo(Coordinate[] coordinates, int arrayIndex)
		{
			InnerList.CopyTo(coordinates,arrayIndex);
		}
		/// <summary>
		/// Copies a range of elements from the CoordinateCollection to a one-dimensional Coordinate Array, starting at the specified index of the target array.
		/// </summary>
		/// <param name="index">The zero-based index in the source Coordinate Collection at which copying begins. </param>
		/// <param name="coordinates">The one-dimensional Array that is the destination of the elements copied from Coordinate Collection. The Array must have zero-based indexing. </param>
		/// <param name="arrayIndex">The zero-based index in coordinates at which copying begins. </param>
		/// <param name="count">The number of elements to copy.</param>
		public void CopyTo(int index,Coordinate[] coordinates,int arrayIndex,int count)
		{
			InnerList.CopyTo(index,coordinates,arrayIndex,count);
		}
		/// <summary>
		/// Determines if the two objects are of the same type and if they contain the elements.
		/// </summary>
		/// <param name="obj">The other object to be compared.</param>
		/// <returns>A bool containing either true of false based on the equality of the two objects.</returns>
		public override bool Equals ( object obj )
		{
			CoordinateCollection other = obj as CoordinateCollection;
			if ( this == other ) return true;			// if they are the same reference objects, then equals is true for sure.
			if ( other == null ) return false;			// not same type or null object then must be false.
			if ( this.Count != other.Count ) return false;		// must be of same length
			for ( int i = 0; i < this.Count; i++ )
			{
				if ( !this[i].Equals( other[i] ) ) return false;
			}
			return true;
		}
		/// <summary>
		/// Returns a unique integer for this object.
		/// </summary>
		/// <remarks>Used with hash tables.</remarks>
		/// <returns>An integer containing the hash code.</returns>
		public override int GetHashCode()
		{
			return InnerList.GetHashCode();
		}
		/// <summary>
		/// Returns the zero-based index of the first occurrence of a Coordinate in the Collection. 
		/// </summary>
		/// <param name="coordinate"></param>
		/// <returns></returns>
		public int IndexOf(Coordinate coordinate)
		{
			return InnerList.IndexOf(coordinate);
		}
		/// <summary>
		/// Reverse the order of the coordinates in this collection.
		/// </summary>
		public void Reverse()
		{
			InnerList.Reverse();
		}
		/// <summary>
		/// Sorts the elements in the collection
		/// </summary>
		public void Sort()
		{
			InnerList.Sort();
		}
		/// <summary>
		/// Sorts the elements in the entire Coordinate colelction using the specified comparer
		/// </summary>
		/// <param name="comparer">The CoordinateCompare (implements IComparer) to use when comparing elements. </param>
		public void Sort(CoordinateCompare comparer)
		{
			InnerList.Sort(comparer);
		}
		/// <summary>
		/// Returns a string representation of the Coordinates object.
		/// </summary>
		/// <remarks>The format is: (x1, y1, NaN),(x2, y2, NaN)...</remarks>
		/// <returns>A string containing the set of coordinates.</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			foreach( object obj in this )
			{
				Coordinate coord = obj as Coordinate;
				sb.Append( coord.ToString() + "," );
			}
			//sb.Remove( sb.Length -1, 1 );		// remove the last comma
			return sb.ToString().TrimEnd(new char[]{','});
		}
		#endregion

		#region JTS Methods

		/// <summary>
		/// Determines if this set of coordinates contains repeating points.
		/// </summary>
		/// <param name="coord">The set of coorinates to be examined.</param>
		/// <returns>A bool based on the presence of repeating points.</returns>
		public static bool HasRepeatedPoints(CoordinateCollection coord)
		{
			for (int i = 1; i < coord.Count; i++) 
			{
				if (coord[i - 1].Equals( coord[i] ) ) 
				{
					return true;
				}
			}
			return false;
		}

		/*/// <summary>
		/// Returns a Coordinate collection that is the reverse order of the coordinates in this collection.
		/// </summary>
		/// <remarks>If a new collection is not required call Reverse() instead.</remarks>
		/// <returns>The set of coordinates with the order of the coordinates reversed.</returns>
		public CoordinateCollection ReverseCoordinateOrder()
		{
			CoordinateCollection coordinates = new CoordinateCollection();
			int numpoints = this.Count;
			coordinates.Capacity = (numpoints - 1);
			for(int i = 0; i < Count; i++)
			{
				coordinates[numpoints - 1 -i] = this[i];
			}
			return coordinates;
		}*/

		/// <summary>
		/// If the coordinate array has repeated points, constructs new array
		/// containing no repeated points.
		/// </summary>
		/// <param name="coord">The set of coordinates to be examined.</param>
		/// <returns>A new set of coordinates with no repeating points.</returns>
		public static CoordinateCollection RemoveRepeatedPoints(CoordinateCollection coord)
		{
			if ( !HasRepeatedPoints(coord) ) 
			{
				return coord;
			}
			CoordinateCollection newCoords = new CoordinateCollection();
			for ( int i = 0; i < coord.Count; i++ )
			{
				newCoords.Add( coord[i],false );
			}
			return newCoords;
		}
		#endregion

		#region JTS1.3 Extentions
		/// <summary>
		/// Returns the minimum coordinate, using the usual lexicographic comparison.
		/// </summary>
		/// <param name="coordinates">The Coordinate Collection to search</param>
		/// <returns>The minimum coordinate in the Collection, found using CompareTo
		/// </returns>
		public static Coordinate MinimumCoordinate(CoordinateCollection coordinates)
		{
			Coordinate minCoord = null;
			for (int i = 0; i < coordinates.Count; i++) 
			{
				if (minCoord == null || minCoord.CompareTo(coordinates[i]) > 0) 
				{
					minCoord = coordinates[i];
				}
			}
			return minCoord;
		}

		/// <summary>
		/// Shifts the positions until firstCoordinate is first.
		/// </summary>
		/// <param name="firstCoordinate">The Coordinate to make first</param>
		public void Scroll(Coordinate firstCoordinate) 
		{
			int i = IndexOf(firstCoordinate);
			//if i is already the first element in the Collection we don't need to do anything
			if (i <= 0) return;
			
			ArrayList newCoordinates = new ArrayList(Count);

			//copy from i to the end of the collection into the new array
			newCoordinates = InnerList.GetRange(i,(Count - i));

			//copy the start of the array onto the end of this	
			newCoordinates.AddRange(InnerList.GetRange(0,(Count -i)));

			this.InnerList.SetRange(0,newCoordinates);
		}

		/// <summary>
		/// Shifts the positions until firstCoordinate is first.
		/// </summary>
		/// <remarks>Static method for compatibility with JTS 1.3, but better to
		/// call Scroll method of your coordinates directly.</remarks>
		/// <param name="coordinates">The CoordinateCollection to scroll</param>
		/// <param name="firstCoordinate">The Coordinate to make first</param>
		public static void Scroll(CoordinateCollection coordinates, Coordinate firstCoordinate) 
		{
			coordinates.Scroll(firstCoordinate);
		}



		#endregion

	}
}
