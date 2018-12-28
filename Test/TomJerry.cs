using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class TomJerry
    {
        public bool Game(int number,bool whoseturn, int[] mem)
        {
            if (number == 0)
            {
                return !whoseturn;
            }
            if (number < 0)
            {
                return whoseturn;
            }
            if (mem[number] != -1)
            {
                if (mem[number] == 1)
                {
                    return whoseturn;
                }
                return !whoseturn;
            }
            var poss = new List<int>();
            for (int i = 1; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    if (number != i)
                    {
                        poss.Add(i);
                    }                    
                    var div = number / i;
                    if (div != number && div != i)
                    {
                        poss.Add(div);
                    }
                }
            }
            for (int i = 0; i < poss.Count; i++)
            {
                var result = Game(number - poss[i], !whoseturn,mem);
                if (result == whoseturn)
                {
                    mem[number] = 1;
                    return whoseturn;
                }
            }
            mem[number] = 0;
            return !whoseturn;
        }

        public void Init()
        {
            var number = 1;        
            int[] mem = new int[number + 1];
            for (int i = 0; i < number +1; i++)
            {
                mem[i] = -1;
            }
            if (Game(number,true,mem))
            {
                Console.WriteLine("Tom");
            }
            else
            {
                Console.WriteLine("Jerry");
            }

        }
    }
}
