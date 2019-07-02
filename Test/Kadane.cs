using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class Kadane
	{
		public void Init()
		{
			KadaneAlgo(new int[] { -2,-1, -3, -4 });
		}

		private void KadaneAlgo(int[] arr)
		{
			int max_yet = arr[0], sum_yet = arr[0];
			int start_index = 0; int end_index = -1;
			for (int i = 1; i < arr.Length; i++)
			{
				int tempsum = sum_yet + arr[i];
				if (tempsum < arr[i])
				{
					sum_yet = arr[i];
					start_index = i;
				}
				else
				{
					sum_yet = tempsum;
				}

				if (sum_yet > max_yet)
				{
					max_yet = sum_yet;
					end_index = i;
				}
			}
			Console.WriteLine($"max sum {max_yet}");
			Console.Write($"from : {start_index} end: {end_index}");
		}
	}
}
