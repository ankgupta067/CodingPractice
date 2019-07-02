using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class ArrayByFrequency
	{
		public void Init()
		{
			SortByFrequency(new int[] { 5, 5, 4, 6, 4 });
		}

		public class Entry : IComparable
		{
			public int key { get; set; }
			public int frequency { get; set; }
			public int CompareTo(object obj)
			{
				if (obj is Entry e)
				{
					if (this.frequency > e.frequency)
					{
						return -1;
					}
					else if (this.frequency < e.frequency)
					{
						return 1;
					}
					if (this.key > e.key)
					{
						return 1;
					}
					else if (this.key < e.key)
					{
						return -1;
					}
					return 0;
				}
				throw new ArgumentException();
			}
		}

		private void SortByFrequency(int[] inputarray)
		{
			var dict = new Dictionary<int, Entry>();
			for (int i = 0; i < inputarray.Length; i++)
			{
				if (dict.ContainsKey(inputarray[i]))
				{
					dict[inputarray[i]].frequency += 1;
				}
				else
				{
					dict[inputarray[i]] = new Entry() { frequency = 1, key = inputarray[i] };
				}
			}
			var list = new List<Entry>();
			list.AddRange(dict.Values);
			list.Sort();

		}
	}
}
