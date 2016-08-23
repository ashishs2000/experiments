using System.Collections.Generic;

namespace Algorithms
{
    public class QuickSort
    {
        public void Sort(int first, int last, int pivotelement,List<int?> items)
        {
            var left = first;
            var right = last;
            items[left] = null;
            while (left != right)
            {
                var rightitem = items[right];
                if (rightitem.HasValue)
                {
                    if (pivotelement < rightitem)
                    {
                        //move right pointer to center
                        right = right - 1;
                        continue;
                    }
                    items[left] = items[right];
                    items[right] = null;
                    left = left + 1;
                    continue;
                }

                var leftitem = items[left];
                if (pivotelement > leftitem)
                {
                    left = left + 1;
                }
                items[right] = items[left];
                items[left] = null;
                right = right - 1;
            }

            items[left] = pivotelement;
            if (left - 1 != first)
                Sort(0, left - 1, items[0].Value, items);

            if (right + 1 != last &&  right + 1 < last)
                Sort(right + 1, last, items[right + 1].Value, items);
        }
    }
}