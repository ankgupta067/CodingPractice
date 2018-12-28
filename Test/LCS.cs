using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class LCS
    {
        public int LcsComputation(string x, string y, int xindex,int yindex,int[,] memtable)
        {
            if (xindex == -1 || yindex == -1)
            {
                return 0;
            }
            if (memtable[xindex,yindex] != 0)
            {
                return memtable[xindex,yindex];
            }
            if (x[xindex] == y[yindex])
            {
                var result = 1 + LcsComputation(x, y, xindex - 1, yindex - 1, memtable);
                memtable[xindex,yindex] = result;
                return result;
            }
            else
            {
                var result = Math.Max(LcsComputation(x, y, xindex, yindex - 1, memtable),
                    LcsComputation(x, y, xindex - 1, yindex, memtable));
                memtable[xindex,yindex] = result;
                return result;
            }
        }

        public string LcsComputationstring(string x, string y, int xindex, int yindex, string[,] memtable)
        {
            if (xindex == -1 || yindex == -1)
            {
                return "";
            }
            if (memtable[xindex, yindex] != null)
            {
                return memtable[xindex, yindex];
            }
            if (x[xindex] == y[yindex])
            {
                var result = LcsComputationstring(x, y, xindex - 1, yindex - 1, memtable) + x[xindex];
                memtable[xindex, yindex] = result;
                return result;
            }
            else
            {
                var result1 = LcsComputationstring(x, y, xindex, yindex - 1, memtable);
                var result2 = LcsComputationstring(x, y, xindex - 1, yindex, memtable);
                if (result1.Length > result2.Length)
                {
                    memtable[xindex, yindex] = result1;
                    return result1;
                }
                else
                {
                    memtable[xindex, yindex] = result2;
                    return result2;
                }                
            }
        }
        public void Init()
        {
            var x = "AGGTAB";
            var y = "GXTXAYB";
            string[,] memtable = new string[x.Length,y.Length];
            Console.WriteLine(LcsComputationstring(x, y, x.Length - 1, y.Length - 1, memtable));
            
        }
    }
}
