// <copyright file="UniqueTest.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>
namespace Unique.Test;

using NUnit.Framework;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Unique;

/// <summary>
/// Test class for UniqueStatistics.
/// </summary>
public class TestUniqueStatistics
{
    /// <summary>
    /// Test inputs for the DinsinctIntegers Methods.
    /// Consists of three test cases in which the results are compared to each static
    /// method of the UniqueStatistics.DistinctIntegers... class.
    /// </summary>
    private static readonly object[] TestCases =
    {
        new object[] { new List<int> { 1, 1, 2, 2, 3, 4, 4 }, 1, (object)UniqueStatistics.DistinctIntegersHashSet },
        new object[] { new List<int> { 1, 2, 3, 4, 5, 6 },     6, (object)UniqueStatistics.DistinctIntegersHashSet },
        new object[] { new List<int> { 1, 1, 1, 1, 1, 1, 1 },  0, (object)UniqueStatistics.DistinctIntegersHashSet },
        new object[] { new List<int> { 1, 1, 2, 2, 3, 4, 4 },  1, (object)UniqueStatistics.DistinctIntegersList },
        new object[] { new List<int> { 1, 2, 3, 4, 5, 6 },     6, (object)UniqueStatistics.DistinctIntegersList },
        new object[] { new List<int> { 1, 1, 1, 1, 1, 1, 1 },  0, (object)UniqueStatistics.DistinctIntegersList },
        new object[] { new List<int> { 1, 1, 2, 2, 3, 4, 4 }, 1, (object)UniqueStatistics.DistinctIntegersSorted },
        new object[] { new List<int> { 1, 2, 3, 4, 5, 6 },     6, (object)UniqueStatistics.DistinctIntegersSorted },
        new object[] { new List<int> { 1, 1, 1, 1, 1, 1, 1 },  0, (object)UniqueStatistics.DistinctIntegersSorted },
    };

    /// <summary>
    /// Tests the constructor of Unique class. The constructor should
    /// initialize the array with the given size and max value.
    /// This test ensures the array is initialized with the correct
    /// size and max value.
    /// </summary>
    /// <param name="size">Capacity of the List.</param>
    /// <param name="max">Maximum size of the number to be generated.</param>
    [Test]
    [TestCase(1, 1)]
    [TestCase(100, 2)]
    [TestCase(1000, 0)]
    [TestCase(10000, 20000)]
    public void TestUniqueConstructor(int size, int max)
    {
        UniqueStatistics stats = new UniqueStatistics(size: size, max: max);
        Assert.AreEqual(stats.Array.Count, size);
        Parallel.ForEach<int>(stats.Array, val =>
        {
            Assert.IsTrue(val <= max);
            Assert.IsTrue(val >= 0);
        });
    }

    /// <summary>
    /// Tests the DistinctIntegersHashSet method. Takes a list of known
    /// amount of unique integers inside as a comparison.
    /// </summary>
    /// <param name="input">The list to calculate the number of distinct numbers.</param>
    /// <param name="expected">The expected result of unique numbers.</param>
    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void TestDistinctIntegersHashSet(List<int> input, int expected, Func<List<int>, int> method)
    {
        Assert.AreEqual(expected, method(input));
    }
}