// <copyright file="SpreadsheetForm.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.Forms;

/// <summary>
/// Initializes the <see cref="SpreadsheetForm"/> class.
/// </summary>
public partial class SpreadsheetForm : Form
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SpreadsheetForm"/> class.
    /// </summary>
    public SpreadsheetForm()
    {
        this.InitializeComponent();
    }

    /// <summary>
    /// Meant to be called upon Load event. Initializes columns for the spreadsheet
    /// ranging from A to Z.
    /// </summary>
    /// <param name="sender">The object sending request.</param>
    /// <param name="e">The event args.</param>
    private void InitColumnsAZ(object sender, EventArgs e)
    {
        char letter = 'A';
        for (int i = 0; i < 26; i++)
        {
            this.DataGridView.Columns.Add(letter.ToString(), letter.ToString());
            ++letter;
        }
    }

    /// <summary>
    /// Meant to be called upon Load event. Initializes rows for the spreadsheet.
    /// The rows are numbered from <paramref name="start"/> to <paramref name="end"/>, inclusive.
    /// </summary>
    /// <param name="start">The numbered row for which to start (This becomes the first header cell name).</param>
    /// <param name="end">The numbered row for which to end (This becaomes the last header cell name).</param>
    /// <param name="sender">The object sending request.</param>
    /// <param name="e">The event args.</param>
    private void InitRows(int start, int end, object sender, EventArgs e)
    {
        for (int i = start; i <= end; ++i)
        {
            this.DataGridView.Rows.Add();
            this.DataGridView.Rows[i - start].HeaderCell.Value = i.ToString();
        }
    }

    /// <summary>
    /// Meant to be called upon Load event. Initializes the spreadsheet.
    /// </summary>
    /// <param name="sender">The object sending request.</param>
    /// <param name="e">The event args.</param>
    private void SpreadsheetForm_Load(object sender, EventArgs e)
    {
        this.DataGridView.Columns.Clear();
        this.InitColumnsAZ(sender, e);
        this.InitRows(1, 50, sender, e);
    }
}
