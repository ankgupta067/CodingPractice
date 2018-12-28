using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class QuickSort<T> where T:IComparable
    {
        private int Partition(T[] array,int i,int j)
        {
            var pivotindex = j;
            while(i < j)
            {
                while(array[i].CompareTo(array[pivotindex]) < 0)
                {
                    i += 1;
                }
                while(j >0 && array[j].CompareTo(array[pivotindex]) >= 0)
                {
                    j -= 1;
                }
                if (i < j)
                {
                    swap(array, i, j);
                }
            }
            swap(array, i, pivotindex);
            return i;
        }

        public void Sort(T[] array,int i,int j)
        {
            if(j-i <= 0)
            {
                return;
            }
            var newindex = Partition(array, i, j);
            Sort(array, i, newindex - 1);
            Sort(array, newindex + 1, j);
        }
        private void swap(T[] array, int i, int pivotindex)
        {
            var temp = array[i];
            array[i] = array[pivotindex];
            array[pivotindex] = temp;
        }
    }
}
