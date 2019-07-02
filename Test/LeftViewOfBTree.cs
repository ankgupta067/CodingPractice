using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class BTreeNode
    {
        public int Data { get; set; }

        public BTreeNode LeftNode { get; set; }

        public BTreeNode RightNode { get; set; }
    }
    class LeftViewOfBTree
    {
        int maxheight = -1;
        public void Init()
        {
            var node = new BTreeNode();
            node.Data = 4;
            node.LeftNode = new BTreeNode() { Data = 5 };
            node.RightNode = new BTreeNode()
            {
                Data = 2,
                LeftNode =
                new BTreeNode
                {
                    Data = 3,
                    LeftNode = new BTreeNode { Data = 6 },
                    RightNode = new BTreeNode { Data = 7 }
                },
                RightNode = new BTreeNode { Data = 1 }
            };
            DisplayLeftView(node, 0);
        }

        private void DisplayLeftView(BTreeNode node, int height)
        {
            if (node == null)
            {
                return;
            }
            if (maxheight < height)
            {
                Console.WriteLine(node.Data);
                maxheight = height;
            }
            DisplayLeftView(node.LeftNode, height + 1);
            DisplayLeftView(node.RightNode, height + 1);

        }
    }
    
}
