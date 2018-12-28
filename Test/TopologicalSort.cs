using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class TopologicalSort
    {
        public void Sort(GraphNode<int> node, Stack<int> result,List<int> visited)
        {
            if (visited.Contains(node.data))
            {
                return;
            }
            visited.Add(node.data);
            foreach (var item in node.Nodes)
            {
                if (!visited.Contains(item.data))
                {
                    Sort(item, result, visited);
                }
            }
            result.Push(node.data);
        }

        public void Init()
        {
            var node5 = new GraphNode<int>();
            node5.data = 5;
            var node7 = new GraphNode<int>();
            node7.data = 7;
            var node3 = new GraphNode<int>();
            node3.data = 3;
            var node11 = new GraphNode<int>();
            node11.data = 11;

            var node8 = new GraphNode<int>();
            node8.data = 8;
            var node9 = new GraphNode<int>();
            node9.data = 9;
            var node10 = new GraphNode<int>();
            node10.data = 10;
            var node2 = new GraphNode<int>();
            node2.data = 2;
            node5.Nodes.Add(node11);
            node7.Nodes.Add(node11);
            node11.Nodes.Add(node9);
            node11.Nodes.Add(node2);
            node11.Nodes.Add(node10);
            node7.Nodes.Add(node8);
            node3.Nodes.Add(node8);
            node3.Nodes.Add(node10);
            node8.Nodes.Add(node9);
            var collection = new List<GraphNode<int>>();
            collection.Add(node5);
            collection.Add(node7);
            collection.Add(node3);
            collection.Add(node11);
            collection.Add(node8);
            collection.Add(node2);
            collection.Add(node9);
            collection.Add(node10);
            var stack = new Stack<int>();
            var visited = new List<int>();
            foreach (var item in collection)
            {
                Sort(item, stack, visited);
            }
           
            while (stack.TryPeek(out int result))
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
