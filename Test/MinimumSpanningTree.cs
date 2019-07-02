using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class MinimumSpanningTree
	{
		private class Vertice
		{
			public int data { get; set; }
			public int Parent { get; set; }
			public int rank { get; set; }
		}
		private class Edge : IComparable
		{
			public int StartVertex { get; set; }
			public int EndVertex { get; set; }
			public int Weight{ get; set; }

			public int CompareTo(object obj)
			{
				if (obj is Edge ed)
				{
					if (this.Weight < ed.Weight)
					{
						return -1;
					}
					else if (Weight == ed.Weight)
					{
						return 0;
					}
					return 1;
				}
				throw new ArgumentException("incorrect type");
			}
		}

		List<Vertice> vertices = new List<Vertice>();
		public void Init()
		{
			var edges = new List<Edge>() {
				new Edge{StartVertex = 7, EndVertex = 6, Weight=1},
				new Edge{StartVertex = 8, EndVertex = 2, Weight=2},
				new Edge{StartVertex = 6, EndVertex = 5, Weight=2},
				new Edge{StartVertex = 0, EndVertex = 1, Weight=4},
				new Edge{StartVertex = 2, EndVertex = 5, Weight=4},
				new Edge{StartVertex = 8, EndVertex = 6, Weight=6},
				new Edge{StartVertex = 2, EndVertex = 3, Weight=7},
				new Edge{StartVertex = 7, EndVertex = 8, Weight=7},
				new Edge{StartVertex = 0, EndVertex = 7, Weight=8},
				new Edge{StartVertex = 1, EndVertex = 2, Weight=8},
				new Edge{StartVertex = 3, EndVertex = 4, Weight=9},
				new Edge{StartVertex = 5, EndVertex = 4, Weight=10},
				new Edge{StartVertex = 1, EndVertex = 7, Weight=11},
				new Edge{StartVertex = 3, EndVertex = 5, Weight=14}
			};
			for (int i = 0; i < 9; i++)
			{
				vertices.Add(
					new Vertice { data = i, Parent = i, rank = 0 }
				);
			}
			Console.WriteLine(findspanningtree(edges, vertices.Count));
		}

		private int findspanningtree(List<Edge> edges, int vertices)
		{
			edges.Sort();
			bool[] visited = new bool[vertices];
			var result = 0;
			var i = 0;
			int count = 0;
			while (count < vertices - 1 && i < edges.Count)
			{
				var edge = edges[i];
				if (!iscycle(edge))
				{					
					result += edge.Weight;
					count += 1;
				}
				i += 1;
			}
			return result;
		}

		private bool iscycle(Edge edge)
		{
			var pars = findparent(edge.StartVertex);
			var pard = findparent(edge.EndVertex);
			if (pars.data == pard.data)
			{
				return true;
			}
			Union(pars, pard);
			return false;
		}

		private void Union(Vertice pars, Vertice pard)
		{
			if (pars.rank > pard.rank)
			{
				pard.Parent = pars.data;
			}
			else if (pard.rank > pars.rank)
			{
				pars.Parent = pard.data;
			}
			else
			{
				pard.Parent = pars.data;
				pars.rank++;
			}
		}

		private Vertice findparent(int vertex)
		{
			var vertice = vertices[vertex];
			return findparent(vertice);
		}

		private Vertice findparent(Vertice vertice)
		{
			while (vertice.Parent != vertice.data)
			{
				return findparent(vertice.Parent);
			}
			return vertice;
		}
	}
}
