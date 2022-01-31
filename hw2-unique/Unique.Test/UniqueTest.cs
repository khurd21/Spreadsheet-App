/// <summary>
/// Unit tests for Unique class.
/// </summary>
/// <copyright file="UniqueTest.cs" company="WSU Cpts 321"></copyright>

namespace Unique.Test;

using NUnit.Framework;
using System.Threading.Tasks;
using Unique;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

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
    public void TestUniqueConstructor(uint size, uint max)
    {
        UniqueStatistics stats = new UniqueStatistics(size: size, max: max);
        Assert.AreEqual(stats.Array.Count, size);
        Parallel.ForEach<uint>(stats.Array, val =>
        {
            Assert.IsTrue(val <= max);
            Assert.IsTrue(val >= 0);
        });
    }
}