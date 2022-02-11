// <copyright file="FibonacciTextReader.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Notepad.TextReader;

using System.IO;
using System.Collections.Concurrent;
using System.Numerics;
using System.Text;

/// <summary>
/// Initializes the <see cref="FibonacciTextReader"/> class.
/// </summary>
public class FibonacciTextReader : TextReader
{
    /// <summary>
    /// The storage for the fibonacci numbers for quick access.
    /// </summary>
    private static ConcurrentDictionary<int, BigInteger> fibonacciItems = new ConcurrentDictionary<int, BigInteger>();

    /// <summary>
    /// The current position in the fibonacci sequence.
    /// </summary>
    private int capacityLeft;

    /// <summary>
    /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
    /// </summary>
    /// <param name="capacity">The maximum number of lines available.</param>
    /// <exception cref="ArgumentException">Thrown when <see cref="Capacity"/> is less than three.</exception>
    public FibonacciTextReader(int capacity)
    {
        if (capacity < 3)
        {
            throw new ArgumentException("Capacity must be greater than or equal to 3.");
        }

        this.Capacity = capacity;
        this.capacityLeft = 0;
        if (fibonacciItems.Count < 3)
        {
            fibonacciItems.TryAdd(0, 0);
            fibonacciItems.TryAdd(1, 1);
            fibonacciItems.TryAdd(2, 1);
        }
    }

    /// <summary>
    /// Gets the limit of fibonacci numbers to be shown.
    /// </summary>
    public int Capacity
    {
        get;

        private set;
    }

    /// <summary>
    /// Calculates the Fibonacci number at <paramref name="n"/>.
    /// </summary>
    /// <param name="n">The index of which fibonacci to determine.</param>
    /// <returns>The nth fibonacci number or -1 if <paramref name="n"/> is less than 0.</returns>
    public static BigInteger FibonacciOf(int n)
    {
        if (n < 0)
        {
            return -1;
        }

        if (!fibonacciItems.ContainsKey(n))
        {
            fibonacciItems.TryAdd(n, FibonacciOf(n - 1) + FibonacciOf(n - 2));
        }

        return fibonacciItems[n];
    }

    /// <summary>
    /// Returns the next fibonacci number up to the specified capacity.
    /// </summary>
    /// <returns>The next fibonacci number in sequence or null if reached capacity.</returns>
    public override string? ReadLine()
    {
        if (this.Capacity <= this.capacityLeft)
        {
            return null;
        }

        this.capacityLeft++;
        return $"{this.capacityLeft - 1}: {FibonacciOf(this.capacityLeft - 1)}";
    }

/// <summary>
/// Returns the fibonacci numbers up to the specified capacity.
/// </summary>
/// <returns>The string of fibonacci numbers up to its capacity.</returns>
    public override string ReadToEnd()
    {
        StringBuilder sb = new StringBuilder();
        string? line;
        while ((line = this.ReadLine()) != null)
        {
            sb.AppendLine(line);
        }

        return sb.ToString();
    }
}