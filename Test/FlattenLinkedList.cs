using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class FlattenLinkedList
	{
		public void Init()
		{
			var lllist = new LinkedList<LinkedList<int>>();
			lllist.AddLast(new LinkedList<int>(new List<int> {5,7,8,30 }));
			lllist.AddLast(new LinkedList<int>(new List<int> { 10,20}));
			lllist.AddLast(new LinkedList<int>(new List<int> { 19,22,50 }));
			lllist.AddLast(new LinkedList<int>(new List<int> { 28,35,40,45 }));
			Flatten(lllist);
		}

		private void Flatten(LinkedList<LinkedList<int>> lllist)
		{
			var resultingll = new LinkedList<int>();
			var enumerator = lllist.GetEnumerator();
			enumerator.MoveNext();
			var templl = enumerator.Current;
			if (templl == null)
			{
				return;
			}
			while (enumerator.MoveNext())
			{
				var cll = enumerator.Current;
				while (templl.Count > 0 && cll.Count > 0)
				{
					if (templl.First.Value < cll.First.Value)
					{
						resultingll.AddLast(new LinkedListNode<int>(templl.First.Value));
						templl.RemoveFirst();
					}
					else
					{
						resultingll.AddLast(new LinkedListNode<int>(cll.First.Value));
						cll.RemoveFirst();
					}
				}
				if (templl.Count == 0)
				{
					foreach (var item in cll)
					{
						resultingll.AddLast(item);
					}
				}
				else {
					foreach (var item in templl)
					{
						resultingll.AddLast(item);
					}
				}
				templl = resultingll;
				resultingll = new LinkedList<int>();
			}
			foreach (var item in templl)
			{
				Console.WriteLine(item);
			}
			
		}
	}
}
