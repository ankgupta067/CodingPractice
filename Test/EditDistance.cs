using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class EditDistance
    {
        public int EditDistanceLogic(string str1, string str2,int n, int m,int[,]mem)
        {
            
            if(n== -1)
            {
                return m +1;
            }
            if (m== -1)
            {
                return n + 1;
            }
            if (mem[n, m] != -1)
            {
                return mem[n, m];
            }
            if (str1[n] == str2[m])
            {
                var result =  EditDistanceLogic(str1, str2, n - 1, m - 1,mem);
                mem[n,m] = result;
                return result;
            }
            var result1 =  1 + Math.Min(Math.Min(EditDistanceLogic(str1, str2, n, m - 1,mem),EditDistanceLogic(str1, str2, n - 1, m - 1,mem)), 
                EditDistanceLogic(str1, str2, n - 1, m,mem));
            return result1;
        }

        public void Init()
        {
            var str1 = "Saturday";
            var str2 = "Sunday";
            var mem = new int[str1.Length,str2.Length];
            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    mem[i,j] = -1;
                }
            }
            Console.WriteLine(EditDistanceLogic(str1, str2, str1.Length - 1, str2.Length - 1,mem));
        }
    }
}
