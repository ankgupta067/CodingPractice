using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class FirstNonOccuringElementInStream
	{
		public void Init()
		{
			var input = "geeksforgeeksandgeeksquizfor";
			FindFirstNonOccuringElement(input);
		}

		private void FindFirstNonOccuringElement(string input)
		{
			LinkedList<char> ll = new LinkedList<char>();
			LinkedListNode<char>[] allreadyPresent = new LinkedListNode<char>[256];
			bool[] removed = new bool[256];
			foreach (var item in input)
			{
				if (allreadyPresent[item] == null)
				{
					if (!removed[item])
					{
							ll.AddLast(item);
							allreadyPresent[item] = ll.Last;
							Console.WriteLine(ll.First.Value);
					}
					else
					{
						if (ll.Count > 0)
						{
							Console.WriteLine(ll.First.Value);
						}
						else
						{
							Console.WriteLine(-1);
						}
					}
				}
				else
				{
					if (!removed[item])
					{
						ll.Remove(allreadyPresent[item]);
						removed[item] = true;
					}
					if (ll.Count > 0)
					{
						Console.WriteLine(ll.First.Value);
					}
					else
					{
						Console.WriteLine(-1);
					}
				}
			}
		}
	}
}
