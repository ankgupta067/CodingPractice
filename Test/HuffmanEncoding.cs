using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class HuffmanEncoding
	{
		public void Init()
		{

		}

		public void BuidHuffmanTree(string input)
		{
			var mh =new MinHeap();
			mh.BuildMinHeap(input);

		}
		private class MinHeap
		{
			int currentcount = 0;
			KeyValuePair<char, int>[] minheap;
			public void BuildMinHeap(string input)
			{
				Dictionary<char, int> cf = new Dictionary<char, int>();
				foreach (var c in input)
				{
					cf[c] += 1;
				}
				minheap = new KeyValuePair<char, int>[cf.Keys.Count + 1];
				foreach (var kv in cf)
				{
					AddToHeap(kv);
				}

			}

			public void AddToHeap(KeyValuePair<char, int> kv)
			{
				if (currentcount == 0)
				{
					minheap[currentcount + 1] = kv;
				}
				else
				{
					minheap[currentcount + 1] = kv;
					currentcount += 1;
					heapify();
				}

			}

			public KeyValuePair<char,int> GetRoot()
			{
				var temp = minheap[currentcount];
				minheap[currentcount] = minheap[1];
				minheap[1] = temp;
				currentcount = currentcount -= 1;
				var currindex = 1;
				while (currindex < currentcount)
				{
					int indextoconsider = 0;
					if (currindex * 2 == currentcount)
					{
						indextoconsider = currentcount;
					}
					else
					{
						if (minheap[currindex * 2].Value < minheap[(currindex * 2) + 1].Value)
						{
							indextoconsider = currindex * 2;
						}
						else
						{
							indextoconsider = (currindex* 2) + 1;
						}
					}
					if (minheap[currindex].Value > minheap[indextoconsider].Value)
					{
						var temp1 = minheap[currindex];
						minheap[currindex] = minheap[indextoconsider];
						minheap[indextoconsider] = temp1;
					}
				}
				return minheap[currentcount + 1];
			}
			private void heapify()
			{
				var currindex = currentcount;
				while (currindex > 1)
				{
					int indextoconsider = 0;
					if (currindex / 2 == 1)
					{
						indextoconsider = currindex / 2;
					}
					else 
					{
						if (minheap[currindex / 2].Value > minheap[(currindex / 2) - 1].Value)
						{
							indextoconsider = currindex / 2;
						}
						else
						{
							indextoconsider = (currindex / 2) + 1;
						}
					}
					if (minheap[currindex].Value < minheap[indextoconsider].Value)
					{
						var temp = minheap[currindex];
						minheap[currindex] = minheap[indextoconsider];
						minheap[indextoconsider] = minheap[currindex];
					}
				}
			}

			private void swap(int currindex, int v)
			{
				throw new NotImplementedException();
			}
		}
	}
}
