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

        byte GetNumLength(int number) => number switch
        {
            int.MinValue => 10,
            < 0 => GetNumLength(Math.Abs(number)),
            < 10 => 1,
            < 100 => 2,
            < 1000 => 3,
            < 10_000 => 4,
            < 100_000 => 5,
            < 1_000_000 => 6,
            < 10_000_000 => 7,
            < 100_000_000 => 8,
            < 1_000_000_000 => 9,
            _ => 10
        };
    }
}
