using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class SpecialKeyboard
	{
		public void Init()
		{
			Console.WriteLine(KeyboardCount(11));
		}


		public int KeyboardCount(int n)
		{
			if (n <= 3)
			{
				return n;
			}
			return getin(n - 3, 3, 0);
		}

		private int getin(int n, int count, int buffer)
		{
			if (n <= 0)
			{
				return count;
			}
			int c1 = 0;
			int c2 = 0;
			int c3 = 0;
			if (buffer != 0)
			{
				c1 = getin(n - 1, count + buffer, buffer);
			}
			if (n- 3 >= 0)
			{
				c2 = getin(n - 3, count * 2, count);
			}
			if (n-1 >= 0)
			{
				c3 = getin(n - 1, count + 1, buffer);
			}
			return Math.Max(Math.Max(c1, c2), c3);
		}
	}
}
