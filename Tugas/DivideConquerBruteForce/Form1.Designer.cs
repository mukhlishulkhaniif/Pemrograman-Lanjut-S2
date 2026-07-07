namespace DivideConquerBruteForce
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnBruteForce = new System.Windows.Forms.Button();
            this.btnDnC = new System.Windows.Forms.Button();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnBenchmark = new System.Windows.Forms.Button();
            this.lblHasilBF = new System.Windows.Forms.Label();
            this.lblHasilDC = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvData);
            this.groupBox1.Location = new System.Drawing.Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(750, 450);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data & Visualisasi";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnNextStep);
            this.groupBox2.Controls.Add(this.btnDnC);
            this.groupBox2.Controls.Add(this.btnBruteForce);
            this.groupBox2.Location = new System.Drawing.Point(20, 480);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(750, 150);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kontrol Algoritma";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtbLog);
            this.groupBox3.Location = new System.Drawing.Point(790, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(370, 350);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Keterangan Langkah";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblHasilDC);
            this.groupBox4.Controls.Add(this.lblHasilBF);
            this.groupBox4.Controls.Add(this.btnBenchmark);
            this.groupBox4.Location = new System.Drawing.Point(790, 380);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(370, 250);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Uji Performa";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(20, 30);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 82;
            this.dgvData.RowTemplate.Height = 33;
            this.dgvData.Size = new System.Drawing.Size(710, 400);
            this.dgvData.TabIndex = 0;
            // 
            // btnBruteForce
            // 
            this.btnBruteForce.Location = new System.Drawing.Point(30, 40);
            this.btnBruteForce.Name = "btnBruteForce";
            this.btnBruteForce.Size = new System.Drawing.Size(200, 45);
            this.btnBruteForce.TabIndex = 0;
            this.btnBruteForce.Text = "Brute Force";
            this.btnBruteForce.UseVisualStyleBackColor = true;
            this.btnBruteForce.Click += new System.EventHandler(this.btnBruteForce_Click);
            // 
            // btnDnC
            // 
            this.btnDnC.Location = new System.Drawing.Point(260, 40);
            this.btnDnC.Name = "btnDnC";
            this.btnDnC.Size = new System.Drawing.Size(200, 45);
            this.btnDnC.TabIndex = 1;
            this.btnDnC.Text = "Divide & Conquer";
            this.btnDnC.UseVisualStyleBackColor = true;
            this.btnDnC.Click += new System.EventHandler(this.btnDnC_Click);
            // 
            // btnNextStep
            // 
            this.btnNextStep.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNextStep.Location = new System.Drawing.Point(500, 40);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(220, 45);
            this.btnNextStep.TabIndex = 2;
            this.btnNextStep.Text = "Next Step";
            this.btnNextStep.UseVisualStyleBackColor = false;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(30, 93);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(690, 45);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset Visualisasi";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(20, 30);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(340, 400);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // btnBenchmark
            // 
            this.btnBenchmark.Location = new System.Drawing.Point(20, 40);
            this.btnBenchmark.Name = "btnBenchmark";
            this.btnBenchmark.Size = new System.Drawing.Size(340, 50);
            this.btnBenchmark.TabIndex = 0;
            this.btnBenchmark.Text = "Benchmark";
            this.btnBenchmark.UseVisualStyleBackColor = true;
            this.btnBenchmark.Click += new System.EventHandler(this.btnBenchmark_Click);
            // 
            // lblHasilBF
            // 
            this.lblHasilBF.AutoSize = true;
            this.lblHasilBF.Location = new System.Drawing.Point(25, 110);
            this.lblHasilBF.Name = "lblHasilBF";
            this.lblHasilBF.Size = new System.Drawing.Size(177, 25);
            this.lblHasilBF.TabIndex = 1;
            this.lblHasilBF.Text = "Brute Force: - ms";
            // 
            // lblHasilDC
            // 
            this.lblHasilDC.AutoSize = true;
            this.lblHasilDC.Location = new System.Drawing.Point(25, 145);
            this.lblHasilDC.Name = "lblHasilDC";
            this.lblHasilDC.Size = new System.Drawing.Size(219, 25);
            this.lblHasilDC.TabIndex = 2;
            this.lblHasilDC.Text = "Divide & Conquer: - ms";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 732);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.Button btnDnC;
        private System.Windows.Forms.Button btnBruteForce;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btnBenchmark;
        private System.Windows.Forms.Label lblHasilDC;
        private System.Windows.Forms.Label lblHasilBF;
    }
}

