using System;
using System.Reflection.Metadata.Ecma335;

namespace ArrayExtension
{
    /// <summary>
    /// Common class with all the methods.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Returns new array of elements that contain expected digit from source array.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <param name="digit">Expected digit.</param>
        /// <returns>Array of elements that contain expected digit.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when digit value is out of range (0..9).</exception>
        /// <example>
        /// {1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17}  => { 7, 70, 17 } for digit = 7.
        /// </example>
        public static int[] FilterByDigit(this int[]? source, int digit)
        {
            if (digit is < 0 or > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), "Digit can not be less than zero or more then 9.");
            }

            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Array is null");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("Array is empty", nameof(source));
            }
            
            List<int> result = new List<int>();
            
            foreach (int num in source)
            {
                if (IsMatch(num))
                {
                    result.Add(num);
                }
            }

            return result.ToArray();

            bool IsMatch(int value)
            {
                if (digit == 0 && value == 0)
                {
                    return true;
                }

                while (value != 0)
                {
                    value = (value < 0) ? -value : value;

                    if (value % 10 == digit)
                    {
                        return true;
                    }

                    value /= 10;
                }

                return false;
            }
        }
        
        /// <summary>
        /// Returns new array that contains only palindromic numbers from source array.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Array of elements that are palindromic numbers.</returns>
        /// <exception cref="ArgumentNullException">Throw when array is null.</exception>
        /// <exception cref="ArgumentException">Throw when array is empty.</exception>
        /// <example>
        /// {12345, 1111111112, 987654, 56, 1111111, -1111, 1, 1233321, 70, 15, 123454321}  => { 1111111, 123321, 123454321 }
        /// {56, -1111111112, 987654, 56, 890, -1111, 543, 1233}  => {  }.
        /// </example>
        public static int[] FilterByPalindromic(this int[]? source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Array is null");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("Array is empty", nameof(source));
            }

            List<int> result = new List<int>();

            foreach (int num in source)
            {
                if (IsMatch(num))
                {
                    result.Add(num);
                }
            }

            return result.ToArray();

            bool IsMatch(int value)
            {
                int div = (int)Math.Pow(10, GetNumLength(value) - 1);

                while (value != 0)
                {
                    int firstDigit = value / div;
                    int lastDigit = value % 10;

                    if ((firstDigit != lastDigit) || (value < 0))
                    {
                        return false;
                    }

                    value = (value % div) / 10;
                    div /= 100;
                }

                return true;
            }

            int GetNumLength(int num)
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
}
