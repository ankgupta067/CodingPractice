using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class RottenOranges
	{
		public void Init()
		{
			int rows = 3;
			int columns = 4;
			var input = new int[,] { {2, 1, 0, 2, 1},
					 {0, 0, 1, 2, 1},
					 {1, 0, 0, 2, 1}};
			Console.WriteLine(FindRottenOranges(input, rows, columns));
			
		}

		private int FindRottenOranges(int[,] input, int rows, int columns)
		{
			int prev = 2;
			int pass = -1;
			int curr = -1;
			while (prev != -1)
			{
				pass += 1;
				for (int i = 0; i < rows; i++)
				{
					for (int j = 0; j < columns; j++)
					{
						if (input[i, j] == prev)
						{
							if (i + 1 < rows)
							{
								if (input[i + 1, j] == 1)
								{
									curr = prev + 1;
									input[i + 1, j] = curr;
								}
							}
							if (i - 1 >= 0)
							{
								if (input[i - 1, j] == 1)
								{
									curr = prev + 1;
									input[i - 1, j] = curr;
								}
							}
							if (j + 1 < columns)
							{
								if (input[i, j + 1] == 1)
								{
									curr = prev + 1;
									input[i, j + 1] = curr;
								}
							}
							if (j - 1 >= 0)
							{
								if (input[i, j - 1] == 1)
								{
									curr = prev + 1;
									input[i, j - 1] = curr;
								}
							}
						}
					}
				}
				prev = curr;
				curr = -1;
			}

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					if (input[i,j] == 1)
					{
						return -1;
					}
				}
			}
			return pass;
		}
	}
}
