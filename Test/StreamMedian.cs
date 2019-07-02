using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class StreamMedian
	{
		public void Init()
		{
			var leftheap = new MaxHeap();
			var rightheap = new MinHeap();
			var items = new int[] { 5, 15, 1, 3 };
			int median = -1;
			foreach (var item in items)
			{
				var diff = leftheap.Count - rightheap.Count;
				switch (diff)
				{
					case 0:
						var leftroot = leftheap.GetRoot();
						var rightroot = rightheap.GetRoot();
						if (item > leftroot)
						{
							rightheap.addItem(item);
							median = rightheap.GetRoot();
						}
						else
						{
							leftheap.addItem(item);
							median = leftheap.GetRoot();
						}
						break;
					case 1:
						var leftroot1 = leftheap.GetRoot();
						if (item > leftroot1)
						{
							rightheap.addItem(item);
							median = (leftroot1 + rightheap.GetRoot())/2;
						}
						else
						{
							leftheap.RemoveRoot();
							leftheap.addItem(item);
							rightheap.addItem(leftroot1);
							median = (leftheap.GetRoot() + rightheap.GetRoot()) / 2;
						}
						break;
					case -1:
						var rightroot1 = rightheap.GetRoot();
						if (item < rightroot1)
						{
							leftheap.addItem(item);
							median = (rightroot1 + leftheap.GetRoot()) / 2;
						}
						else
						{
							rightheap.RemoveRoot();
							rightheap.addItem(item);
							leftheap.addItem(rightroot1);
							median = (leftheap.GetRoot() + rightheap.GetRoot()) / 2;
						}
						break;
					default:
						break;
				}
				Console.WriteLine(median);
			}
			
		}
	}
}
