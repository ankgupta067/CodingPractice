using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class RecursiveDuplicate
	{
		public void Init()
		{
			RemoveDuplicate("acaaabbbacdddd");
		}

		private void RemoveDuplicate(string input)
		{
			int startindex = 0;
			StringBuilder newstring = new StringBuilder();
			for (int i = 1; i < input.Length; i++)
			{
				if (input[i-1] != input[i])
				{
					if (startindex == i-1)
					{
						newstring.Append(input[startindex]);
					}
					startindex = i;
				}
			}
			if (startindex == input.Length - 1)
			{
				newstring.Append(input[startindex]);
			}
			Console.WriteLine(newstring);
		}
	}
}
