using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Islands
    {
        public void FindIsland(int[,] inputarray,List<Tuple<int,int>> island,int m, int n,int limitm, int limitn)
        {
            if (m == limitm || n == limitn || m== -1 || n==-1)
            {
                return;
            }
            if (inputarray[m,n] == 2 || inputarray[m,n] == 0)
            {
                return;
            }
            if(inputarray[m,n] == 1)
            {
                inputarray[m, n] = 2;
                island.Add(new Tuple<int, int>(m, n));
            }
            FindIsland(inputarray, island, m + 1, n, limitm, limitn);
            FindIsland(inputarray, island, m + 1, n-1, limitm, limitn);
            FindIsland(inputarray, island, m + 1, n+1, limitm, limitn);
            FindIsland(inputarray, island, m, n - 1, limitm, limitn);
            FindIsland(inputarray, island, m, n + 1, limitm, limitn);
            FindIsland(inputarray, island, m - 1, n, limitm, limitn);
            FindIsland(inputarray, island, m - 1, n - 1, limitm, limitn);
            FindIsland(inputarray, island, m - 1, n + 1, limitm, limitn);
        }

        public void Init()
        {
            const int m = 5;
            const int n = 5;
            var ia = new int[m,n]
            {{1, 1, 0, 0, 0},
                   {0, 1, 0, 0, 1},
                   {1, 0, 0, 1, 1},
                   {0, 0, 0, 0, 0},
                   {1, 0, 1, 0, 1} };
            var result = 0;
            for (int i = 0; i < m; i++)
            {
                
                for (int j = 0; j < n; j++)
                {
                    var list = new List<Tuple<int, int>>();
                    FindIsland(ia,list, i,j, m, n);
                    if (list.Count > 0)
                    {
                        result += 1;
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
