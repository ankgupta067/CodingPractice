using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class SnakeLadder
    {
        public void Init()
        {
            var totalblocks = 30;
            var ls = new Dictionary<int, int>();
            ls.Add(11, 26);
            ls.Add(3, 22);
            ls.Add(5,8);
            ls.Add(20,29);
           ls.Add(27, 1);
            ls.Add(21, 9);
            var mem = new int[totalblocks + 1];
            Console.WriteLine(GetCount(1, ls, totalblocks, mem, 6));

        }
        public int GetCount(int currpos,Dictionary<int,int>ls,int maxpos, int[] mem, int dicefaces)
        {
            if (currpos >= maxpos)
            {
                return 0;
            }
            if (mem[currpos] != 0)
            {
                return mem[currpos];
            }

            if (ls.ContainsKey(currpos))
            {
                if (ls[currpos] < currpos)
                {
                    return int.MaxValue - 1;
                }
                currpos = ls[currpos];
            }
           

           
            var minyet = int.MaxValue;
            for (int i = 1; i <= dicefaces; i++)
            {
                var currvalue = 1 + GetCount(currpos + i, ls, maxpos, mem, dicefaces);
                if (currvalue < minyet)
                {
                    minyet = currvalue;
                }
            }
            mem[currpos] = minyet;
            return minyet;

        }
    }
}
