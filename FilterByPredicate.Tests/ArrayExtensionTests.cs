using System;
using System.Linq;
using ArrayExtension;

namespace FilterByPredicate.Tests
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, ExpectedResult = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new[] { 717, 828, 45, 58, 881, 11711, 252 }, ExpectedResult = new[] { 717, 828, 11711, 252 })]
        [TestCase(new[] { 17, 82, 45, 58, 881, 117, 25 }, ExpectedResult = new int[] { })]
        [TestCase(new[] { 2212332, 0, 1405644, 12345, 1, -1236674, 123321, 1111111 }, ExpectedResult = new[] { 0, 1, 123321, 1111111 })]
        [TestCase(new[] { 1111111112, 987654, -24, 1234654321, 32, 1005 }, ExpectedResult = new int[] { })]
        [TestCase(new[] { -27, 987656789, 7557, int.MaxValue, 7556, 7243, 7243427, int.MinValue }, ExpectedResult = new[] { 987656789, 7557, 7243427 })]
        [TestCase(new[] { 111, 111, 111, 11111111 }, ExpectedResult = new[] { 111, 111, 111, 11111111 })]
        [TestCase(new[] { -1, 0, 111, -11, -1 }, ExpectedResult = new[] { 0, 111 })]
        [TestCase(new[] { 0, 1, 2, 3, 4 }, ExpectedResult = new[] { 0, 1, 2, 3, 4 })]
        public int[] FilterByPalindromicTests(int[] source) => source.FilterByPalindromic();

        [Test]
        public void FilterByPalindromic_ArrayIsEmpty_ThrowArgumentException() => Assert.Throws<ArgumentException>(
            () => Array.Empty<int>().FilterByPalindromic(), "Array cannot be empty.");

        [Test]
        public void FilterByPalindromic_ArrayIsNull_ThrowArgumentNullException() => Assert.Throws<ArgumentNullException>(
            () => ((int[])null!).FilterByPalindromic(), "Array cannot be null.");

        [Test]
        public void FilterByPalindromic_PerformanceTest()
        {
            const int sourceLength = 1_000_000;
            const int palindromic = 1_234_554_321;
            int[] source = Enumerable.Repeat(int.MaxValue, sourceLength).ToArray();
            const int count = 1_000_000, step = sourceLength / count;

            for (int i = 0; i < sourceLength; i += step)
            {
                source[i] = palindromic;
            }

            int[] expected = Enumerable.Repeat(palindromic, count).ToArray();
            int[] actual = source.FilterByPalindromic();
            CollectionAssert.AreEqual(expected, actual);
        }
        
        [TestCase(new[] { 2212332, 1405644, -1236674 }, 0, ExpectedResult = new[] { 1405644 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, 2, ExpectedResult = new[] { -24, 32 })]
        [TestCase(new[] { -27, 173, 371132, 7556, 7243, 10017, int.MinValue, int.MaxValue }, 7, ExpectedResult = new[] { -27, 173, 371132, 7556, 7243, 10017, int.MinValue, int.MaxValue })]
        [TestCase(new[] { -123, 123, 2202, 3333, 4444, 55055, 0, -7, 5402, 9, 0, -150, 287 }, 0, ExpectedResult = new[] { 2202, 55055, 0, 5402, 0, -150 })]
        [TestCase(new[] { -123, 123, 2202, 3333, 4444, 55055, 0, -7, 5402, 9, 0, -150, 287 }, 2, ExpectedResult = new[] { -123, 123, 2202, 5402, 287 })]
        [TestCase(new[] { -583, -7481, -24, -81001, -32, -10805 }, 8, ExpectedResult = new[] { -583, -7481, -81001, -10805 })]
        [TestCase(new[] { 111, 111, 111, 11111111 }, 1, ExpectedResult = new[] { 111, 111, 111, 11111111 })]
        [TestCase(new[] { -1, 0, 111, -11, -1 }, 1, ExpectedResult = new[] { -1, 111, -11, -1 })]
        [TestCase(new[] { int.MinValue, int.MinValue, int.MinValue, int.MaxValue, int.MaxValue }, 0, ExpectedResult = new int[] { })]
        public int[] FilterByDigit_WithCorrectDigits_ReturnNewArray(int[] source, int digit)
        {
            return source.FilterByDigit(digit);
        }

        [Test]
        public void FilterByDigit_ArrayIsEmpty_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Array.Empty<int>().FilterByDigit(2), "Array cannot be empty.");
        }

        [Test]
        public void FilterByDigit_ArrayIsNull_ThrowArgumentNullException()
        {
            int[] array = null!;
            Assert.Throws<ArgumentNullException>(() => array.FilterByDigit(4), "Array cannot be null.");
        }

        [Test]
        public void FilterByDigit_DigitLessZero_ThrowArgumentOutOfRangeException() => Assert.Throws<ArgumentOutOfRangeException>(
            () => Array.Empty<int>().FilterByDigit(-2), "Expected digit cannot be less than zero.");

        [Test]
        public void FFilterByDigit_DigitMoreThanNine_ThrowArgumentOutOfRangeException() => Assert.Throws<ArgumentOutOfRangeException>(
            () => Array.Empty<int>().FilterByDigit(12), "Expected digit cannot be out of range 0..9.");

        [Test]
        public void FilterByDigit_PerformanceTest()
        {
            const int sourceLength = 1_000_000,
                digit = 2,
                number = int.MaxValue;

            int[] source = new int[sourceLength];

            const int count = 1_000_000, step = sourceLength / count;

            for (int i = 0; i < sourceLength; i += step)
            {
                source[i] = number;
            }

            int[] expected = Enumerable.Repeat(number, count).ToArray();

            int[] actual = source.FilterByDigit(digit);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
