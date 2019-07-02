using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class NBinaryWithoutConecutive1
	{
		int count = 0;
		public void Init()
		{
			int n = 10;
			findcount(n);
			//Console.WriteLine(count);
		}

		private void FindCount(int n, int lastvalue)
		{
			if (n == 0)
			{
				count += 1;
				return;
			}
			if (lastvalue == 0)
			{
				FindCount(n - 1, 1);				
			}
			FindCount(n - 1, 0);
		}

		private void findcount(int n)
		{
			int endwith0 = 1; int endwith1 = 1;
			for (int i = 1; i < n; i++)
			{
				var preendwith0 = endwith0;
				endwith0 = endwith1 + endwith0;
				endwith1 = preendwith0;

			}

			Console.WriteLine(endwith0 + endwith1);
		}
	}
}
