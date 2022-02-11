// <copyright file="FibonacciTextReaderTests.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Notepad.Test;

using System;
using NUnit.Framework;
using Notepad.TextReader;
using System.Numerics;

/// <summary>
/// Initializes the <see cref="FibonacciTextReaderTests"/> class.
/// </summary>
public class FibonacciTextReaderTests
{
    /// <summary>
    /// Tests to ensure the correct fibonacci number is returned.
    /// There is no limitation for capcity when using this function.
    /// Capacity is only used when writing to a Stream.
    /// </summary>
    /// <param name="n">The nth Fibonacci.</param>
    /// <param name="expectedStr">
    /// The expected result of nth Fibonacci sequence. The expected value
    /// is passed as a string to compensate for the BigInteger.
    /// </param>
    [Test]
    [TestCase(-100, "-1")]
    [TestCase(-1, "-1")]
    [TestCase(0, "0")]
    [TestCase(1, "1")]
    [TestCase(2, "1")]
    [TestCase(50, "12586269025")]
    [TestCase(100, "354224848179261915075")]
    public void TestFibonacciOf(in int n, string expectedStr)
    {
        BigInteger expected = BigInteger.Parse(expectedStr.ToString());
        BigInteger actual = FibonacciTextReader.FibonacciOf(n);
        Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Ensures the correct exception is thrown if an incorrect capacity is passed.
    /// </summary>
    /// <param name="capacity">The capacity to pass to FibonacciTextReader.</param>
    [Test]
    [TestCase(-100)]
    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    public void TestConstructorException(int capacity)
    {
        Assert.Throws<ArgumentException>(() => new FibonacciTextReader(capacity));
    }

    /// <summary>
    /// Ensures the correct capacity is given to the <see cref="FibonacciTextReader"/> class.
    /// </summary>
    /// <param name="capacity">The capacity of fibonacci numbers it may output.</param>
    [Test]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(50)]
    [TestCase(100)]
    public void TestConstructorPass(int capacity)
    {
        FibonacciTextReader fibonacciTextReader = new FibonacciTextReader(capacity);
        Assert.AreEqual(capacity, fibonacciTextReader.Capacity);
    }

    /// <summary>
    /// This test exclusively tests the output string outputs the result of the
    /// <see cref="FibonacciTextReader.FibonacciOf(int)"/> method along with the
    /// nth fibonacci result it is attached to. In additions, it ensures it only has
    /// the fibonacci numbers up to the capacity it was given.
    /// </summary>
    /// <param name="capacity">The total number of fibonacci values to output.</param>
    [Test]
    [TestCase(3)]
    [TestCase(25)]
    [TestCase(100)]
    public void TestReadLine(int capacity)
    {
        FibonacciTextReader fibonacciTextReader = new FibonacciTextReader(capacity);
        for (int i = 0; i < capacity; ++i)
        {
            string content = fibonacciTextReader.ReadLine() ?? "ReadLine() returned null.";
            BigInteger expected = FibonacciTextReader.FibonacciOf(i);
            Assert.AreEqual($"{i}: {expected}", content);
        }

        Assert.IsNull(fibonacciTextReader.ReadLine());
    }

    /// <summary>
    /// Ensures each line of the <see cref="FibonacciTextReader.ReadToEnd"/> method
    /// lists each nth fibonacci along with its <see cref="FibonacciTextReader.FibonacciOf(int)"/>
    /// result.
    /// </summary>
    /// <param name="capacity">The number of fibonacci numbers to calculate.</param>
    [Test]
    [TestCase(3)]
    [TestCase(25)]
    [TestCase(100)]
    public void TestReadToEnd(int capacity)
    {
        FibonacciTextReader fibonacciTextReader = new FibonacciTextReader(100);
        string content = fibonacciTextReader.ReadToEnd();
        string[] lines = content.Split("\r\n");

        for (int i = 0; i < capacity; ++i)
        {
            BigInteger expected = FibonacciTextReader.FibonacciOf(i);
            Assert.AreEqual($"{i}: {expected}", lines[i]);
        }
    }
}