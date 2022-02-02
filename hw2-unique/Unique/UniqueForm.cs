// <copyright file="UniqueForm.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Unique.Forms;

using System.Text;

/// <summary>
/// The main form for the application.
/// </summary>
public partial class UniqueForm : Form
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UniqueForm"/> class.
    /// </summary>
    public UniqueForm()
    {
        this.InitializeComponent();
    }

    /// <summary>
    /// Handles the Click event of the btnUnique control.
    /// </summary>
    /// <param name="sender">Reference of object that raised event.</param>
    /// <param name="e">Event Arguments.</param>
    private void UniqueForm_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        UniqueStatistics stats = new UniqueStatistics(size: 10000, max: 20000);

        sb.AppendFormat(
            "Distinct Integers (HashSet): {0}" + Environment.NewLine,
            UniqueStatistics.DistinctIntegersHashSet(stats.Array));
        sb.Append("The time complexity for this method is O(n) and the space " +
                    "complexity is O(n). This is because the HashSet is " +
                    "storing all elements in the array that are unique. " +
                    "This means, if all items in the array are unique, " +
                    "the HashSet will end up storing all items from the array. " +
                    "For the time complexity, There only needs to be one " +
                    "iteration through the array, making the time to complete dependent " +
                    "on the size of the input. Within single iteration of the array, " +
                    "we rely on the HashSet.Add() Function. The lookup from this function " +
                    "is based on the size of the key, not the size of its inputs. Therefore, " +
                    "HashSet.Add() is performed in constant time. Accessing the number of items in the " +
                    "HashSet can be done in constant time as well. " + Environment.NewLine);
        sb.AppendFormat(
            "Distinct Integers (Iterate): {0}" + Environment.NewLine,
            UniqueStatistics.DistinctIntegersList(stats.Array));
        sb.AppendFormat(
            "Distinct Integers (Sort): {0}" + Environment.NewLine,
            UniqueStatistics.DistinctIntegersSorted(stats.Array));

        this.primaryTextBox.Text = sb.ToString();
    }
}
