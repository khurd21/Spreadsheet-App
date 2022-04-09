namespace Spreadsheet_Kyle_Hurd.Forms;

partial class SpreadsheetForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonRandomPopulate = new System.Windows.Forms.Button();
            this.ButtonClearGrid = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RedoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.AllowUserToDeleteRows = false;
            this.DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.A,
            this.B,
            this.C,
            this.D});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridView.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DataGridView.Location = new System.Drawing.Point(12, 60);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.RowHeadersWidth = 82;
            this.DataGridView.RowTemplate.Height = 41;
            this.DataGridView.Size = new System.Drawing.Size(1266, 724);
            this.DataGridView.TabIndex = 0;
            this.DataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridView_CellBeginEdit);
            this.DataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellEndEdit);
            // 
            // A
            // 
            this.A.HeaderText = "A";
            this.A.MinimumWidth = 10;
            this.A.Name = "A";
            this.A.Width = 200;
            // 
            // B
            // 
            this.B.HeaderText = "B";
            this.B.MinimumWidth = 10;
            this.B.Name = "B";
            this.B.Width = 200;
            // 
            // C
            // 
            this.C.HeaderText = "C";
            this.C.MinimumWidth = 10;
            this.C.Name = "C";
            this.C.Width = 200;
            // 
            // D
            // 
            this.D.HeaderText = "D";
            this.D.MinimumWidth = 10;
            this.D.Name = "D";
            this.D.Width = 200;
            // 
            // ButtonRandomPopulate
            // 
            this.ButtonRandomPopulate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ButtonRandomPopulate.BackColor = System.Drawing.Color.White;
            this.ButtonRandomPopulate.Location = new System.Drawing.Point(538, 790);
            this.ButtonRandomPopulate.Name = "ButtonRandomPopulate";
            this.ButtonRandomPopulate.Size = new System.Drawing.Size(214, 46);
            this.ButtonRandomPopulate.TabIndex = 1;
            this.ButtonRandomPopulate.Text = "Populate Me";
            this.ButtonRandomPopulate.UseVisualStyleBackColor = false;
            this.ButtonRandomPopulate.Click += new System.EventHandler(this.ButtonRandomPopulate_Click);
            // 
            // ButtonClearGrid
            // 
            this.ButtonClearGrid.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ButtonClearGrid.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ButtonClearGrid.Location = new System.Drawing.Point(775, 790);
            this.ButtonClearGrid.Name = "ButtonClearGrid";
            this.ButtonClearGrid.Size = new System.Drawing.Size(214, 46);
            this.ButtonClearGrid.TabIndex = 2;
            this.ButtonClearGrid.Text = "Clear Me";
            this.ButtonClearGrid.UseVisualStyleBackColor = false;
            this.ButtonClearGrid.Click += new System.EventHandler(this.ButtonClearGrid_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.cellToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1290, 42);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(71, 38);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UndoToolStripMenuItem,
            this.RedoToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(74, 38);
            this.EditToolStripMenuItem.Text = "Edit";
            this.EditToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // cellToolStripMenuItem
            // 
            this.cellToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeColorToolStripMenuItem});
            this.cellToolStripMenuItem.Name = "cellToolStripMenuItem";
            this.cellToolStripMenuItem.Size = new System.Drawing.Size(74, 38);
            this.cellToolStripMenuItem.Text = "Cell";
            // 
            // ChangeColorToolStripMenuItem
            // 
            this.ChangeColorToolStripMenuItem.Name = "ChangeColorToolStripMenuItem";
            this.ChangeColorToolStripMenuItem.Size = new System.Drawing.Size(293, 44);
            this.ChangeColorToolStripMenuItem.Text = "Change Color";
            this.ChangeColorToolStripMenuItem.Click += new System.EventHandler(this.ChangeColorToolStripMenuItem_Click);
            // 
            // UndoToolStripMenuItem
            // 
            this.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem";
            this.UndoToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.UndoToolStripMenuItem.Text = "Undo";
            this.UndoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // RedoToolStripMenuItem
            // 
            this.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem";
            this.RedoToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.RedoToolStripMenuItem.Text = "Redo";
            this.RedoToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItem_Click);
            // 
            // SpreadsheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1290, 848);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ButtonClearGrid);
            this.Controls.Add(this.ButtonRandomPopulate);
            this.Controls.Add(this.DataGridView);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SpreadsheetForm";
            this.Text = "Spreadsheet";
            this.Load += new System.EventHandler(this.SpreadsheetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DataGridView DataGridView;
    private DataGridViewTextBoxColumn A;
    private DataGridViewTextBoxColumn B;
    private DataGridViewTextBoxColumn C;
    private DataGridViewTextBoxColumn D;
    private Button ButtonRandomPopulate;
    private Button ButtonClearGrid;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem EditToolStripMenuItem;
    private ToolStripMenuItem cellToolStripMenuItem;
    private ToolStripMenuItem ChangeColorToolStripMenuItem;
    private ToolStripMenuItem UndoToolStripMenuItem;
    private ToolStripMenuItem RedoToolStripMenuItem;
}
