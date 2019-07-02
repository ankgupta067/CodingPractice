using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class NQueen
	{
		int count;
		public void Init()
		{
			const int n = 1;
			var arr = new int[n, n];
			findways(n, arr,0);
			Console.WriteLine(count);
		}

		private void findways(int n, int[,] arr, int currj)
		{
			if (currj == n)
			{
				count += 1;
				return;
			}
			for (int i = 0; i < n; i++)
			{
				if (canplace(i,currj,n,arr))
				{
					arr[i, currj] = 1;
					findways(n, arr, currj + 1);
					arr[i, currj] = 0;
				}
			}
		}

		private bool canplace(int i, int currj,int n, int[,] arr)
		{
			int j = 0;
			if (currj == 0)
			{
				return true;
			}
			for (j = currj -1; j >=0; j--)
			{
				if (arr[i,j] == 1)
				{
					return false;
				}
			}
			int k = i -1;
			j = currj - 1;
			while (k >= 0 && j >= 0)
			{
				if (arr[k,j] == 1)
				{
					return false;
				}
				k--;
				j--;
			}
			 k = i + 1;
			 j = currj - 1;
			while (k <= n-1 && j >= 0)
			{
				if (arr[k, j] == 1)
				{
					return false;
				}
				k++;
				j--;
			}
			return true;
		}
	}
}
