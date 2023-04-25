using NUnit.Framework;
using DerivedClasses;
using System.Reflection;

namespace FilterByPredicate.Tests;

[TestFixture]
public class PositiveFilterTests
{
    [TestCase(new[] { 1, -2, 3, -4, 5, 6, -7, 8, -9 }, ExpectedResult = new[] { 1, 3, 5, 6, 8 })]
    [TestCase(new[] { 717, -828, 45, 58, -881, 11711, -252 }, ExpectedResult = new[] { 717, 45, 58, 11711 })]
    [TestCase(new[] { 2212332, 0, 1405644, 12345, 1, -1236674, 123321, 1111111 }, ExpectedResult = new[] { 2212332, 1405644, 12345, 1, 123321, 1111111 })]
    [TestCase(new[] { 1111111112, 987654, -24, 1234654321, 32, 1005 }, ExpectedResult = new[] { 1111111112, 987654, 1234654321, 32, 1005 })]
    [TestCase(new[] { -27, -987656789, 7557, int.MaxValue, 7556, 7243, 7243427, int.MinValue }, ExpectedResult = new[] { 7557, 2147483647, 7556, 7243, 7243427 })]
    [TestCase(new[] { -1, 0, 111, -11, -1 }, ExpectedResult = new[] { 111 })]
    public int[] Select_PalindromicVerifyTests(int[] source) => new PositiveFilter().Select(source);

    [Test]
    public void Select_ArrayIsEmpty_ThrowArgumentException() => Assert.Throws<ArgumentException>(
        () => new PositiveFilter().Select(Array.Empty<int>()), "Array cannot be empty.");

    [Test]
    public void Select_ArrayIsNull_ThrowArgumentNullException() => Assert.Throws<ArgumentNullException>(
        () => new PositiveFilter().Select(null), "Array cannot be null.");
}
