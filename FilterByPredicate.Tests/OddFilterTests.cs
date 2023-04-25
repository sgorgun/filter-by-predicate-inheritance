using System;
using System.Linq;
using DerivedClasses;

namespace FilterByPredicate.Tests;

[TestFixture]
public class OddFilterTests
{
    [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, ExpectedResult = new[] { 1, 3, 5, 7, 9 })]
    [TestCase(new[] { 717, 828, 45, 58, 881, 11711, 252 }, ExpectedResult = new[] { 717, 45, 881, 11711 })]
    [TestCase(new[] { 17, 82, 45, 58, 881, 117, 25 }, ExpectedResult = new[] { 17, 45, 881, 117, 25 })]
    [TestCase(new[] { 1111111112, 987654, -24, 1234654321, 32, 1005 }, ExpectedResult = new[] { 1234654321, 1005 })]
    [TestCase(new[] { 0, 1, 2, 3, 4 }, ExpectedResult = new[] { 1, 3 })]

    public int[] Select_OddVerifyTests(int[] source) => new OddFilter().Select(source);

    [Test]
    public void Select_ArrayIsEmpty_ThrowArgumentException() => Assert.Throws<ArgumentException>(
               () => new OddFilter().Select(Array.Empty<int>()), "Array cannot be empty.");
    [Test]
    public void Select_ArrayIsNull_ThrowArgumentNullException() => Assert.Throws<ArgumentNullException>(
               () => new OddFilter().Select(null), "Array cannot be null.");
}

