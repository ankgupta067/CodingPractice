using System;
using System.Threading;
using Test.Trie;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
			//Console.WriteLine("first");
			//var timer = new Timer(TimerCallbackFunc, null, 0, 0);
			//Console.WriteLine("last");
			//var qs = new QuickSort<int>();
			//var inputarray = new int[] { 4,8,3,7,2,9,8 };
			//qs.Sort(inputarray, 0,inputarray.Length-1);
            new CoinChange().Init();
            Console.Read();

        }

        private static void TimerCallbackFunc(object state)
        {
            Console.WriteLine("second");
        }
    }
}
