using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _08._Custom_Comparator
{
    class SortEvenFirst : IComparer
    {
        public int Compare(object x, object y)
        {
            if ((int)x % 2 == 0 && (int)y % 2 == 0 && (int)x > (int)y)
            {
                return 1;
            }
            else if ((int)x % 2 == 0 && (int)y % 2 == 0 && (int)x < (int)y)
            {
                return -1;
            }
            else if ((int)x % 2 == 0 && (int)y % 2 == 0 && (int)x == (int)y)
            {
                return 0;
            }
            else if ((int)x % 2 != 0 && (int)y % 2 != 0 && (int)x < (int)y)
            {
                return -1;
            }
            else if ((int)x % 2 != 0 && (int)y % 2 != 0 && (int)x > (int)y)
            {
                return 1;
            }
            else if ((int)x % 2 != 0 && (int)y % 2 != 0 && (int)x == (int)y)
            {
                return 0;
            }
            else if ((int)x % 2 == 0 && (int)y % 2 != 0)
            {
                return -1;
            }
            else if ((int)x % 2 != 0 && (int)y % 2 == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
