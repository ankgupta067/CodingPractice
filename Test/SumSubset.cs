using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class SumSubset
    {
        public bool SumSubsetLogic(int[] inputarray, int index, List<int> Subset1, List<int> Subset2)
        {
            if (index == inputarray.Length)
            {
                if (Subset1.Sum() == Subset2.Sum())
                {
                    return true;
                }
                return false;
            }
            var sub1 = new List<int>();
            sub1.AddRange(Subset1);
            sub1.Add(inputarray[index]);
            var sub2 = new List<int>();
            sub2.AddRange(Subset2);
            sub2.Add(inputarray[index]);
            return SumSubsetLogic(inputarray, index + 1, sub1, Subset2) || SumSubsetLogic(inputarray, index + 1, Subset1, sub2);
        }

        public void Init()
        {
            var ia = new int[] { 1, 5, 11 };
            Console.WriteLine(SumSubsetLogic(ia,0,new List<int>(),new List<int>()));
        }
    }
}
