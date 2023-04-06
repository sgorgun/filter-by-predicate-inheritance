using System;
using FilterByPredicate;

namespace FilterByDigit
{
    /// <summary>
    /// Represents an class filter of the array on a given digit.
    /// </summary>
    public class ContainsDigitFilter : Filter
    {
        /// <summary>
        /// Gets or sets a digit.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Digit more than 9 or less than 0.</exception>
        public int Digit
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        
        protected override bool IsMatch(int item)
        {
            throw new NotImplementedException();
        }
    }
}
