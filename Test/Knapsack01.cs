using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class Knapsack01
	{
		public void Init()
		{
			var n = 3;
			var maxweight = 50;
			var valueArray = new int[] { 60,100,120};
			var weightarray = new int[] {10,20,30 };
			var mem = new int[n+1, maxweight+1];
			var currentvalue = 0;
			Console.WriteLine(FillKnapSack(0, 0,maxweight,
				currentvalue, mem, valueArray, weightarray));
		}

		private int FillKnapSack(int n, int w, int maxweight, int currentvalue, int[,] mem, int[] valueArray, int[] weightarray)
		{
			if (w >= maxweight || n >= weightarray.Length)
			{
				return currentvalue;
			}
			if (mem[n,w] != 0)
			{
				return mem[n, w];
			}
			if (w + weightarray[n] >  maxweight)
			{
				return FillKnapSack(n + 1, w, maxweight, currentvalue, mem, valueArray, weightarray);
			}

			var result = Math.Max(FillKnapSack(n + 1, w + weightarray[n], maxweight, currentvalue + valueArray[n], mem, valueArray, weightarray),
				FillKnapSack(n + 1, w, maxweight, currentvalue, mem, valueArray, weightarray));
			mem[n, w] = result;
			return result;
		}
	}
}
