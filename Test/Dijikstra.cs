using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class Node
    {
        public Node()
        {
            Routes = new Dictionary<string, int>();
        }
        public string Data { get; set; }
        public Dictionary<string, int> Routes;
    }

    public class Dijikstra
    {
        public void Init()
        {
            var StartNode = new Node() { Data = "A" };
            StartNode.Routes.Add("D", 160);
            StartNode.Routes.Add("B", 100);
            var BNode = new Node() { Data = "B" };
            BNode.Routes.Add("C", 120);
            BNode.Routes.Add("D", 180);

            var CNode = new Node() { Data = "C" };
            CNode.Routes.Add("E", 80);

            var DNode = new Node() { Data = "D" };
            DNode.Routes.Add("C", 40);
            DNode.Routes.Add("E", 140);

            var ENode = new Node() { Data = "E" };
            ENode.Routes.Add("B", 100);

            DijikstraAlgo(StartNode, new List<Node> { BNode, CNode, DNode, ENode });

        }

        public void DijikstraAlgo(Node startNode,List<Node> vertexList)
        {
            var weightedRoutes = new Dictionary<string, Tuple<int, string>>();
            List<string> visitedNodes = new List<string>();
            var currnode = startNode;
            weightedRoutes.Add(startNode.Data, new Tuple<int, string>(0, null));
            foreach (var item in vertexList)
            {
                weightedRoutes.Add(item.Data, new Tuple<int, string>(int.MaxValue, null));
            }
            while (currnode != null)
            {
                foreach (var item in currnode.Routes)
                {
                    if (weightedRoutes[item.Key].Item1 == int.MaxValue) { 
                    
                        weightedRoutes[item.Key] = 
                            new Tuple<int, string>(item.Value + weightedRoutes[currnode.Data].Item1,currnode.Data);
                    }
                    else
                    {
                        if (weightedRoutes[item.Key].Item1 >
                            (weightedRoutes[currnode.Data].Item1 + item.Value)){
                            weightedRoutes[item.Key] = new Tuple<int, string>(
                                weightedRoutes[currnode.Data].Item1 + item.Value,
                                currnode.Data);
                        }
                    }                    
                }
                visitedNodes.Add(currnode.Data);
                string minnodekey = null;
                int minnodevalue = int.MaxValue;
                foreach (var item in weightedRoutes)
                {
                    if (!visitedNodes.Contains(item.Key))
                    {
                        if (item.Value.Item1 < minnodevalue)
                        {
                            minnodekey = item.Key;
                            minnodevalue = item.Value.Item1;
                        }
                    }
                }
                currnode = vertexList.FirstOrDefault(x => x.Data == minnodekey);
            }
        }
    }
}
