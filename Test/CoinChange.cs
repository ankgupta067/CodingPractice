using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class CoinChange
    {
        public int Calculate(int[] S,int m, int n,int[,] mem)
        {
            if (n==0)
            {
                return 1;
            }
            if (n < 0 || m < 0)
            {
                return 0;
            }
            if (mem[m,n] != -1)
            {
                return mem[m, n];
            }
            return Calculate(S, m - 1, n,mem) + Calculate(S, m, n - S[m],mem);
        }
        public void Init()
        {
            
            int[] s = new int[] { 2, 5, 3, 6 };
            int n = 10;
            var mem = new int[s.Length, n+1];
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    mem[i, j] = -1;
                }
            }
            Console.WriteLine(Calculate(s, s.Length - 1, n,mem));
        }
    }
}
