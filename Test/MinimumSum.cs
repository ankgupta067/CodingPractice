using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class MinimumSum
    {
        int MinSum(int[] ia,int s1,int s2,int index)
        {
            if (index == ia.Length)
            {
                return Math.Abs(s1 - s2);
            }

            var res1 = Math.Abs(MinSum(ia, s1 + ia[index], s2, index + 1));
            var res2 = Math.Abs(MinSum(ia, s1, s2 + ia[index], index + 1));
            return Math.Min(res1, res2);
        }

        public void Init()
        {
            var ia = new int[] { 36, 7, 46, 40 };
            Console.WriteLine(MinSum(ia, 0, 0, 0));
        }
    }
}
