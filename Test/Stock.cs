using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class Stock
	{
		public void Init()
		{
			var arr = new int[] { 23, 13, 25, 29, 33, 19, 34, 45, 65, 67};
			PrintProfit(arr);
		}

		private void PrintProfit(int[] arr)
		{
			int j = 0;
			int[] mem = new int[arr.Length];
			for (int i = 0; i < arr.Length; i++)
			{
				for (int k = j; k < i; k++)
				{
					var val = arr[i] - arr[k];
					if (val <=0)
					{
						j = i;
						mem[i] = 0;
						break;
					}
					if (val > mem[i])
					{
						mem[i] = val;
					}
				}
			}
			int startindex = 0, endindex=0;
			for (int i = 1; i < mem.Length; i++)
			{
				if (mem[i] == 0)
				{
					endindex = i - 1;
					if (startindex != endindex)
					{
						Console.Write($"({startindex} {endindex}) ");
					}
					startindex = i;
				}			
			}
			if (startindex != arr.Length-1)
			{
				Console.Write($"({startindex} {arr.Length - 1}) ");
			}
		}
	}
}
