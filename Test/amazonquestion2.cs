using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class amazonquestion2
	{
		public void Init()
		{
			var lot = new int[,]
			{
				{ 1,0,1,0 },
				{1,1,1,9 },
				{0,1,1,1 },
				{0,0,0,0 }
			};
			removeObstacle(4, 4, lot);

		}

		int bestroute = int.MaxValue;
		public bool findbest (int i, int j, int numrows, int numcolumns, int[,] lot, int steps, bool[,] visited,int count){
			
			if (i >= numrows || i < 0)
			{
				return false;
			}
			if (j >= numcolumns || j < 0)
			{
				return false;
			}
			if (visited[i, j])
			{
				return false;
			}
			if (lot[i,j] == 9)
			{
				if (count < bestroute)
				{
					bestroute = count;
				}
				return true;
			}
			if (lot[i,j] == 0)
			{
				return false;
			}
			visited[i, j] = true;
			var o1 = findbest(i + 1, j, numrows, numcolumns, lot, steps, visited, count + 1);
			var o2 = findbest(i - 1, j, numrows, numcolumns, lot, steps, visited, count + 1);
			var o3 = findbest(i, j + 1, numrows, numcolumns, lot, steps, visited, count + 1);
			var o4 =  findbest(i, j - 1, numrows, numcolumns, lot, steps, visited, count + 1);
			if (o1 || o2 || o3 || o4){			
			visited[i, j] = false;
				return true;
			}
			visited[i, j] = false;
			return false;
		}
		public void removeObstacle(int numRows, int numColumns, int[,] lot)
		{
		 if(findbest(0, 0, numRows, numColumns,lot, 0, new bool[numRows, numColumns],1)){
				Console.WriteLine(bestroute);
			}
		}
	}
}
