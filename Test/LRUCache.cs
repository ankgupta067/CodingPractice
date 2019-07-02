using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class LRUCache
	{
		LinkedList<int> cache = new LinkedList<int>();
		Dictionary<int, LinkedListNode<int>> hash = new Dictionary<int, LinkedListNode<int>>();

		public int PageFaultCount(List<int> pages,int cachelimit)
		{
			var result = 0;
			foreach (var item in pages)
			{
				var node = cache.Find(item);
				if (node == null)
				{
					result += 1;
					if (cache.Count < cachelimit)
					{
						cache.AddFirst(item);
					}
					else
					{
						cache.RemoveLast();
						cache.AddFirst(item);
					}
				}
				else
				{
					if (node.Previous != null)
					{
						cache.Remove(node);
						cache.AddFirst(node);
					}
				}
			}

			return result;
		}

		public void Init()
		{
			var pagelist = new List<int> { 1, 2, 3, 4, 1, 2, 5, 1, 2, 3, 4, 5 };
			Console.WriteLine(PageFaultCount(pagelist, 3));
		}

	}
}
