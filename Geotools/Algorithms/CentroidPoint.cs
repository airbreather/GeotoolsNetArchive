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

#region Using statements
using System;
using Geotools.Geometries;
#endregion

namespace Geotools.Algorithms
{

	/// <summary>
	/// Computes the centroid of a point geometry.
	/// </summary>
	/// <remarks>
	///  Compute the average of all points.
	/// </remarks>
	public class CentroidPoint
	{
		private int _ptCount = 0;
		private Coordinate _centSum = new Coordinate();

		public CentroidPoint()
		{
		}


		/// <summary>
		/// Adds the point(s) defined by a Geometry to the centroid total.
		/// </summary>
		/// <remarks>
		/// If the geometry is not of dimension 0 it does not contribute to the centroid.
		/// </remarks>
		/// <param name="geom">geom the geometry to add.</param>
		public void Add(Geometry geom)
		{
			if (geom is Point) 
			{
				Add(geom.GetCoordinate());
			}
			else if (geom is GeometryCollection) 
			{
				GeometryCollection gc = (GeometryCollection) geom;
				for (int i = 0; i < gc.GetNumGeometries(); i++) 
				{
					Add(gc[i]);
				}
			}
		}

		/// <summary>
		/// Adds the length defined by an array of coordinates.
		/// </summary>
		/// <param name="pt">pts an array of {@link Coordinate}s</param>
		public void Add(Coordinate pt)
		{
			_ptCount += 1;
			_centSum.X += pt.X;
			_centSum.Y += pt.Y;
		}

		public Coordinate GetCentroid()
		{
			Coordinate cent = new Coordinate();
			cent.X = _centSum.X / _ptCount;
			cent.Y = _centSum.Y / _ptCount;
			return cent;
		}

	}
}