namespace GridGenerator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.lblGapValue = new System.Windows.Forms.Label();
            this.lblColumnsCount = new System.Windows.Forms.Label();
            this.trackBarGap = new System.Windows.Forms.TrackBar();
            this.lblGap = new System.Windows.Forms.Label();
            this.trackBarColumns = new System.Windows.Forms.TrackBar();
            this.lblColumns = new System.Windows.Forms.Label();
            this.lblRows = new System.Windows.Forms.Label();
            this.trackBarRows = new System.Windows.Forms.TrackBar();
            this.lblRowsCount = new System.Windows.Forms.Label();
            this.groupBoxNames = new System.Windows.Forms.GroupBox();
            this.btnSortZA = new System.Windows.Forms.Button();
            this.btnSortAZ = new System.Windows.Forms.Button();
            this.txtRename = new System.Windows.Forms.TextBox();
            this.lblRenameTitle = new System.Windows.Forms.Label();
            this.listBoxItems = new System.Windows.Forms.ListBox();
            this.groupBoxCode = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtCssOutput = new System.Windows.Forms.TextBox();
            this.groupBoxPreview = new System.Windows.Forms.GroupBox();
            this.previewPanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRows)).BeginInit();
            this.groupBoxNames.SuspendLayout();
            this.groupBoxCode.SuspendLayout();
            this.groupBoxPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.BackColor = System.Drawing.Color.White;
            this.groupBoxSettings.Controls.Add(this.lblGapValue);
            this.groupBoxSettings.Controls.Add(this.lblColumnsCount);
            this.groupBoxSettings.Controls.Add(this.trackBarGap);
            this.groupBoxSettings.Controls.Add(this.lblGap);
            this.groupBoxSettings.Controls.Add(this.trackBarColumns);
            this.groupBoxSettings.Controls.Add(this.lblColumns);
            this.groupBoxSettings.Controls.Add(this.lblRows);
            this.groupBoxSettings.Controls.Add(this.trackBarRows);
            this.groupBoxSettings.Controls.Add(this.lblRowsCount);
            this.groupBoxSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxSettings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.groupBoxSettings.Location = new System.Drawing.Point(20, 20);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(380, 180);
            this.groupBoxSettings.TabIndex = 0;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "CSS Grid Settings";
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblRows.Location = new System.Drawing.Point(15, 35);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(40, 15);
            this.lblRows.TabIndex = 10;
            this.lblRows.Text = "ROWS";
            // 
            // trackBarRows
            // 
            this.trackBarRows.BackColor = System.Drawing.Color.White;
            this.trackBarRows.Location = new System.Drawing.Point(140, 30);
            this.trackBarRows.Minimum = 1;
            this.trackBarRows.Maximum = 8;
            this.trackBarRows.Name = "trackBarRows";
            this.trackBarRows.Size = new System.Drawing.Size(184, 45);
            this.trackBarRows.TabIndex = 11;
            this.trackBarRows.Value = 3;
            // 
            // lblRowsCount
            // 
            this.lblRowsCount.AutoSize = true;
            this.lblRowsCount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRowsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblRowsCount.Location = new System.Drawing.Point(340, 35);
            this.lblRowsCount.Name = "lblRowsCount";
            this.lblRowsCount.Size = new System.Drawing.Size(15, 17);
            this.lblRowsCount.TabIndex = 12;
            this.lblRowsCount.Text = "3";
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblColumns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblColumns.Location = new System.Drawing.Point(15, 80);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(67, 15);
            this.lblColumns.TabIndex = 4;
            this.lblColumns.Text = "COLUMNS";
            // 
            // trackBarColumns
            // 
            this.trackBarColumns.BackColor = System.Drawing.Color.White;
            this.trackBarColumns.Location = new System.Drawing.Point(140, 75);
            this.trackBarColumns.Minimum = 1;
            this.trackBarColumns.Maximum = 8;
            this.trackBarColumns.Name = "trackBarColumns";
            this.trackBarColumns.Size = new System.Drawing.Size(184, 45);
            this.trackBarColumns.TabIndex = 5;
            this.trackBarColumns.Value = 3;
            // 
            // lblColumnsCount
            // 
            this.lblColumnsCount.AutoSize = true;
            this.lblColumnsCount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblColumnsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblColumnsCount.Location = new System.Drawing.Point(340, 80);
            this.lblColumnsCount.Name = "lblColumnsCount";
            this.lblColumnsCount.Size = new System.Drawing.Size(15, 17);
            this.lblColumnsCount.TabIndex = 8;
            this.lblColumnsCount.Text = "3";
            // 
            // lblGap
            // 
            this.lblGap.AutoSize = true;
            this.lblGap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblGap.Location = new System.Drawing.Point(15, 125);
            this.lblGap.Name = "lblGap";
            this.lblGap.Size = new System.Drawing.Size(31, 15);
            this.lblGap.TabIndex = 6;
            this.lblGap.Text = "GAP";
            // 
            // trackBarGap
            // 
            this.trackBarGap.BackColor = System.Drawing.Color.White;
            this.trackBarGap.Location = new System.Drawing.Point(140, 120);
            this.trackBarGap.Maximum = 40;
            this.trackBarGap.Name = "trackBarGap";
            this.trackBarGap.Size = new System.Drawing.Size(184, 45);
            this.trackBarGap.TabIndex = 7;
            this.trackBarGap.Value = 15;
            // 
            // lblGapValue
            // 
            this.lblGapValue.AutoSize = true;
            this.lblGapValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblGapValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblGapValue.Location = new System.Drawing.Point(330, 125);
            this.lblGapValue.Name = "lblGapValue";
            this.lblGapValue.Size = new System.Drawing.Size(38, 17);
            this.lblGapValue.TabIndex = 9;
            this.lblGapValue.Text = "15px";
            // 
            // groupBoxNames
            // 
            this.groupBoxNames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left))));
            this.groupBoxNames.BackColor = System.Drawing.Color.White;
            this.groupBoxNames.Controls.Add(this.btnSortZA);
            this.groupBoxNames.Controls.Add(this.btnSortAZ);
            this.groupBoxNames.Controls.Add(this.txtRename);
            this.groupBoxNames.Controls.Add(this.lblRenameTitle);
            this.groupBoxNames.Controls.Add(this.listBoxItems);
            this.groupBoxNames.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxNames.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.groupBoxNames.Location = new System.Drawing.Point(20, 215);
            this.groupBoxNames.Name = "groupBoxNames";
            this.groupBoxNames.Size = new System.Drawing.Size(380, 260);
            this.groupBoxNames.TabIndex = 1;
            this.groupBoxNames.TabStop = false;
            this.groupBoxNames.Text = "Daftar Nama Kotak";
            // 
            // btnSortZA
            // 
            this.btnSortZA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSortZA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnSortZA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSortZA.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnSortZA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSortZA.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSortZA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSortZA.Location = new System.Drawing.Point(265, 220);
            this.btnSortZA.Name = "btnSortZA";
            this.btnSortZA.Size = new System.Drawing.Size(100, 28);
            this.btnSortZA.TabIndex = 4;
            this.btnSortZA.Text = "Sort Z - A ↑";
            this.btnSortZA.UseVisualStyleBackColor = false;
            // 
            // btnSortAZ
            // 
            this.btnSortAZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSortAZ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnSortAZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSortAZ.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnSortAZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSortAZ.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSortAZ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSortAZ.Location = new System.Drawing.Point(155, 220);
            this.btnSortAZ.Name = "btnSortAZ";
            this.btnSortAZ.Size = new System.Drawing.Size(100, 28);
            this.btnSortAZ.TabIndex = 3;
            this.btnSortAZ.Text = "Sort A - Z ↓";
            this.btnSortAZ.UseVisualStyleBackColor = false;
            // 
            // lblRenameTitle
            // 
            this.lblRenameTitle.AutoSize = true;
            this.lblRenameTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRenameTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblRenameTitle.Location = new System.Drawing.Point(15, 25);
            this.lblRenameTitle.Name = "lblRenameTitle";
            this.lblRenameTitle.Size = new System.Drawing.Size(76, 15);
            this.lblRenameTitle.TabIndex = 1;
            this.lblRenameTitle.Text = "Ganti Nama:";
            // 
            // txtRename
            // 
            this.txtRename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtRename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRename.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRename.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtRename.Location = new System.Drawing.Point(15, 45);
            this.txtRename.Name = "txtRename";
            this.txtRename.Size = new System.Drawing.Size(350, 25);
            this.txtRename.TabIndex = 2;
            // 
            // listBoxItems
            // 
            this.listBoxItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.listBoxItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxItems.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.listBoxItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.listBoxItems.FormattingEnabled = true;
            this.listBoxItems.Location = new System.Drawing.Point(15, 80);
            this.listBoxItems.Name = "listBoxItems";
            this.listBoxItems.Size = new System.Drawing.Size(350, 130);
            this.listBoxItems.TabIndex = 0;
            // 
            // groupBoxCode
            // 
            this.groupBoxCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left))));
            this.groupBoxCode.BackColor = System.Drawing.Color.White;
            this.groupBoxCode.Controls.Add(this.btnCopy);
            this.groupBoxCode.Controls.Add(this.txtCssOutput);
            this.groupBoxCode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.groupBoxCode.Location = new System.Drawing.Point(20, 490);
            this.groupBoxCode.Name = "groupBoxCode";
            this.groupBoxCode.Size = new System.Drawing.Size(380, 205);
            this.groupBoxCode.TabIndex = 2;
            this.groupBoxCode.TabStop = false;
            this.groupBoxCode.Text = "Code Generator";
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCopy.ForeColor = System.Drawing.Color.White;
            this.btnCopy.Location = new System.Drawing.Point(275, 160);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(85, 30);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "Copy Code";
            this.btnCopy.UseVisualStyleBackColor = false;
            // 
            // txtCssOutput
            // 
            this.txtCssOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCssOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtCssOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCssOutput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCssOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.txtCssOutput.Location = new System.Drawing.Point(15, 25);
            this.txtCssOutput.Multiline = true;
            this.txtCssOutput.Name = "txtCssOutput";
            this.txtCssOutput.ReadOnly = true;
            this.txtCssOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCssOutput.Size = new System.Drawing.Size(345, 125);
            this.txtCssOutput.TabIndex = 0;
            // 
            // groupBoxPreview
            // 
            this.groupBoxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPreview.BackColor = System.Drawing.Color.White;
            this.groupBoxPreview.Controls.Add(this.previewPanel);
            this.groupBoxPreview.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.groupBoxPreview.Location = new System.Drawing.Point(420, 20);
            this.groupBoxPreview.Name = "groupBoxPreview";
            this.groupBoxPreview.Size = new System.Drawing.Size(650, 675);
            this.groupBoxPreview.TabIndex = 4;
            this.groupBoxPreview.TabStop = false;
            this.groupBoxPreview.Text = "Live Preview";
            // 
            // previewPanel
            // 
            this.previewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.previewPanel.ColumnCount = 3;
            this.previewPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.previewPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.previewPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.previewPanel.Location = new System.Drawing.Point(15, 27);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.RowCount = 3;
            this.previewPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.previewPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.previewPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.previewPanel.Size = new System.Drawing.Size(620, 630);
            this.previewPanel.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1094, 715);
            this.Controls.Add(this.groupBoxPreview);
            this.Controls.Add(this.groupBoxCode);
            this.Controls.Add(this.groupBoxNames);
            this.Controls.Add(this.groupBoxSettings);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grid Generator - Premium Clean Edition";
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRows)).EndInit();
            this.groupBoxNames.ResumeLayout(false);
            this.groupBoxNames.PerformLayout();
            this.groupBoxCode.ResumeLayout(false);
            this.groupBoxCode.PerformLayout();
            this.groupBoxPreview.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.TrackBar trackBarColumns;
        private System.Windows.Forms.Label lblColumns;
        private System.Windows.Forms.TrackBar trackBarRows;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.TrackBar trackBarGap;
        private System.Windows.Forms.Label lblGap;
        private System.Windows.Forms.Label lblGapValue;
        private System.Windows.Forms.Label lblColumnsCount;
        private System.Windows.Forms.Label lblRowsCount;
        private System.Windows.Forms.GroupBox groupBoxNames;
        private System.Windows.Forms.ListBox listBoxItems;
        private System.Windows.Forms.TextBox txtRename;
        private System.Windows.Forms.Label lblRenameTitle;
        private System.Windows.Forms.GroupBox groupBoxCode;
        private System.Windows.Forms.TextBox txtCssOutput;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.GroupBox groupBoxPreview;
        private System.Windows.Forms.TableLayoutPanel previewPanel;
        private System.Windows.Forms.Button btnSortZA;
        private System.Windows.Forms.Button btnSortAZ;
    }
}