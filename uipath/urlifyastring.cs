using System;
namespace uipath
{
    public class urlifyastring
    {
        public void Init()
        {
            Logic("i am ankush    ".ToCharArray());
        }

        public void Logic(char[] str)
        {

            int emptyindex = str.Length - 1;

            int currentvalueindex = str.Length - 1;

            while (str[currentvalueindex] == ' ')
            {
                currentvalueindex = currentvalueindex - 1;
            }

            for (int i = currentvalueindex; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    str[emptyindex] = '0';
                    str[emptyindex - 1] = '2';
                    str[emptyindex - 2] = '%';
                    emptyindex -= 3;
                }
                else
                {
                    str[emptyindex] = str[i];
                    emptyindex -= 1;
                }

            }

            Console.WriteLine(str);
        }
    }
}