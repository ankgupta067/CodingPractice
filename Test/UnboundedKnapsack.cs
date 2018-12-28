using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Knapsack { 
        public struct KnapsackEntry : IComparable
        {
            public int Value { get; set; }
            public int Weight { get; set; }

            public int CompareTo(object obj)
            {
                if (obj is KnapsackEntry ks)
                {
                    var thisfraction = this.Value / this.Weight;
                    var ksfraction = ks.Value / ks.Weight;
                    if (thisfraction > ksfraction)
                    {
                        return 1;
                    }
                    else if (thisfraction < ksfraction)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                return -2;
            }
        }

        public int FillKnapsackUnbounded(List<KnapsackEntry> entries,int weight, int index)
        {
            if (weight == 0 || index == -1)
            {
                return 0;
            }
            if (entries[index].Weight >  weight)
            {
                return FillKnapsackUnbounded(entries, weight, index - 1);
            }
            Console.WriteLine($"Value : {entries[index].Value} Weight : {entries[index].Weight}");
            return entries[index].Value + FillKnapsackUnbounded(entries, weight - entries[index].Weight, 
                index);
        }

        public int FillKnapsack01(List<KnapsackEntry> entries, int weight, int index)
        {
            if (weight == 0 || index == -1)
            {
                return 0;
            }
            if (entries[index].Weight > weight)
            {
                return FillKnapsack01(entries, weight, index - 1);
            }
            return Math.Max(entries[index].Value + FillKnapsack01(entries, weight - entries[index].Weight,
                index - 1), FillKnapsack01(entries,weight,index-1));
        }

        public void Init()
        {
            var entries = new List<KnapsackEntry>();
            entries.Add(new KnapsackEntry() { Value = 60, Weight = 10 });
            entries.Add(new KnapsackEntry() { Value = 100, Weight = 20});
            entries.Add(new KnapsackEntry() { Value = 120, Weight = 30 });
            Console.WriteLine(FillKnapsack01(entries, 50, entries.Count - 1));
        }
    }
}
