using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Jump
    {
        public int JumpCode(int[] inputarray, Dictionary<int,int> memarray, int startIndex)
        {
            if (memarray.ContainsKey(startIndex))
            {
                return memarray[startIndex];
            }
            if (startIndex >= inputarray.Length-1)
            {
                return 0;
            }
            if (inputarray[startIndex] == 0)
            {
                return -1;
            }
            var curresult = int.MaxValue;
            for (int j = 1; j <= inputarray[startIndex]; j++)
            {
                var result = 1 + JumpCode(inputarray,memarray ,j + startIndex);
                if (result == -1)
                {
                    return -1;
                }
                if (result < curresult)
                {
                    curresult = result;
                }
            }
            memarray[startIndex] = curresult;
            return curresult;
        }

        public void Init()
        {
            var inputarray = new int[] { 1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9 };

            Console.WriteLine(JumpCode(inputarray, new Dictionary<int, int>(), 0));

        }
    }
}
