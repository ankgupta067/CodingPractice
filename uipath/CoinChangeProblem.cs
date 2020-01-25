using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace uipath
{
    class CoinChangeProblem
    {
        public void Init()
        {
            var coin = new[] { 2, 5, 3, 6 };
            var finalValue = 10;
            var mem = new int[coin.Length, finalValue+1];
            Console.WriteLine(numberOfWays(coin,coin.Length-1,finalValue,mem));
        }

        private int numberOfWays(int[] coin,int index, int finalValue,int[,] mem)
        {
            int count = 0;
            if (finalValue == 0)
            {
                return 1;
            }

            if (finalValue < 0)
            {
                return 0;
            }

            if (index < 0 && finalValue > 0)
            {
                return 0;
            }

            if (mem[index, finalValue] != 0)
            {
                return mem[index, finalValue];
            }

            var result = numberOfWays(coin, index, finalValue - coin[index], mem) +
                         numberOfWays(coin, index - 1, finalValue, mem);
            mem[index, finalValue] = result;
            return result;
        }
    }
}
