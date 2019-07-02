using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class Urlify
	{
		public void Init()
		{
			UrlifyString("I am Ankush    ");
		}

		private void UrlifyString(string v)
		{
			var input = v.ToCharArray();
			int i = input.Length - 1;
			while (char.IsWhiteSpace(input[i]))
			{
				i--;
			}
			var k = input.Length - 1;
			for (int j = i; j >=0;j--)
			{
				if (char.IsWhiteSpace(input[j]))
				{
					input[k] = '0';
					input[k-1] = '2';
					input[k - 2] = '%';
					k = k - 3;
				}
				else
				{
					input[k] = input[j];
					k -= 1;
				}
			}
			Console.WriteLine(new string(input));
		}
	}
}
