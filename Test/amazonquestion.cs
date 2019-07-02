using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	class amazonquestion
	{
		static void heapify(int[] arr, int n, int i)
		{
			int smallest = i; // Initialize largest as root  
			int l = 2 * i + 1; // left = 2*i + 1  
			int r = 2 * i + 2; // right = 2*i + 2  

			// If left child is larger than root  
			if (l < n && arr[l] < arr[smallest])
				smallest = l;

			// If right child is larger than largest so far  
			if (r < n && arr[r] < arr[smallest])
				smallest = r;

			// If largest is not root  
			if (smallest != i)
			{
				int swap = arr[i];
				arr[i] = arr[smallest];
				arr[smallest] = swap;

				// Recursively heapify the affected sub-tree  
				heapify(arr, n, smallest);
			}
		}

		static void buildHeap(int[] arr, int n)
		{
			// Index of last non-leaf node  
			int startIdx = (n / 2) - 1;

			// Perform reverse level order traversal  
			// from last non-leaf node and heapify  
			// each node  
			for (int i = startIdx; i >= 0; i--)
			{
				heapify(arr, n, i);
			}
		}

		public static int findmin(int[] arr, int n)
		{
			int totaltime = 0;
			while (true)
			{
				var getfirstvalue = arr[0];
				if (getfirstvalue == int.MaxValue)
				{
					return totaltime;
				}
				arr[0] = int.MaxValue;
				heapify(arr, n, 0);
				var getsecondvalue = arr[0];
				if (getsecondvalue == int.MaxValue)
				{
					return totaltime;
				}
				totaltime += getfirstvalue + getsecondvalue;
				arr[0] = getfirstvalue + getsecondvalue;
				heapify(arr, n, 0);
			}
		}

		public int minimumTime(int numOfParts, int[] parts)
		{
			return findmin(parts, numOfParts); ;
		}
		public void Init()
		{
			int[] arr = { 20,4,8,2 };

			int n = arr.Length;
			buildHeap(arr, n);
			Console.WriteLine(findmin(arr, n));
		}
	}
}
