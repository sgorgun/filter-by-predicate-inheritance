using System;
using FilterByPredicate;

namespace DerivedClasses
{
    public class OddFilter : Filter
    {
        protected override bool IsMatch(int item)
        {
            return item % 2 != 0;
        }
    }
}
