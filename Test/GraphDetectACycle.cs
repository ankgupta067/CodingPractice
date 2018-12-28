using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class GraphDetectACycle
    {
        public bool Cycle(GraphNode<int> node,List<int> visitednodes)
        {
            visitednodes.Add(node.data);
            var result = false;
            foreach (var item in node.Nodes)
            {
                if (visitednodes.Contains(item.data))
                {
                    return true;                    
                }
               if( result || Cycle(item, visitednodes))
                {
                    return true;
                }
            }
            return false;
        }

        public bool DetectCycleDirected(GraphNode<int> node,Dictionary<int,bool> recstack)
        {
            if (recstack.ContainsKey(node.data) && recstack[node.data])
            {
                return true;
            }
            recstack[node.data] = true;
            bool result = false;
            foreach (var item in node.Nodes)
            {
                result = result || DetectCycleDirected(item, recstack);
                if (result)
                {
                    return true;
                }
            }
            recstack[node.data] = false;
            return false;
        }

        public void Init()
        {
            var gnode0 = new GraphNode<int> { data = 0 };
            var gnode1 = new GraphNode<int> { data = 1 };
            var gnode2 = new GraphNode<int> { data = 2 };
            var gnode3 = new GraphNode<int> { data = 3 };
            gnode0.Nodes.Add(gnode1);
            gnode0.Nodes.Add(gnode2);
            gnode1.Nodes.Add(gnode2);
            gnode2.Nodes.Add(gnode0);
            gnode2.Nodes.Add(gnode3);
           // gnode3.Nodes.Add(gnode3);
            Console.WriteLine(DetectCycleDirected(gnode0, new Dictionary<int, bool>()));
        }
    }
}
