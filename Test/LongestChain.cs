using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class LongestChain
	{
		public void Init()
		{
			var pairs = new List<Tuple<int, int>>
			{
				new Tuple<int, int>(5,24),
				new Tuple<int, int>(39,60),
				new Tuple<int, int>(15,28),
				new Tuple<int, int>(27,40),
				new Tuple<int, int>(50,90),
			};
			Console.WriteLine(GetMaxLen(pairs, 0, 0));
		}

		private int GetMaxLen(List<Tuple<int,int>> pairs,int index,int lastMaxvalue)
		{
			if (index == pairs.Count)
			{
				return 0;
			}
			int opt1 = 0;
			if (pairs[index].Item1 > lastMaxvalue)
			{
				opt1 = 1 + GetMaxLen(pairs, index + 1, pairs[index].Item2);
			}
			var opt2 = GetMaxLen(pairs, index + 1, lastMaxvalue);
			return Math.Max(opt1, opt2);
		}
	}
}
