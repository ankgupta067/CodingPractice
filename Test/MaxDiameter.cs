using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class MaxDiameter
	{
		public void Init()
		{
			var root = new BTreeNode()
			{
				Data = 2,
				LeftNode = new BTreeNode(),
				RightNode = new BTreeNode()
			};
			Tuple<int, int> finalresult = MaxDia(root);
			Console.WriteLine(finalresult.Item1);
		}

		private Tuple<int, int> MaxDia(BTreeNode root)
		{
			if (root == null)
			{
				return new Tuple<int, int>(0, 0);
			}

			var ldia = MaxDia(root.LeftNode);
			var rdia = MaxDia(root.RightNode);
			var subtreelen = ldia.Item2 + 1 + rdia.Item2;
			var submax =  Math.Max(ldia.Item1, rdia.Item1);
			var maxsubtreelen = Math.Max(subtreelen, submax);
			var longestheight = 1 + Math.Max(ldia.Item2, rdia.Item2);
			return new Tuple<int, int>(maxsubtreelen, longestheight);
		}
	}
}
