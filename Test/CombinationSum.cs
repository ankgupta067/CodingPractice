using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class CombinationSum
	{
		public void Init()
		{
			var ia = new int[] { 10, 1, 2, 7, 6, 1, 5 };
			var targetsum = 8;
			Array.Sort(ia);
			bool[,] mem = new bool[ia.Length,targetsum + 1];
			FindCombination(ia,0, targetsum, new List<int>(),mem);
		}

		private void FindCombination(int[] ia,int index, int targetsum, List<int> list,
			bool[,] mem)
		{
			if (mem[index,targetsum])
			{
				return;
			}
			mem[index, targetsum] = true;
			if (targetsum == 0)
			{
				Console.Write("{ ");
				list.ForEach(x => Console.Write(x + " "));
				Console.Write("}");
				Console.WriteLine();
			}

			if (index >= ia.Length || ia[index] > targetsum )
			{
				return;
			}
		
			var newlist = new List<int>();
			newlist.AddRange(list);
			newlist.Add(ia[index]);
			FindCombination(ia, index + 1, targetsum, list,mem);
			FindCombination(ia, index + 1, targetsum - ia[index], newlist,mem);
		}
	}
}
