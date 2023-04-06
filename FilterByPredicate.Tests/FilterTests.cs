using System.Collections.Generic;
using FilterByDigitPredicate;
using FilterByPalindromicPredicate;

namespace FilterByPredicate.Tests
{
    [TestFixture]
    public class FilterTests
    {
        public static IEnumerable<TestCaseData> FiltersTestCases()
        {
            yield return new TestCaseData(
                new ContainsDigitFilter { Digit = 7 },
                new[] { -27, 173, 371132, 7556, 7243, 10017, int.MinValue, int.MaxValue },
                new[] { -27, 173, 371132, 7556, 7243, 10017, int.MinValue, int.MaxValue });
            yield return new TestCaseData(
                new ContainsDigitFilter { Digit = 1 },
                new[] { 111, 111, 111, 11111111 },
                new[] { 111, 111, 111, 11111111 });
            yield return new TestCaseData(
                new ContainsDigitFilter { Digit = 8 },
                new[] { -583, -7481, -24, -81001, -32, -10805 },
                new[] { -583, -7481, -81001, -10805 });
            yield return new TestCaseData(
                new ContainsDigitFilter { Digit = 0 },
                new[] { 2212332, 1405644, -1236674 },
                new[] { 1405644 });
            yield return new TestCaseData(
                new ContainsDigitFilter { Digit = 2 },
                new[] { 53, 71, -24, 1001, 32, 1005 }, 
                new[] { -24, 32 });
            yield return new TestCaseData(
                new ContainsDigitFilter { Digit = 0 },
                new[] { int.MinValue, int.MinValue, int.MinValue, int.MaxValue, int.MaxValue },
                new int[] { });
            yield return new TestCaseData(
                new PalindromicFilter(),
                new[] { 717, 828, 45, 58, 881, 11711, 252 }, 
                new[] { 717, 828, 11711, 252 });
            yield return new TestCaseData(
                new PalindromicFilter(),
                new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 
                new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            yield return new TestCaseData(
                new PalindromicFilter(),
                new[] { 17, 82, 45, 58, 881, 117, 25 }, 
                new int[] { });
            yield return new TestCaseData(
                new PalindromicFilter(),
                new[] { 2212332, 0, 1405644, 12345, 1, -1236674, 123321, 1111111 },
                new[] { 0, 1, 123321, 1111111 });
            yield return new TestCaseData(
                new PalindromicFilter(),
                new[] { -27, 987656789, 7557, int.MaxValue, 7556, 7243, 7243427, int.MinValue },
                new[] { 987656789, 7557, 7243427 });
            yield return new TestCaseData(
                new PalindromicFilter(),
                new[] { -1, 0, 111, -11, -1 }, 
                new[] { 0, 111 });
        }

        [TestCaseSource(nameof(FiltersTestCases))]
        public void SelectTests(Filter filter, int[] source, int[] expected)
        {
            CollectionAssert.AreEqual(expected, filter.Select(source));
        }
    }
}
