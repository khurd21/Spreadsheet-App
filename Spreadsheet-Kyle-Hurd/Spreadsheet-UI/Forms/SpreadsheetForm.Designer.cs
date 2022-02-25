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
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonRandomPopulate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
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
            this.DataGridView.Location = new System.Drawing.Point(12, 12);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.RowHeadersWidth = 82;
            this.DataGridView.RowTemplate.Height = 41;
            this.DataGridView.Size = new System.Drawing.Size(1266, 772);
            this.DataGridView.TabIndex = 0;
            this.DataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellValueChanged);
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
            this.ButtonRandomPopulate.Location = new System.Drawing.Point(538, 790);
            this.ButtonRandomPopulate.Name = "ButtonRandomPopulate";
            this.ButtonRandomPopulate.Size = new System.Drawing.Size(214, 46);
            this.ButtonRandomPopulate.TabIndex = 1;
            this.ButtonRandomPopulate.Text = "Populate Me";
            this.ButtonRandomPopulate.UseVisualStyleBackColor = true;
            this.ButtonRandomPopulate.Click += new System.EventHandler(this.ButtonRandomPopulate_Click);
            // 
            // SpreadsheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 848);
            this.Controls.Add(this.ButtonRandomPopulate);
            this.Controls.Add(this.DataGridView);
            this.Name = "SpreadsheetForm";
            this.Text = "Spreadsheet";
            this.Load += new System.EventHandler(this.SpreadsheetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private DataGridView DataGridView;
    private DataGridViewTextBoxColumn A;
    private DataGridViewTextBoxColumn B;
    private DataGridViewTextBoxColumn C;
    private DataGridViewTextBoxColumn D;
    private Button ButtonRandomPopulate;
}
