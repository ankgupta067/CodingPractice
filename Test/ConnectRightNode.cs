using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class ConnectRightNode
    {
        class RightNode
        {
            public int Data { get; set; }

            public RightNode Left { get; set; }

            public RightNode Right { get; set; }

            public RightNode Adjacent { get; set; }
        }

        public void Init()
        {
            var root = new RightNode
            {
                Data = 10,
                Left = new RightNode
                {
                    Data = 3,
                    Left = new RightNode
                    {
                        Data = 4
                    },
                    Right = new RightNode
                    {
                        Data = 1
                    }
                },
                Right = new RightNode
                {
                    Data = 5,
                    Right = new RightNode
                    {
                        Data = 2
                    }
                }
            };

            Connect(root);
        }

        private void Connect(RightNode root)
        {
            var q1 = new Queue<RightNode>();
            var q2 = new Queue<RightNode>();
            q2.Enqueue(root);
            while (q2.TryPeek(out RightNode result1))
            {
                q1 = q2;
                q2 = new Queue<RightNode>();
                while (q1.TryPeek(out RightNode result))
                {
                    result = q1.Dequeue();
                    if (q1.TryPeek(out RightNode nextresult))
                    {
                        result.Adjacent = nextresult;
                    }
                    if (result.Left != null)
                    {
                        q2.Enqueue(result.Left);
                    }
                    if (result.Right != null)
                    {
                        q2.Enqueue(result.Right);
                    }
                }
            }

        }
    }
}
