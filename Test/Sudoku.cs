using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class Sudoku
	{
		public void Init()
		{
			const int n = 9;
			var input = new int[n,n]
			{
				{3,0,6,5,0,8,4,0,0 },
				{5,2,0,0,0,0,0,0,0 },
				{0,8,7,0,0,0,0,3,1 },
				{0,0,3,0,1,0,0,8,0 },
				{9,0,0,8,6,3,0,0,5 },
				{0,5,0,0,9,0,6,0,0 },
				{1,3,0,0,0,0,2,5,0 },
				{0,0,0,0,0,0,0,7,4 },
				{0,0,5,2,0,6,3,0,0 }
			};
			if(solvesudoku(input, 0, 0, 9))
			{
				for (int i = 0; i < n; i++)
				{
					for (int j = 0; j < n; j++)
					{
						Console.Write(input[i, j] + ' ');
					}
					Console.WriteLine();
				}
			}
		}

		public bool solvesudoku(int[,] arr, int i, int j,int n)
		{
			if (i >= n -1 && j >= n-1)
			{
				return true;
			}

			if (arr[i,j] == 0)
			{
				for (int k = 1;k < 10; k++)
				{
					if (canfit(k,i,j,arr,n))
					{
						arr[i, j] = k;
						Tuple<int, int> tup = findnextij(i, j, n);
						if (solvesudoku(arr,tup.Item1,tup.Item2,n))
						{
							return true;
						}
						// backtrack
						arr[i, j] = 0;
					}
				}
			}
			else
			{
				Tuple<int, int> tup = findnextij(i, j, n);
				if (solvesudoku(arr, tup.Item1, tup.Item2, n))
				{
					return true;
				}
			}
			return false;
		}

		private Tuple<int, int> findnextij(int i, int j, int n)
		{
			if (j == n - 1)
			{
				return new Tuple<int, int>(i + 1, 0);
			}
			return new Tuple<int, int>(i, j + 1);

		}

		private bool canfit(int k, int i, int j, int[,] arr, int n)
		{
			for (int l = 0; l < n; l++)
			{
				if (arr[i,l] == k)
				{
					return false;
				}
				if (arr[l,j] == k)
				{
					return false;
				}
			}
			int si = (i / 3) * 3;
			int sj = (j / 3) * 3;
			for (int l = si; l < si + 3; l++)
			{
				for (int m = sj; m < sj + 3; m++)
				{
					if (arr[l,m] == k)
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}
