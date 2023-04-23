using System;
using System.Reflection.Metadata.Ecma335;

namespace ArrayExtension
{
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
        /// {1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17}  => { 7, 70, 17 } for digit = 7
        /// </example>
        public static int[] FilterByDigit(this int[]? source, int digit)
        {
            if(source is  null) throw new ArgumentNullException(nameof(source), "Array is null");
            if(source.Length == 0 ) throw new ArgumentException("Array is empty", nameof(source));
            if(digit < 0) throw new ArgumentOutOfRangeException(nameof(digit), "Digit can not be less than zero.");
            if(digit > 9) throw new ArgumentOutOfRangeException(nameof(digit), "Digit can not be more than nine.");
            
            List<int> result = new List<int>();
            
            foreach (int num in source)
            {
                if (IsMatch(num))
                    result.Add(num);
            }

            return result.ToArray();

            bool IsMatch(int value)
            {
                if (digit == 0 && value == 0) return true;

                while (value != 0)
                {
                    if(value < 0) value = -value;
                    if (value % 10 == digit) return true;
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
        /// {56, -1111111112, 987654, 56, 890, -1111, 543, 1233}  => {  }
        /// </example>
        public static int[] FilterByPalindromic(this int[]? source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source), "Array is null");
            if (source.Length == 0) throw new ArgumentException("Array is empty", nameof(source));

            List<int> result = new List<int>();

            foreach (int num in source)
            {
                if (IsMatch(num))
                    result.Add(num);
            }

            return result.ToArray();

            bool IsMatch(int value)
            {
                int leftPart = 0;
                int rightPart = 0;
                int numLength = GetNumLength(value);

                for (int i = 0; i < numLength / 2; i++)
                {
                    int digit = value % 10;
                    leftPart = leftPart * 10 + digit;
                    value /= 10;

                    digit = GetFirstDigit(value, numLength - 1);
                    rightPart = rightPart * 10 + digit;
                    value = RemoveFirstDigit(value, numLength - 1);
                    numLength -= 2;
                }

                return leftPart == rightPart;
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

            int GetFirstDigit(int num, int power)
            {
                while (power > 0)
                {
                    num /= 10;
                    power--;
                }
                return num % 10;
            }

            int RemoveFirstDigit(int num, int power)
            {
                int divisor = 1;
                while (power > 0)
                {
                    divisor *= 10;
                    power--;
                }
                return num % divisor;
            }
        }
    }
}
