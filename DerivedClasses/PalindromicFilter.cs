using System;
using FilterByPredicate;

namespace DerivedClasses
{
    /// <summary>
    /// Represents an class filter of the array on a given digit.
    /// </summary> 
    public class PalindromicFilter : Filter
    {
        protected override bool IsMatch(int item)
        {
            int div = (int)Math.Pow(10, GetNumLength(item) - 1);

            while (item != 0)
            {
                int firstDigit = item / div;
                int lastDigit = item % 10;

                if ((firstDigit != lastDigit) || (item < 0))
                {
                    return false;
                }

                item = (item % div) / 10;
                div /= 100;
            }

            return true;
        }

        static int GetNumLength(int num)
        {
            int length = 0;
            while (num != 0)
            {
                num /= 10;
                length++;
            }

            return length;
        }
    }
}
