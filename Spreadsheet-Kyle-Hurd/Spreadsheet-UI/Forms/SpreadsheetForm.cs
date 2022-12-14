// <copyright file="SpreadsheetForm.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.Forms;

using SpreadsheetEngine.Cells;
using SpreadsheetEngine;

/// <summary>
/// Initializes the <see cref="SpreadsheetForm"/> class.
/// </summary>
public partial class SpreadsheetForm : Form
{
    /// <summary>
    /// A spreadsheet object to be used in the form.
    /// </summary>
    private Spreadsheet spreadsheet;

    /// <summary>
    /// Initializes a new instance of the <see cref="SpreadsheetForm"/> class.
    /// </summary>
    public SpreadsheetForm()
    {
        // Value is what is displayed
        this.InitializeComponent();
        this.spreadsheet = new Spreadsheet(50, 26);
        this.spreadsheet.PropertyChanged += this.Spreadsheet_PropertyChanged;
    }

    /// <summary>
    /// Makes an update upon recieveing PropertyChanged event.
    /// </summary>
    /// <param name="sender">The object sending request.</param>
    /// <param name="e">The event arguments.</param>
    private void Spreadsheet_PropertyChanged(object? sender, EventArgs e)
    {
        if (sender is Cell)
        {
            SpreadsheetCell? cell = sender as SpreadsheetCell;
            if (cell != null)
            {
                this.DataGridView.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value = cell.Value;
                this.DataGridView.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Style.BackColor = cell.BackColor;
            }
        }
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
        for (int i = start; i <= end; i++)
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

    /// <summary>
    /// Upon the populate button being clicked, the spreadsheet is populated with
    /// around 50 random text saying a message, also showcasing the use of the
    /// `=` equation operation.
    /// </summary>
    /// <param name="sender">The object sending the event.</param>
    /// <param name="e">The event arguments.</param>
    private void ButtonRandomPopulate_Click(object sender, EventArgs e)
    {
        this.spreadsheet.ClearCells();
        string message = "Greetings, World.";
        var columns = this.spreadsheet.NumColumns;
        var rows = this.spreadsheet.NumRows;
        Random random = new Random();
        for (int i = 0; i < 55; ++i)
        {
            // Randomly select a column and row between 0 and columns and rows
            int column = random.Next(0, columns);
            int row = random.Next(0, rows);
            this.spreadsheet.TriggerUpdateCellText(row, column, message);
        }

        for (int row = 0; row < rows; ++row)
        {
            this.spreadsheet.TriggerUpdateCellText(row, 1, $"This is cell B{row + 1}");
        }

        for (int row = 0; row < rows; ++row)
        {
            this.spreadsheet.TriggerUpdateCellText(row, 0, $"=B{row + 1}");
        }
    }

    /// <summary>
    /// Modifier when the user clicks on a cell for editing.
    /// </summary>
    /// <param name="sender">The object sending the request.</param>
    /// <param name="e">The event arguments.</param>
    /// <exception cref="Exception">Grabs any exception that may occur.</exception>
    private void DataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
        int row = e.RowIndex;
        int col = e.ColumnIndex;
        try
        {
            this.DataGridView[col, row].Value = this.spreadsheet.GetCellText(row, col);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    /// <summary>
    /// Modifier when the user deselects a cell for editing.
    /// </summary>
    /// <param name="sender">The object sending the request.</param>
    /// <param name="e">The event arguments.</param>
    /// <exception cref="Exception">Grabs any exception that may occur.</exception>
    private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        int row = e.RowIndex;
        int col = e.ColumnIndex;
        try
        {
            string? message = this.DataGridView[col, row].Value.ToString();
            if (message != null)
            {
                this.spreadsheet.TriggerUpdateCellText(row, col, message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    /// <summary>
    /// Modifier when the user clicks on the ClearGrid button. Clears the spreadsheet.
    /// </summary>
    /// <param name="sender">The object sending the request.</param>
    /// <param name="e">The event arguments.</param>
    private void ButtonClearGrid_Click(object sender, EventArgs e)
    {
        this.spreadsheet.ClearCells();
    }

    /// <summary>
    /// Modifier when the user clicks on the change color button.
    /// Updates the color of the cell by updating value from
    /// <see cref="SpreadsheetCell.BackColor"/>.
    /// </summary>
    /// <param name="sender">The object sending the Click event.</param>
    /// <param name="e">The event arguments.</param>
    private void ChangeColorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ColorDialog colorDialog = new ColorDialog();
        if (colorDialog.ShowDialog() == DialogResult.OK)
        {
            DataGridViewSelectedCellCollection cells = this.DataGridView.SelectedCells;
            List<SpreadsheetCell> spreadsheetCells = cells
                                                        .Cast<DataGridViewCell>()
                                                        .Select(cell => new SpreadsheetCell(cell.RowIndex, cell.ColumnIndex))
                                                        .ToList();
            this.spreadsheet.TriggerUpdateCellColor(spreadsheetCells, colorDialog.Color);
        }
    }

    /// <summary>
    /// Modifier when the user clicks on the edit tool strip button.
    /// Updates the state of the button depending if there are items
    /// to undo or redo.
    /// </summary>
    /// <param name="sender">The thing sending the click event.</param>
    /// <param name="e">The event arguments.</param>
    private void EditToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.UndoToolStripMenuItem.Enabled = this.spreadsheet.CanUndo();
        this.RedoToolStripMenuItem.Enabled = this.spreadsheet.CanRedo();

        if (this.RedoToolStripMenuItem.Enabled == true)
        {
            this.RedoToolStripMenuItem.Text = $"Redo {this.spreadsheet.GetRedoTopAction()}";
        }

        if (this.UndoToolStripMenuItem.Enabled == true)
        {
            this.UndoToolStripMenuItem.Text = $"Undo {this.spreadsheet.GetUndoTopAction()}";
        }
    }

    /// <summary>
    /// Modifier when the user clicks on the undo button.
    /// </summary>
    /// <param name="sender">The thing sending the click event.</param>
    /// <param name="e">The event arguments.</param>
    private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.spreadsheet.Undo();
    }

    /// <summary>
    /// Modifier when the user clicks on the redo button.
    /// </summary>
    /// <param name="sender">The thing sending the click event.</param>
    /// <param name="e">The event arguments.</param>
    private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.spreadsheet.Redo();
    }

    /// <summary>
    /// Modifier when the user clicks on the save button.
    /// </summary>
    /// <param name="sender">The object sending the click event.</param>
    /// <param name="e">The event arguments.</param>
    private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "XML Files (*.xml)|*.xml";
        saveFileDialog.FilterIndex = 1;
        saveFileDialog.RestoreDirectory = true;

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                this.spreadsheet.Save(saveFileDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    /// <summary>
    /// Modifier when the user clicks on the load button.
    /// </summary>
    /// <param name="sender">The object sending the event.</param>
    /// <param name="e">The event arguments.</param>
    private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "XML Files (*.xml)|*.xml";
        openFileDialog.FilterIndex = 1;
        openFileDialog.RestoreDirectory = true;

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                this.spreadsheet.Load(openFileDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
