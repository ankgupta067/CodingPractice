using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class ZeroSumSubArray
    {
       
        public void Init()
        {
            var ia = new int[] { 4, 2, -3, 1, 6 };
            ZeroSumSubArrayLogic(ia);
        }

        private void ZeroSumSubArrayLogic(int[] ia)
        {
            var sum = 0;
            var count = 0;
            var hash = new Dictionary<int, int>();
            for (int i = 0; i < ia.Length; i++)
            {
                sum += ia[i];
                if (sum == 0)
                {
                    if (hash.ContainsKey(0))
                    {
                        hash[0] += 1;
                        count += hash[0];
                    }
                    else
                    {
                        count += 1;
                        hash.Add(0, 1);
                    }

                }
                else
                {
                    if (hash.ContainsKey(sum))
                    {
                        count += hash[sum];
                        hash[sum] += 1;
                    }
                    else
                    {
                        hash[sum] = 1;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
