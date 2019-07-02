using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class LongestTreeLength
	{
		public void Init()
		{
			var node = new BTreeNode()
			{
				Data = 1,
				LeftNode = new BTreeNode()
				{
					Data = 2,
					LeftNode = new BTreeNode
					{
						Data = 3
					}
				},
				RightNode = new BTreeNode()
				{
					Data = 4,
					LeftNode = new BTreeNode
					{
						Data = 5
					},
					RightNode = new BTreeNode
					{
						Data = 6,
						LeftNode = new BTreeNode
						{
							Data = 7
						}
					}
				}				
			};
			Console.WriteLine(LongestTreeLengthLogic(node, 1));
		}

		public int LongestTreeLengthLogic(BTreeNode node,int length)
		{
			if (node.LeftNode == null && node.RightNode == null)
			{
				return length;
			}
			int llength = 0;
			int rlength = 0;

			if (node.LeftNode != null)
			{				
				if (node.LeftNode.Data == node.Data + 1)
				{
				 llength = LongestTreeLengthLogic(node.LeftNode, length + 1);
				}
				else
				{
					llength = LongestTreeLengthLogic(node.LeftNode, length);
				}
			}
			if (node.RightNode != null)
			{
				if (node.RightNode.Data == node.Data + 1)
				{
					rlength = LongestTreeLengthLogic(node.RightNode, length + 1);
				}
				else
				{
					rlength = LongestTreeLengthLogic(node.RightNode, length);
				}
			}

			if (llength > rlength)
			{
				return llength;
			}
			else
			{
				return rlength;
			}
		}
	}
}
