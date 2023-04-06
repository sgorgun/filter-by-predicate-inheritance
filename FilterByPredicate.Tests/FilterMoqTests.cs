using System;
using System.Linq;
using Moq;
using Moq.Protected;

namespace FilterByPredicate.Tests
{
    [TestFixture]
    public class FilterMoqTests
    {
        [Test]
        public void FilterStateTest()
        {
            var mockFilter = new Mock<Filter>();

            mockFilter.Protected()
                .Setup<bool>("IsMatch", ItExpr.Is<int>(i => Contains(i, 1)))
                .Returns(true);

            Filter filter = mockFilter.Object;

            var source = new[] { 11, 121, 31, 20, 33, 56, 234, -231, 678 };

            var expected = new[] { 11, 121, 31, -231 };

            var actual = filter.Select(source);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterBehaviourTest()
        {
            var mockFilter = new Mock<Filter>();

            mockFilter.Protected()
                .Setup<bool>("IsMatch", ItExpr.IsAny<int>())
                .Returns(true);

            Filter filter = mockFilter.Object;

            int count = 1000;

            var source = Enumerable.Range(1, count).ToArray();

            filter.Select(source);

            mockFilter.Protected().Verify("IsMatch", Times.Exactly(count), ItExpr.IsAny<int>());
        }

        private static bool Contains(int number, int digit)
        {
            int tmp = Math.Abs(number);

            while (tmp / 10 != 0)
            {
                if (tmp % 10 == digit)
                {
                    return true;
                }

                tmp /= 10;
            }

            return tmp % 10 == digit;
        }
    }
}
