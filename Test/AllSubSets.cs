using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class AllSubSets
    {
        public void PrintAllSubSets(int[] input)
        {
            var total = input.Length;

            for (int i = 0; i < (1 << total); i++)
            {
                Console.WriteLine();
                Console.Write("{ ");
                for (int j = 0; j < total; j++)
                {
                    if ((i & (1<<j)) != 0)
                    {
                        Console.Write(input[j]);
                        Console.Write(" ");
                    }
                }
                Console.Write("}");
            }
        }

        public void Init()
        {
            var inputaray = new int[] { 1, 2, 3, 4 };
            PrintAllSubSets(inputaray);
        }
    }
}
