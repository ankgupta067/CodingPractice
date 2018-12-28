using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class RectangleBoxStacking
    {
        public int MaxHeight(Dictionary<int,int> dict,int baseWidth, Dictionary<int, int> mem)
        {
            int maxheightyet = 0;
            foreach (var item in dict)
            {
                if (item.Key < baseWidth)
                {
                    //if (mem.ContainsKey(item.Key))
                    //{
                    //    int maxheight = item.Value + mem[item.Key];
                    //    if (maxheight > maxheightyet)
                    //    {
                    //        maxheightyet = maxheight;
                    //    }
                    //}
                    //else
                    {
                        int maxheight = item.Value + MaxHeight(dict, item.Key, mem);
                        if (maxheight > maxheightyet)
                        {
                            maxheightyet = maxheight;
                        }
                    }
                }
            }
            mem[baseWidth] = maxheightyet;
            return maxheightyet;
        }
        public void Init()
        {
            var dict = new Dictionary<int, int>();
            var boxes = new List<Box>();
            //boxes.Add(new Box { Height = 4, Width = 6, Length = 7 });
            //boxes.Add(new Box { Height = 1, Width = 2, Length = 3 });
            //boxes.Add(new Box { Height = 4, Width = 5, Length = 6 });
            //boxes.Add(new Box { Height = 10, Width = 12, Length = 32 });
            boxes.Add(new Box { Height = 1, Width = 2, Length = 3 });
            boxes.Add(new Box { Height = 4, Width = 5, Length = 6 });
            boxes.Add(new Box { Height = 3, Width = 4, Length = 1 });
            foreach (var box in boxes)
            {
                SetDictEntry(dict, box.Height * box.Length,box.Width);
                SetDictEntry(dict, box.Height * box.Width, box.Length);
                SetDictEntry(dict, box.Width * box.Length, box.Height);
            }
            Console.WriteLine(MaxHeight(dict, int.MaxValue, new Dictionary<int, int>()));
        }

        private static void SetDictEntry(Dictionary<int, int> dict, int dictentry, int value)
        {
            if (dict.ContainsKey(dictentry))
            {
                if (dict[dictentry] < value)
                {
                    dict[dictentry] = value;
                }
            }
            else
            {
                dict[dictentry] = value;
            }
        }

        class Box
        {
            public int Height { get; set; }
            public int Width { get; set; }
            public int Length { get; set; }
        }
    }
}
