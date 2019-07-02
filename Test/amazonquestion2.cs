using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class amazonquestion2
	{
		int bestroute = int.MaxValue;
		public Tuple<bool,int> findbest (int i, int j, int numrows, int numcolumns, int[,] lot, int steps, bool[,] visited){
			if (visited[i,j])
			{
				return new Tuple<bool, int>(false, 0); ;
			}
			if (i >= numrows || i < 0)
			{
				new Tuple<bool, int>(false, 0);
			}
			if (j >= numcolumns || j < 0)
			{
				new Tuple<bool, int>(false, 0);
			}
			if (lot[i,j] == 9)
			{
				return new Tuple<bool, int>(true,0);
			}
			if (lot[i,j] == 0)
			{
				new Tuple<bool, int>(false, 0);
			}
			visited[i, j] = true;
			var result = int.MaxValue;
			var res = findbest(i + 1, j, numrows, numcolumns, lot, steps,visited);
			if ((res.Item1))
			{
				if (res.Item2 + 1 < result)
				{
					result = res.Item2 + 1;
				}
			}
			res = findbest(i - 1, j, numrows, numcolumns, lot, steps,visited);
			if ((res.Item1))
			{
				if (res.Item2 + 1 < result)
				{
					result = res.Item2 + 1;
				}
			}

			res = findbest(i, j+1, numrows, numcolumns, lot, steps, visited);
			if ((res.Item1)){
				if (res.Item2 + 1 < result)
				{
					result = res.Item2 + 1;
				}
			}

			res = findbest(i , j-1, numrows, numcolumns, lot, steps, visited);
			if ((res.Item1))
			{
				if (res.Item2 + 1 < result)
				{
					result = res.Item2 + 1;
				}
			}
			if (result == int.MaxValue)
			{
				return new Tuple<bool, int>(false, int.MaxValue);
			}
			return new Tuple<bool, int>(true,result);
		}
		public int removeObstacle(int numRows, int numColumns, int[,] lot)
		{
		  Console.WriteLine(findbest(0, 0, numRows, numColumns,lot, 0, new bool[numRows, numColumns]));
		}
	}
}
