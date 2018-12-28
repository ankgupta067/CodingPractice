using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class MaxSubsequenseSum
    {
        //class dictentry
        //{
        //    public int Total { get; set; }
        //    public int index { get; set; }
        //    public override bool Equals(object obj)
        //    {
        //        if (obj is dictentry x)
        //        {
        //            return x.index == this.index && x.Total == this.Total;
        //        }
        //        return false;
        //    }
        //    public override int GetHashCode()
        //    {
        //        return Total * ;
        //    }
        //}
        public void Init()
        {
            var ia = new int[] { 2,-1, 2, 3, 4,-5 };
            Console.WriteLine( MaxSubSum(ia) + " " + MaxSum(ia, 0));
            
           

        }

        private static int MaxSum(int[] ia, int index)
        {
            if (index == ia.Length-1)
            {
                return ia[ia.Length-1];
            }
            var ms = MaxSum(ia, index + 1);
            var res = Math.Max(ms, ms + ia[index]);
            return Math.Max(res, ia[index]);          

        }

        private static int MaxSubSum(int[] ia)
        {
            var total = 0;
            var maxyet = 0;
            for (int i = 0; i < ia.Length; i++)
            {
                if (i == 0)
                {
                    total = ia[i];
                    maxyet = ia[i];

                }
                else
                {
                    total = Math.Max (total + ia[i],ia[i]);
                    if (maxyet < total)
                    {
                        maxyet = total;
                    }
                }
            }
            return maxyet;
        }
    }
}
