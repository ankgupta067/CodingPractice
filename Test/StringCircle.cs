using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class StringCircle
    {
        public bool CircleExists(string[] ia, int n)
        {
            var visited = new bool[n];
            for (int i = 0; i < n; i++)
            {
                bool found = false;
                for (int j = 0; j < n; j++)
                {
                    if (!visited[j] && i != j)
                    {
                        if (ia[i][ia[i].Length -1] == ia[j][0])
                        {
                            visited[j] = true;
                            found = true;
                        }
                    }
                }
                if (!found)
                {
                    return false;
                }
            }
            return true;
        }

        public void Init()
        {
            var ia = new string[] { "ijk", "kji", "abc", "cba"};
            int n = 4;
            Console.WriteLine(CircleExists(ia, n));


        }
    }
}
