using System;
using System.Collections.Generic;

namespace uipath
{
    public class LongestDistinctCharacter
    {
       public void Init()
        {
            logic("GEEKSFORGEEKS");
        }

       void n2logic(string str)
        {
            int startIndex = 0;
            int currentIndex = 0;
            int currentLength = 0;
            int largestLength = 0;
            Dictionary<char, int> mem = new Dictionary<char, int>();

            while(currentIndex < str.Length)
            {
                if (mem.ContainsKey(str[currentIndex]))
                {
                    if(currentLength > largestLength)
                    {
                        largestLength = currentLength;
                    }
                    currentLength = 0;
                    startIndex += 1;
                    currentIndex = startIndex;
                    mem.Clear();
                }
                else
                {
                    mem.Add(str[currentIndex], 1);
                    currentLength += 1;
                    currentIndex += 1;
                }
            }

            if (currentLength > largestLength)
            {
                largestLength = currentLength;
            }

            Console.WriteLine(largestLength);
        }

        void logic(string str)
        {
            Dictionary<char, int> mem = new Dictionary<char, int>();

            int currentLength = 0;
            int largestLength = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (mem.ContainsKey(str[i]))
                {
                    if(currentLength > largestLength)
                    {
                        largestLength = currentLength;
                    }
                    currentLength = i - mem[str[i]];
                    mem[str[i]] = i;
                }
                else
                {
                    mem[str[i]] = i;
                    currentLength += 1;
                }
            }
            if (currentLength > largestLength)
            {
                largestLength = currentLength;
            }
            Console.WriteLine(largestLength);

        }
    }
}
