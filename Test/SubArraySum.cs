using System;
using System.Collections.Generic;

namespace Test
{
	public class GFG
	{
		public void Init()
		{
			int[] arr = new int[] { 1, 4, 20, 3, 10, 5 };
			int n = arr.Length;
			int sum = -10;
			subArraySum(arr, n, sum);
		}

		public static void subArraySum(int[] arr, int n, int sum)
		{
			//cur_sum to keep track of cummulative sum till that point  
			int cur_sum = 0;
			int start = 0;
			int end = -1;
			Dictionary<int, int> hashMap = new Dictionary<int, int>();

			for (int i = 0; i < n; i++)
			{
				cur_sum = cur_sum + arr[i];
				//check whether cur_sum - sum = 0, if 0 it means  
				//the sub array is starting from index 0- so stop  
				if (cur_sum - sum == 0)
				{
					start = 0;
					end = i;
					break;
				}
				//if hashMap already has the value, means we already   
				// have subarray with the sum - so stop  
				if (hashMap.ContainsKey(cur_sum - sum))
				{
					start = hashMap[cur_sum - sum] + 1;
					end = i;
					break;
				}
				//if value is not present then add to hashmap  
				hashMap[cur_sum] = i;

			}
			// if end is -1 : means we have reached end without the sum  
			if (end == -1)
			{
				Console.WriteLine("No subarray with given sum exists");
			}
			else
			{
				Console.WriteLine("Sum found between indexes " + start + " to " + end);
			}

		}

		
	}
}
