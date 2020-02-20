using System;
namespace uipath
{

    public class LeftViewOfBinaryTree
    {
        class Node
        {
            public int data { get; set; }
            public Node Lnode { get; set; }
            public Node RNode { get; set; }
        }
        int lastprintedlevel = -1;
        public void Init()
        {
            var root = new Node
            {
                data = 1,
                Lnode = new Node
                {
                    data = 2,
                    Lnode = new Node { data = 4 },
                    RNode = new Node { data = 5 }

                },
                RNode = new Node
                {
                    data = 3,
                    Lnode = new Node
                    {
                        data = 6,
                        Lnode = new Node
                        {
                            data = 8
                        }
                    },
                    RNode = new Node
                    {
                        data = 7
                    }
                }

            };
            Logic(root, 0);

        }
        void Logic(Node n,int currentlevel)
        {
            if (n == null)
            {
                return;
            }

            if(lastprintedlevel < currentlevel)
            {
                Console.WriteLine(n.data);
                lastprintedlevel += 1;
            }

            Logic(n.Lnode, currentlevel + 1);
            Logic(n.RNode, currentlevel + 1);

        }

    }
}
