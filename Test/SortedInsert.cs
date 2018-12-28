using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class SortedInsert
    {
        public void Insert(ref int[] array,int i,int j,int item)
        {
            if (j-i <=0)
            {
                if (array[i] < item)
                {
                    InsertAt(ref array, i + 1, item);
                }else
                {
                    InsertAt(ref array, i, item);
                }
                return;
            }
            int pi = (i + j) / 2;
            if (item < array[pi])
            {
                Insert(ref array, i, pi - 1, item);
            }else  if(item > array[pi])
            {
                Insert(ref array, pi + 1, j, item);
            }
            else
            {
                InsertAt(ref array, pi + 1, item);
                return ;
            }
        }

        private void InsertAt(ref int[] array, int v, int item)
        {
            var array1 = new int[array.Length + 1];
            int j = 0;
            for (int i = 0; i < array.Length; i++ ,j++)
            {
                if (i == v)
                {
                    array1[j] = item;
                    array1[j + 1] = array[i];
                    j++;
                }
                else
                {
                    array1[j] = array[i];
                }                
            }
            if (v== array1.Length -1)
            {
                array1[v] = item;
            }
            array = array1;
        }
    }
}
