namespace Test
{
	public class MinHeap
	{
		int[] items = new int[20];

		public int Count { get; set; } = 0;

		public void RemoveRoot()
		{
			RemoveItem(1);
		}
		public void addItem(int item)
		{
			Count = Count + 1;
			if (Count > items.Length - 1)
			{
				var newitems = new int[items.Length * 2];
				for (int i = 0; i < items.Length; i++)
				{
					newitems[i] = items[i];
				}
				items = newitems;
			}

			items[Count] = item;
			var currcount = Count;
			while (currcount > 1)
			{
				if (items[currcount / 2] > items[currcount])
				{
					swap(currcount / 2, currcount);
					currcount = currcount / 2;
				}
				else
				{
					break;
				}
			}
		}

		public int GetRoot()
		{
			return GetItem(1);
		}

		private int GetItem(int index)
		{
			if (index <= Count)
			{
				return items[index];
			}
			return 0;
		}

		public void RemoveItem(int index)
		{
			swap(Count, index);
			Count = Count - 1;
			heapify(index);
		}

		private void heapify(int index)
		{
			int nextindex = 0;
			if (2 * index > Count)
			{
				return;
			}
			if (2 * index + 1 > Count)
			{
				nextindex = 2 * index;
			}
			if (items[2 * index] < items[(2 * index) + 1])
			{
				nextindex = 2 * index;
			}
			else
			{
				nextindex = 2 * index + 1;
			}
			if (items[index] > items[nextindex])
			{
				swap(index, nextindex);
				index = nextindex;
				heapify(index);
			}
		}

		private void swap(int v, int currcount)
		{
			int temp = items[v];
			items[v] = items[currcount];
			items[currcount] = temp;
		}
	}
}
