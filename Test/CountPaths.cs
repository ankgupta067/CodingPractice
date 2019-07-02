using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class CountPaths
	{
		public void Init()
		{
			var rows = 2;
			var columns = 8;
			Console.WriteLine(TotalPaths(0, 0, rows - 1, columns - 1));
		}

		private int TotalPaths(int sx, int sy, int dx, int dy)
		{
			if (sx == dx && sy == dy)
			{
				return 1;
			}
			if (sx > dx || sy > dy)
			{
				return 0;
			}
			return TotalPaths(sx + 1, sy, dx, dy) + TotalPaths(sx, sy + 1, dx, dy);
		}
	}
}
