using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class GraphNode<T>
    {
        public GraphNode()
        {
            Nodes = new List<GraphNode<T>>();
        }
        public T data { get; set; }
        public List<GraphNode<T>> Nodes {get; private set;}
    }

    public class Graph
    {
        public void BreadthFirstSearch<T>(GraphNode<T> node)
        {
            var queue = new Queue<GraphNode<T>>();
            List<GraphNode<T>> VisistedNodes =
                new List<GraphNode<T>>();
            queue.Enqueue(node);
            VisistedNodes.Add(node);
            var result = new GraphNode<T>();
            while(queue.TryPeek(out result))
            {
                var currnode = queue.Dequeue();
                Console.WriteLine(currnode.data);
                foreach (var item in currnode.Nodes)
                {
                    if (VisistedNodes.Contains(item))
                    {
                        continue;
                    }
                    VisistedNodes.Add(node);
                    queue.Enqueue(item);
                }
            }
        }

        public GraphNode<string> Init()
        {
            var node = new GraphNode<string>() { data = "Alice" };
            node.Nodes.Add(new GraphNode<string> { data = "candy" });
            node.Nodes.Add(new GraphNode<string> { data = "Elaine" });
            var n1 = new GraphNode<string> { data = "Bob" };
            var n2 = new GraphNode<string> { data = "fred" };
            var n3 = new GraphNode<string> { data = "Helen" };
            var n4 = new GraphNode<string> { data = "Derek" };
            var n5 = new GraphNode<string> { data = "Gina" };
            var n6 = new GraphNode<string> { data = "Irena" };
            n2.Nodes.Add(n3);
            n1.Nodes.Add(n2);
            n5.Nodes.Add(n6);
            n4.Nodes.Add(n5);
            node.Nodes.Add(n1);
            node.Nodes.Add(n4);
            return node;
        }

        public void DoSomething()
        {
            var node = Init();
            BreadthFirstSearch<string>(node);
        }
    }
}
