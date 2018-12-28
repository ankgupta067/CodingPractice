using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class MinCostPath
    {
        public void Init()
        {
            //var ia = new int[,] { { 31, 100, 65, 12, 18 }, { 10, 13, 47, 157, 6 }, { 100, 113, 174, 11, 33 }, { 88, 124, 41, 20, 140 }, { 99, 32, 111, 41, 20 } };
            var ia = new int[,] { { 42, 93 }, { 7, 14 } };
            int n = 2;
            var mem = new int[n, n];
            Console.WriteLine(MinCostPathLogic(0, 0, n, mem, ia));
        }

        private int MinCostPathLogic(int i, int j, int n, int[,] mem, int[,] ia)
        {
            if (i==n || j==n || i < 0 || j < 0)
            {
                return int.MaxValue;
            }
            if (i == n-1 && j == n-1)
            {
                return ia[i, j];
            }
            if (mem[i,j] != 0)
            {
                return mem[i, j];
            }
            
            var res1 = MinCostPathLogic(i + 1, j, n, mem, ia);
            var res2 = MinCostPathLogic(i, j + 1, n, mem, ia);
            var res3 = MinCostPathLogic(i-1 , j, n, mem, ia);
            var res4 = MinCostPathLogic(i, j-1, n, mem, ia);
            var res5 = Math.Min(res1, res2);
            var res6 = Math.Min(res4, res3);
            var res = Math.Min(res5,res6) + ia[i, j];
            mem[i, j] = res;
            return res;
        }
    }
}
