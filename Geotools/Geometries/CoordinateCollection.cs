/* Copyright (C) 2003 Beacon Dodsworth Ltd.
 * Modified from Coordinates.cs (geotoolsnet) which is
 * Copyright (C) 2002 Urban Science Applications, Inc. 
 * (translated from Java Topology Suite,  Copyright 2001 Vivid Solutions)
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

#region Using
using System;
using System.Collections;
#endregion

namespace Geotools.Geometries
{
	[Serializable]
	/// <summary>
	/// Coordinates class is a typed collection class for the Coordinate class.
	/// </summary>
	public class Coordinates : ICollection, IList, IEnumerable, ICloneable
	{
		private const int DefaultMinimumCapacity = 16;

		private Coordinate[] m_array = new Coordinate[DefaultMinimumCapacity];
		private int m_count = 0;
		private int m_version = 0;

		#region Constructors
		/// <summary>
		/// Creates a new, empty instance of Coordinates.
		/// </summary>
		public Coordinates()
		{ }
		
		/// <summary>
		/// Creates a new instance of Coordinates adding each coordinate in coords to this instance.
		/// </summary>
		/// <param name="coords">The set of coordinates to be used to create this one.</param>
		public Coordinates(Coordinates coords)
		{ AddRange(coords); }

		/// <summary>
		/// Creates a new instance of Coordinates adding each coordinate in array to this instance.
		/// </summary>
		/// <param name="array">An array of Coordinates to be used.</param>
		public Coordinates(Coordinate[] array)
		{ AddRange(array); }
		
		#endregion

		#region Operations(type-safeICollection)

		public int Count
		{
			get
			{ return m_count; }
		}

		public void CopyTo(Coordinate[] array)
		{
			this.CopyTo(array, 0);
		}

		public void CopyTo(Coordinate[] array, int start)
		{
			if (m_count > array.GetUpperBound(0)+1-start)
				throw new System.ArgumentException("Destination array was not long enough.");

			Array.Copy(m_array, 0, array, start, m_count); 
		}

		#endregion

		#region Operations (type-safe IList)

		public Coordinate this[int index]
		{
			get
			{
				ValidateIndex(index); // throws
				return m_array[index]; 
			}
			set
			{
				ValidateIndex(index); // throws

				++m_version; 
				m_array[index] = value; 
			}
		}

		/// <summary>
		/// Adds a new coordinate to this set of coordinates.
		/// </summary>
		/// <remarks>Successive repeated coordinates are allowed.</remarks>
		/// <param name="item">The coordinate to be added to the set.</param>
		/// <returns>The index of the added Coordinate in the collection</returns>
		public int Add(Coordinate item)
		{
			if (NeedsGrowth())
				Grow();

			++m_version;
			m_array[m_count] = item;

			return m_count++;
		}

		/// <summary>
		/// Adds a new coordinate to this set of coordinates.
		/// </summary>
		/// <param name="item">The coordinate to be added to the set.</param>
		/// <param name="allowRepeated">A flag used to determine if successive repeat coordinates will be added to the collection.</param>
		/// <returns>The index of the added Coordinate in the collection.  Returns -1 if the add was unsuccesful</returns>
		public int Add(Coordinate item, bool allowRepeated)
		{
			if (!allowRepeated)
			{
				if (m_array[m_count - 1] == item)
				{
					return -1;
				}
			}
			return this.Add(item);
		}

		public void Clear()
		{
			++m_version;
			m_array = new Coordinate[DefaultMinimumCapacity];
			m_count = 0;
		}

		public bool Contains(Coordinate item)
		{
			return ((IndexOf(item) == -1)?false:true);
		}

		public int IndexOf(Coordinate item)
		{
			for (int i=0; i < m_count; ++i)
				if (m_array[i].Equals(item))
					return i;
			return -1;
		}

		public void Insert(int position, Coordinate item)
		{
			ValidateIndex(position,true); // throws

			if (NeedsGrowth())
				Grow();

			++m_version;
			Array.Copy(m_array, position, m_array, position+1, m_count-position);

			m_array[position] = item;
			m_count++;
		}

		public void Remove(Coordinate item)
		{
			int index = IndexOf(item);
			if (index < 0)
				throw new System.ArgumentException("Cannot remove the specified item because it was not found in the specified Collection.");

			RemoveAt(index);
		}

		public void RemoveAt(int index)
		{
			ValidateIndex(index); // throws

			++m_version;
			m_count--;
			Array.Copy(m_array, index+1, m_array, index, m_count-index);

			if (NeedsTrimming())
				Trim();
		}
		#endregion

		#region Operations (type-safe IEnumerable)

		public Enumerator GetEnumerator()
		{
			return new Enumerator(this);
		}
		#endregion
	
		#region Operations (type-safe ICloneable)

		public Coordinates Clone()
		{
			Coordinates tc = new Coordinates();
			tc.AddRange(this);
			tc.Capacity = this.m_array.Length;
			tc.m_version = this.m_version;
			return tc;
		}
		#endregion

		#region ArrayList Features

		public int Capacity
		{
			get
			{ return m_array.Length; }
			set
			{
				if (value < m_count) value = m_count;
				if (value < DefaultMinimumCapacity) value = DefaultMinimumCapacity;

				if (m_array.Length == value) return;

				++m_version;

				Coordinate[] temp = new Coordinate[value];
				Array.Copy(m_array, 0, temp, 0, m_count); 
				m_array = temp;
			}
		}

		public void AddRange(Coordinates collection)
		{
			++m_version;

			Capacity += collection.Count;
			Array.Copy(collection.m_array, 0, this.m_array, m_count, collection.m_count);
			m_count += collection.Count;
		}

		public void AddRange(Coordinate[] array)
		{
			++m_version;

			Capacity += array.Length;
			Array.Copy(array, 0, this.m_array, m_count, array.Length);
			m_count += array.Length;
		}
		public void Reverse()
		{
			Array.Reverse(m_array);
		}

		public void Reverse(int index,int count)
		{
			Array.Reverse(m_array,index,count);
		}

		#endregion

		#region Implementation (helpers)

		private void ValidateIndex(int index)
		{
			ValidateIndex(index,false);
		}

		private void ValidateIndex(int index, bool allowEqualEnd)
		{
			int max = (allowEqualEnd)?(m_count):(m_count-1);
			if (index < 0 || index > max)
				throw new System.ArgumentOutOfRangeException("Index was out of range.  Must be non-negative and less than the size of the collection.", (object)index, "Specified argument was out of the range of valid values.");
		}

		private bool NeedsGrowth()
		{
			return (m_count >= Capacity);
		}

		private void Grow()
		{
			if (NeedsGrowth())
				Capacity = m_count*2;
		}

		private bool NeedsTrimming()
		{
			return (m_count <= Capacity/2);
		}

		private void Trim()
		{
			if (NeedsTrimming())
				Capacity = m_count;
		}

		#endregion

		#region Implementation (ICollection)

		bool ICollection.IsSynchronized
		{
			get
			{ return m_array.IsSynchronized; }
		}

		object ICollection.SyncRoot
		{
			get
			{ return m_array.SyncRoot; }
		}

		void ICollection.CopyTo(Array array, int start)
		{
			this.CopyTo((Coordinate[])array, start);
		}
		#endregion

		#region Implementation (IList)

		bool IList.IsFixedSize
		{
			get
			{ return false; }
		}

		bool IList.IsReadOnly
		{
			get
			{ return false; }
		}

		/// <summary>
		/// Represents the Coordinate object entry at the specific index
		/// </summary>
		object IList.this[int index]
		{
			get
			{ return (object)this[index]; }
			set
			{ this[index] = (Coordinate)value; }
		}

		int IList.Add(object item)
		{
			return this.Add((Coordinate)item);
		}

		bool IList.Contains(object item)
		{
			return this.Contains((Coordinate)item);
		}

		int IList.IndexOf(object item)
		{
			return this.IndexOf((Coordinate)item);
		}

		void IList.Insert(int position, object item)
		{
			this.Insert(position, (Coordinate)item);
		}

		void IList.Remove(object item)
		{
			this.Remove((Coordinate)item);
		}

		#endregion

		#region Implementation (IEnumerable)

		IEnumerator IEnumerable.GetEnumerator()
		{
			return (IEnumerator)(this.GetEnumerator());
		}

		#endregion

		#region Implementation (ICloneable)

		object ICloneable.Clone()
		{
			return (object)(this.Clone());
		}

		#endregion

		#region JTS
		public Coordinates ReverseCoordinateOrder()
		{
			Coordinates coordinates = new Coordinates();
			for(int i = mcount - 1; i > -1; i--)
			{
				coordinates.Add(this[i]);
			}
			return coordinates;
		}
		#endregion

		#region Nested enumerator class

		public class Enumerator : IEnumerator
		{
			private Coordinates m_collection;
			private int m_index;
			private int m_version;

			#region Construction

			internal Enumerator(Coordinates tc)
			{
				m_collection = tc;
				m_index = -1;
				m_version = tc.m_version;
			}
			#endregion

			#region Operations (type-safe IEnumerator)

			public Coordinate Current
			{
				get
				{ return m_collection[m_index]; }
			}

			public bool MoveNext()
			{
				if (m_version != m_collection.m_version)
					throw new System.InvalidOperationException("Collection was modified; enumeration operation may not execute.");

				++m_index;
				return (m_index < m_collection.Count)?true:false;
			}

			public void Reset()
			{
				if (m_version != m_collection.m_version)
					throw new System.InvalidOperationException("Collection was modified; enumeration operation may not execute.");

				m_index = -1;
			}
			#endregion

			#region Implementation (IEnumerator)
			object IEnumerator.Current
			{
				get
				{ return (object)(this.Current); }
			}
			#endregion
		}
		#endregion
	}
}