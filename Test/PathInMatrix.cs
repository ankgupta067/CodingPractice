using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class PathInMatrix
    {
        public int FindPath(int[,] ia,int currI, int currJ,int maxI , int MaxJ,int[,] mem)
        {
            if (currI == -1 || currJ == -1 || currI > maxI || currJ > MaxJ)
            {
                return 0;
            }
            if (mem[currI, currJ] != -1)
            {
                return mem[currI, currJ];
            }
            int maxvalue = 0;
            maxvalue = ChildTask(ia, currI + 1, currJ,currI,currJ, maxI, MaxJ, mem, maxvalue);
            maxvalue = ChildTask(ia, currI - 1, currJ, currI, currJ, maxI, MaxJ, mem, maxvalue);
            maxvalue = ChildTask(ia, currI,currJ + 1, currI, currJ, maxI, MaxJ, mem, maxvalue);
            maxvalue = ChildTask(ia, currI, currJ - 1, currI, currJ, maxI, MaxJ, mem, maxvalue);
            
            mem[currI, currJ] = maxvalue;
            return maxvalue;
        }

        private int ChildTask(int[,] ia, int newI, int newJ, int oldI,int oldJ, int maxI, int MaxJ, int[,] mem, int maxvalue)
        {
            if (newI == -1 || newJ == -1 || newI > maxI || newJ > MaxJ)
            {
                return maxvalue;
            }
            if (ia[newI, newJ] == ia[oldI, oldJ] + 1)
            {
                var value = 1 + FindPath(ia, newI, newJ, maxI, MaxJ, mem);
                if (value > maxvalue)
                {
                    maxvalue = value;
                }
            }
            return maxvalue;            
        }

        public void Init()
        {
            var iind = 3;
            var jind = 3;
            var ia = new int[3,3] { { 1, 2, 9 }, { 5, 3, 6 }, { 6, 4,5 } };
            var mem = new int[3, 3];
            for (int i = 0; i < iind; i++)
            {
                for (int j = 0; j < jind; j++)
                {
                    mem[i, j] = -1;
                }
            }
            int maxvalue = 0;
            for (int i = 0; i < iind; i++)
            {
                for (int j = 0; j < jind; j++)
                {
                    int value = 1 + FindPath(ia, i, j, iind - 1, jind - 1, mem);
                    if (value > maxvalue)
                    {
                        maxvalue = value;
                    } 
                }
            }

            Console.WriteLine(maxvalue);
        }
    }
}
