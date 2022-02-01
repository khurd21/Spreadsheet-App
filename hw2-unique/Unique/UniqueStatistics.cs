// <copyright file="UniqueStatistics.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Unique;

using System.Collections.Generic;
using System;

/// <summary>
/// A class to determine the number of unique integers in an array.
/// This is implemented in three different ways:
/// 1. Using a HashSet. This gives O(n) time and O(n) space.
/// 2. Simply iterating. This gives O(n^2) time and O(1) space.
/// 3. By sorting. This gives O(n log n) time and O(n) space.
///    If we ignore the sorted functionality, this gives O(n) time and no
///    additional space is needed.
/// </summary>
public class UniqueStatistics
{
    private List<int> array;

    /// <summary>
    /// Constructor for UniqueStatistics class.
    /// </summary>
    /// <param name="size">The capacity for the List.</param>
    /// <param name="max">The threshold value to be generated [0,max].</param>
    /// <param name="init">If true, randomly initialize array, otherwise leave empty.</param>
    public UniqueStatistics(int size = 10, int max = 20000, bool init = true)
    {
        this.array = new List<int>(size);
        if (init == true)
        {
            this.RandomlyInitializeArray(size, max);
        }
    }

    /// <summary>
    /// An accessor for the private List array.
    /// </summary>
    /// <returns>this.array</returns>
    public List<int> Array
    {
        get
        {
            return this.array;
        }

        // internal is used for testing purposes only.
        internal set
        {
            this.array = value;
        }
    }

    /// <summary>
    /// Initializes the array of <c>size</c> with random values
    /// between 0 and <c>max</c>.
    /// </summary>
    /// <param name="size">The capacity of the array.</param>
    /// <param name="max">The max threshold [0, max].</param>
    private void RandomlyInitializeArray(int size, int max)
    {
    }

    /// <summary>
    /// Returns the number of unique values in the array.
    /// Implemented by using a HashSet to store the unique values.
    /// The number of items in the set will be the number of unique values.
    /// </summary>
    /// <returns>The number of distinct values within <c>this.array</c>.</returns>
    public static int DistinctIntegersHashSet(List<int> array)
    {
        return int.MaxValue;
    }

    /// <summary>
    /// Returns the number of unique values in the array.
    /// Implemented by using this.array and not introducing any additional
    /// space that is not a constant.
    /// </summary>
    /// <returns>The number of distinct values within <c>this.array</c>.</returns>
    public static int DistinctIntegersList(List<int> array)
    {
        return int.MaxValue;
    }

    /// <summary>
    /// Returns the number of unique values in the array.
    /// Implemented by first sorting the array and then counting the number
    /// of unique values.
    /// </summary>
    /// <returns>The number of distinct values within <c>this.array</c>.</returns>
    public static int DistinctIntegersSorted(List<int> array)
    {
        return int.MaxValue;
    }
}