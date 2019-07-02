using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class ReverseWords
	{
		public void Init()
		{
			Reverse("i.like.this.program.very.much");
		}

		private void Reverse(string s)
		{
			var ll = new LinkedList<char>();
			var sb = new StringBuilder();
			for (int i = s.Length -1; i >=0; i--)
			{
				var c = s[i];
				if (c != '.')
				{
					ll.AddFirst(c);
				}
				else
				{
					foreach (var item in ll)
					{
						sb.Append(item);
					}
					
					sb.Append('.');
					ll.Clear();
				}
			}
			if (ll.Count > 0)
			{
				foreach (var item in ll)
				{
					sb.Append(item);
				}
			}
			Console.WriteLine(sb.ToString());
		}
	}
}
