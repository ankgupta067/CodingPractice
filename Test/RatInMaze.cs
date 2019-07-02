using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class RatInMaze
	{
		List<string> solutions = new List<string>();
		public void Init()
		{
			const int n = 4;
			var arr = new int[n, n] { { 1, 0, 0, 0 }, { 1, 1, 0, 1 }, { 1, 1, 0, 0 }, { 0, 1, 1, 1 } };
			RatInMazeSolutions(arr, n, 0, 0,new StringBuilder());
			solutions.ForEach(x => Console.WriteLine(x));
		}

		private void RatInMazeSolutions(int[,] arr, int n, int i, int j, StringBuilder result)
		{
			if (i == n-1 && j == n-1 )
			{
				solutions.Add(result.ToString());
				return;
			}
			if (canmove(i+1,j,arr,n))
			{
				result.Append('D');
				arr[i + 1, j] = 2;
				RatInMazeSolutions(arr, n, i + 1, j, result);
				arr[i + 1, j] = 1;
				result.Remove(result.Length - 1, 1);
			}
			if (canmove(i, j-1, arr, n))
			{
				result.Append('L');
				arr[i, j-1] = 2;
				RatInMazeSolutions(arr, n, i, j-1, result);
				arr[i, j - 1] = 1;
				result.Remove(result.Length - 1, 1);
			}
			if (canmove(i, j + 1, arr, n))
			{
				result.Append('R');
				arr[i, j+1] = 2;
				RatInMazeSolutions(arr, n, i, j + 1, result);
				arr[i, j+1] = 1;
				result.Remove(result.Length - 1, 1);
			}
			if (canmove(i-1, j, arr, n))
			{
				result.Append('U');
				arr[i-1, j] = 2;
				RatInMazeSolutions(arr, n, i - 1, j, result);
				arr[i - 1, j] = 1;
				result.Remove(result.Length - 1, 1);
			}

		}

		private bool canmove(int i, int j, int[,] arr, int n)
		{
			if ((i >= 0 && i < n) && (j >= 0 && j < n))
			{
				if(arr[i, j] == 1)
				{
					return true;
				}
			}
			return false;
		}
	}
}
