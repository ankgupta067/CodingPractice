using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class FindShortestPathGraph
    {
        class Graph
        {
            public List<GraphNode<int>> Nodes { get; set; }
            public Graph()
            {
                Nodes = new List<GraphNode<int>>();
            }
        }
        public void Init()
        {
            const int n = 5;
            var ia = new int[,] { { 31, 100, 65, 12, 18 }, { 10, 13, 47, 157, 6 }, { 100, 113, 174, 11, 33 }, { 88, 124, 41, 20, 140 }, { 99, 32, 111, 41, 20 } };
            var graph = new LinkedList<int>[n * n];
            var visited = new bool[n * n];
            var cost = new Tuple<int, int>[n*n];
            cost[0] = new Tuple<int, int>(-1, ia[0, 0]);
            
            var arrindex = 0;
            while (arrindex != (n*n)-1)
            {
                var curri = arrindex / n;
                var currj = arrindex % n;
                arrindex = curri * n + currj;
                if (!visited[arrindex])
                {
                    if (currj + 1 < n)
                    {
                        if (cost[arrindex + 1] == null)
                        {
                            cost[arrindex + 1] = new Tuple<int, int>(arrindex, cost[arrindex].Item2 + ia[curri, currj +1]);
                        }
                        else
                        {
                            var newcost = cost[arrindex].Item2 + ia[curri, currj +1];
                            if (cost[arrindex + 1].Item2 > newcost)
                            {
                                cost[arrindex + 1] = new Tuple<int, int>(arrindex, cost[arrindex].Item2 + ia[curri, currj + 1]);
                            }
                        }
                    }
                    if (currj - 1 >=0)
                    {
                        if (cost[arrindex - 1] == null)
                        {
                            cost[arrindex - 1] = new Tuple<int, int>(arrindex, cost[arrindex].Item2 + ia[curri, currj - 1]);
                        }
                        else
                        {
                            var newcost = cost[arrindex].Item2 + ia[curri, currj - 1];
                            if (cost[arrindex - 1].Item2 > newcost)
                            {
                                cost[arrindex - 1] = new Tuple<int, int>(arrindex, cost[arrindex].Item2 + ia[curri, currj - 1]);
                            }
                        }
                    }
                    
                    if (curri - 1 >= 0)
                    {
                        if (cost[arrindex - n] == null)
                        {
                            cost[arrindex - n] = new Tuple<int, int>(arrindex, cost[arrindex].Item2 + ia[curri -1, currj]);
                        }
                        else
                        {
                            var newcost = cost[arrindex].Item2 + ia[curri -1, currj];
                            if (cost[arrindex - n].Item2 > newcost)
                            {
                                cost[arrindex - n] = new Tuple<int, int>(arrindex, cost[arrindex].Item2 + ia[curri - 1 , currj]);
                            }
                        }
                    }
                    if (curri +1 < n)
                    {
                        if (cost[arrindex + n] == null)
                        {
                            cost[arrindex + n] = new Tuple<int, int>(arrindex, cost[arrindex].Item2 + ia[curri + 1, currj]);
                        }
                        else
                        {
                            var newcost = cost[arrindex].Item2 + ia[curri + 1, currj];
                            if (cost[arrindex + n].Item2 > newcost)
                            {
                                cost[arrindex + n] = new Tuple<int, int>(arrindex, newcost);
                            }
                        }
                    }
                    visited[arrindex] = true;
                    int min = int.MaxValue;
                    int indextovisit = -1;
                    for (int i = 0; i < n*n; i++)
                    {
                        if (!visited[i])
                        {
                            if (cost[i] != null)
                            {
                                if (cost[i].Item2 < min)
                                {
                                    min = cost[i].Item2;
                                    indextovisit = i;
                                }
                            }
                        }
                    }
                    arrindex = indextovisit;
                }

            }
            Console.WriteLine(cost[(n * n) - 1].Item2);
            arrindex = cost[(n * n) - 1].Item1;
            while (arrindex != -1)
            {
                Console.WriteLine(cost[arrindex].Item2);
                arrindex = cost[arrindex].Item1;
            }
        }
     }
}
