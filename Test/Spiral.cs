using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	public class Spiral
	{
		public void Init()
		{
			int[,] a = { {1, 2, 3, 4},
						 {7, 8, 9, 10},
						 {13, 14, 15, 16},
						{17,18,19,20 }
			  };
			DoSpiral(a, 4,4);
		}

		public void DoSpiral(int[,] a, int currcol, int currrow)
		{
			int i = 0;
			int j = currcol - 1;
			int lr = currrow - 1;
			int lc = 0;
			while ((i <= lr) && (j >= lc))
			{
				int k = i;
				while (k <= j)
				{
					Console.WriteLine(a[i, k]);
					k++;
				}
				i++;
				k = i;
				while (k <= lr)
				{
					Console.WriteLine(a[k, j]);
					k++;
				}
				j--;
				k = j;
				while (k >= lc && i <= lr)
				{
					Console.WriteLine(a[lr, k]);
					k--;
				}
				lr--;
				k = lr;
				while (k >= i && j >= lc)
				{
					Console.WriteLine(a[k, lc]);
					k--;
				}
				lc++;
			}
		}
	}
}
