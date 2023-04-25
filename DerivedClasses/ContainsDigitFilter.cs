using System;
using FilterByPredicate;

namespace DerivedClasses
{
    /// <summary>
    /// Represents an class filter of the array on a given digit.
    /// </summary>
    public class ContainsDigitFilter : Filter
    {
        private int digit;

        /// <summary>
        /// Gets or sets a digit.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Digit more than 9 or less than 0.</exception>
        public int Digit
        {
            get => digit;
            set
            {
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Digit can not be less than zero or more then 9.");
                }
                digit = value;
            }
        }

        protected override  bool IsMatch(int item)
        {
            if (digit == 0 && item == 0)
            {
                return true;
            }

            while (item != 0)
            {
                item = (item < 0) ? -item : item;

                if (item % 10 == digit)
                {
                    return true;
                }

                item /= 10;
            }

            return false;
        }
    }
}
