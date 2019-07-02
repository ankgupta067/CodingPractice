using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class HashingLongestConsecutiveSubsequence
    {
        public void Init()
        {
            var ia = new int[] { 1, 9, 3, 10, 4, 20, 2 };
            Console.WriteLine(FindLongestSequence(ia));
        }

        private int FindLongestSequence(int[] ia)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < ia.Length; i++)
            {
                if (dict.ContainsKey(ia[i]))
                {
                    dict[ia[i]] += 1;
                }
                else
                {
                    dict.Add(ia[i],1);
                }
            }
            int maxcount = 0;
            for (int i = 0; i < ia.Length; i++)
            {
                var entry = ia[i];
               
                if (dict[ia[i]] != 0)
                {                    
                    var count = dict[ia[i]];
                    dict[ia[i]] = 0;
                    var loop = true;
                    var incentry = entry;
                    while (loop)
                    {
                        incentry = incentry + 1;
                        
                        if (dict.ContainsKey(incentry) && dict[incentry] != 0)
                        {
                            count += dict[incentry];
                            dict[incentry] = 0;
                        }
                        else
                        {
                            loop = false;
                        }
                    }
                    loop = true;
                    var deccentry = entry;
                    while (loop)
                    {
                        deccentry = deccentry - 1;
                        if (dict.ContainsKey(deccentry) && dict[deccentry] != 0)
                        {
                            count += dict[deccentry];
                            dict[deccentry] = 0;
                        }
                        else
                        {
                            loop = false;
                        }
                    }
                    if (count > maxcount)
                    {
                        maxcount = count;
                    }
                }

                

            }
            return maxcount;
        }
    }
}
