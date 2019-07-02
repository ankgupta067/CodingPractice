using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class GlassFill
	{
		public void Init()
		{
			Console.WriteLine(GlassFillLogic(3, 2, 1));
		}

		private double GlassFillLogic(int k, int i, int j)
		{
			if (j > i)
			{
				return 0;
			}
			double[] arr = new double[((i * (i + 1)) / 2) + 1];
			arr[1] = k;
			for (int row = 1; row <= i; row++)
			{
				for (int col = 1; col <= row; col++)
				{
					var currindex = ((row * (row - 1)) / 2) + col;
					if (arr[currindex] > 1)
					{
						var overflowvalue = arr[currindex] - 1.0;
						arr[currindex] = 1;
						if((row + 1) <= i)
						{
							arr[((row * (row + 1)) / 2) + col] += overflowvalue / 2;
							arr[((row * (row + 1)) / 2) + col + 1] += overflowvalue / 2;
						}
					}
				}
			}
			return arr[((i * (i - 1)) / 2) + j];
		}
	}
}
