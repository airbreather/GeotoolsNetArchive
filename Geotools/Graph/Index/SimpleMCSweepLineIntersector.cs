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

#region Using
using System;
using System.Collections;
#endregion

namespace Geotools.Graph.Index
{
	/// <summary>
	/// Finds all intersections in one or two sets of edges,using an x-axis sweepline algorithm in conjunction with Monotone Chains.
	/// </summary>
	/// <remarks>
	/// While still O(n^2) in the worst case, this algorithm
	/// drastically improves the average-case time.
	/// The use of MonotoneChains as the items in the index
	/// seems to offer an improvement in performance over a sweep-line alone.
	/// </remarks>
	internal class SimpleMCSweepLineIntersector : EdgeSetIntersector
	{
		ArrayList _events = new ArrayList();

		// statistics information
		int _nOverlaps;


		#region Constructors
		/// <summary>
		/// Initializes a new instance of the SimpleMCSweepLineIntersector class.
		/// </summary>
		public SimpleMCSweepLineIntersector()
		{
		}
		#endregion

		#region Properties
		#endregion

		#region Methods
		/// <summary>
		/// Computes all self-intersections between edges in a set of edges.
		/// </summary>
		/// <param name="edges">Array of edges from which to compute self-intersections.</param>
		/// <param name="si">SegmentIntersector object.</param>
		public override void ComputeIntersections( ArrayList edges, SegmentIntersector si, bool testAllSegments )
		{
			if (testAllSegments)
			{
				Add(edges, null);
			}
			else
			{
				Add(edges);
			}
			ComputeIntersections(si);
		}

		/// <summary>
		/// Computes all mutual intersections between two sets of edges.
		/// </summary>
		/// <param name="edges0"></param>
		/// <param name="edges1"></param>
		/// <param name="si"></param>
		public override void ComputeIntersections(ArrayList edges0, ArrayList edges1, SegmentIntersector si)
		{
			Add(edges0, edges0);
			Add(edges1, edges1);
			ComputeIntersections(si);
		}	

		
		private void Add(ArrayList edges)
		{
			for(int i=0; i<edges.Count;i++)
			{
				Edge edge = (Edge) edges[i];
				// edge is its own group
				Add(edge, edge);
			}
		}
		private void Add(ArrayList edges, object edgeSet)
		{
			for(int i=0; i<edges.Count;i++)
			{
				Edge edge = (Edge) edges[i];
				Add(edge, edgeSet);
			}
		}

		private void Add(Edge edge, object edgeSet)
		{
			MonotoneChainEdge mce = edge.GetMonotoneChainEdge();
			int[] startIndex = mce.StartIndex;
			for (int i = 0; i < startIndex.Length - 1; i++) 
			{
				MonotoneChain mc = new MonotoneChain(mce, i);
				SweepLineEvent insertEvent = new SweepLineEvent(edgeSet, mce.GetMinX(i), null, mc);
				_events.Add(insertEvent);
				_events.Add(new SweepLineEvent(edgeSet, mce.GetMaxX(i), insertEvent, mc));
			}
		} // private void Add(Edge edge, int geomIndex)

		private void ComputeIntersections(SegmentIntersector si)
		{
			_nOverlaps = 0;
			PrepareEvents();

			for (int i = 0; i < _events.Count; i++ )
			{
				SweepLineEvent ev = (SweepLineEvent) _events[i];
				if (ev.IsInsert) 
				{
					ProcessOverlaps(i, ev.DeleteEventIndex, ev, si);
				}
			}
		} // private void ComputeIntersections(SegmentIntersector si, bool doMutualOnly)

		/// <summary>
		/// Because Delete events have a link to their corresponding Insert event,
		/// it is possible to compute exactly the range of events which must be
		/// compared to a given Insert event object.
		/// </summary>
		private void PrepareEvents()
		{
			_events.Sort();
			//TODO:remove this bubble sort!!!! AWC, LAK, RAB - we should find this!!!!!!
			//**************************************************************************8

						// remove this bubble sort.

			//************************************************************************
			/*int count=0;
			for (int a=0;a<_events.Count;a++)
			{
				for (int b=0;b<_events.Count-1;b++)
				{
					SweepLineEvent ev1 = (SweepLineEvent) _events[b];
					SweepLineEvent ev2 = (SweepLineEvent) _events[b+1];
					if (ev1.CompareTo(ev2)==1)
					{
						SweepLineEvent temp = ev1;
						_events[b]=ev2;
						_events[b+1]=temp;    		
						count++;
					}
				}
			}
			*/
			for (int i = 0; i < _events.Count; i++ )
			{
				SweepLineEvent ev = (SweepLineEvent) _events[i];
				if ( ev.IsDelete ) 
				{
					ev.InsertEvent.DeleteEventIndex = i;
				}
			}
		} // private void PrepareEvents()

		private void ProcessOverlaps(int start, int end, SweepLineEvent  ev0, SegmentIntersector si)
		{
			MonotoneChain mc0 = (MonotoneChain) ev0.Object;
			/**
			 * Since we might need to test for self-intersections,
			 * include current insert event object in list of event objects to test.
			 * Last index can be skipped, because it must be a Delete event.
			 */
			for (int i = start; i < end; i++ ) 
			{
				SweepLineEvent ev1 = (SweepLineEvent) _events[i];
				if (ev1.IsInsert) 
				{
					MonotoneChain mc1 = (MonotoneChain) ev1.Object;
					// don't compare edges in same group
					// null group indicates that edges should be compared
					if (ev0.EdgeSet == null || (ev0.EdgeSet != ev1.EdgeSet)) 
					{
						mc0.ComputeIntersections(mc1, si);
						_nOverlaps++;
					}
				}
			}

		} // private void ProcessOverlaps(int start, int end, MonotoneChain mc0, SegmentIntersector si, bool doMutualOnly)

		#endregion

	}
}
