using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class EggDropping
    {
        static int floor = -1;
        public int EggDrop(int n, int k,int[,] mem)
        {
            if (n == 1)
            {
                return k;
            }
            if (k == 0|| k ==1)
            {
                return k;
            }
            if (mem[n,k] != -1)
            {
                return mem[n, k];
            }
            int minyet = int.MaxValue;
            for (int i = 1; i <= k; i++)
            {
                var result = Math.Max(EggDrop(n - 1, i - 1,mem), EggDrop(n, k - i,mem));
                if (result < minyet)
                {
                    minyet = result;
                    floor = i;
                }
            }

            var result1 =  minyet + 1;
            mem[n, k] = result1;
            return result1;
        }

        public void Init()
        {
            int n =2;
            int k =36;
            int[,] mem = new int[n+1,k+1];
            for (int i = 0; i < n +1; i++)
            {
                for (int j = 0; j < k+1; j++)
                {
                    mem[i, j] = -1;
                }
            }
            Console.WriteLine(EggDrop(n,k,mem));
            Console.WriteLine($"floor -- {floor}");
        }
    }
}
