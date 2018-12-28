using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class SCC
    {
        

        public void Init()
        {
            var edges = new List<Tuple<int, int>>();
            edges.Add(new Tuple<int, int>(0, 2));
            edges.Add(new Tuple<int, int>(2, 1));
            edges.Add(new Tuple<int, int>(1, 0));
            edges.Add(new Tuple<int, int>(0, 3));
            edges.Add(new Tuple<int, int>(3,4));
            var ll = new LinkedList<int>[5];
            foreach (var edge in edges)
            {
                if (ll[edge.Item1] == null)
                {
                    ll[edge.Item1] = new LinkedList<int>();
                }
                ll[edge.Item1].AddLast(edge.Item2);
            }
            var visited = new bool[5];
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < ll.Length; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    df(ll[i], visited, stack,ll,false);
                    stack.Push(i);
                }
               
            }

            ll = new LinkedList<int>[5];
            foreach (var edge in edges)
            {
                if (ll[edge.Item2] == null)
                {
                    ll[edge.Item2] = new LinkedList<int>();
                }
                ll[edge.Item2].AddLast(edge.Item1);
            }

            visited = new bool[5];
            while (stack.TryPop(out int item))
            {
                if (!visited[item])
                {
                    visited[item] = true;
                    df(ll[item], visited, stack, ll, true);
                    Console.Write($"{item} ");
                    Console.WriteLine();
                }

            }
        }

        private void df(LinkedList<int> linkedList, bool[] visited, Stack<int> stack, LinkedList<int>[] ll,bool stackpop)
        {
            if (linkedList == null)
            {
                return;
            }
            foreach (var item in linkedList)
            {
                if (!visited[item])
                {
                    visited[item] = true;
                    df(ll[item], visited, stack, ll,stackpop);
                    if (stackpop)
                    {
                        Console.Write($"{item} ");
                    }
                    else
                    {
                        stack.Push(item);
                    }
                }
            }
            
        }
    }
}
