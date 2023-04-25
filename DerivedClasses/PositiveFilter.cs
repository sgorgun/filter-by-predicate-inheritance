using System;
using FilterByPredicate;

namespace DerivedClasses
{
    public class PositiveFilter : Filter
    {
        protected override bool IsMatch(int item)
        {
            return item > 0;
        }
    }
}
