using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class CoinPiles
	{
		public void Init()
		{
			int n = 6;
			int k = 3;
			var intarr = new int[] {1 ,5 ,1 ,2,5, 1};
			Console.WriteLine(Compute(n, k, intarr));
		}

		private int Compute(int n, int k, int[] intarr)
		{
			int minnum = int.MaxValue;
			for (int i = 0; i < n; i++)
			{
				if (intarr[i] < minnum )
				{
					minnum = intarr[i];
				}
			}
			var newminnum = minnum + k;
			var coincount = 0;
			for (int i = 0; i < n; i++)
			{
				if (intarr[i] > newminnum)
				{
					coincount += (intarr[i] - newminnum);
				}
			}
			return coincount;
		}
	}
}
