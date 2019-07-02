using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class VerticalOrder
	{
		public void Init()
		{
			var inputtree = new BTreeNode
			{
				Data = 1,
				LeftNode = new BTreeNode
				{
					Data = 2,
					LeftNode = new BTreeNode
					{
						Data = 4
					},
					RightNode = new BTreeNode
					{
						Data = 5
					}
				},
				RightNode = new BTreeNode
				{
					Data = 3,
					LeftNode = new BTreeNode
					{
						Data = 6
					},
					RightNode = new BTreeNode
					{
						Data = 7
					}					
				}
			};
			var mem = new SortedDictionary<int, List<int>>();
			PrintVerticalOrder(inputtree, mem, 0);
			foreach (var item in mem)
			{
				foreach (var value in item.Value)
				{
					Console.WriteLine(value);
				}
			}
		}

		private void PrintVerticalOrder(BTreeNode inputnode, 
			SortedDictionary<int,List<int>> mem, int key)
		{
			if (inputnode == null)
			{
				return;
			}
			if (mem.ContainsKey(key))
			{
				mem[key].Add(inputnode.Data);
			}
			else
			{
				mem[key] = new List<int>();
				mem[key].Add(inputnode.Data);
			}
			PrintVerticalOrder(inputnode.LeftNode, mem, key - 1);
			PrintVerticalOrder(inputnode.RightNode, mem, key + 1);
		}
	}
}
