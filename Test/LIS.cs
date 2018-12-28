using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
   public class LIS
    {
        public List<int> LisCompute(int[] inputarray,int index, int currmax, List<int> outlist)
        {
            if (index == inputarray.Length)
            {
                return outlist;
            }
            if (currmax < inputarray[index])
            {
                var newlist = new List<int>();
                newlist.AddRange(outlist);
                newlist.Add(inputarray[index]);
                var withitem = LisCompute(inputarray, index + 1, inputarray[index], newlist);
                var withoutitem = LisCompute(inputarray, index + 1, currmax,outlist);
                if (withitem.Count < withoutitem.Count)
                {
                    return withoutitem;
                }
                return withitem;
            }
            return LisCompute(inputarray, index + 1, currmax,outlist);
        }

        public void Init()
        {
            var arr = new int[]
            {
                0 ,8, 4, 12 ,2 ,10 ,6, 14 ,1 ,9 ,5, 13 ,3, 11, 7, 15
            };
            var output =LisCompute(arr,0,-1,new List<int>());
            foreach (var item in output)
            {
                Console.WriteLine(item);
            }

        }
    }
}
