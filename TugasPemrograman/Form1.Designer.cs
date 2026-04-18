namespace TugasPemrograman
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
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAutoPlay = new System.Windows.Forms.Button();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.btnPrevStep = new System.Windows.Forms.Button();
            this.lblKeterangan = new System.Windows.Forms.Label();
            this.lblLangkah = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPertukaran = new System.Windows.Forms.Label();
            this.lblPerbandingan = new System.Windows.Forms.Label();
            this.dgvPerbandingan = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTabelPerbandingan = new System.Windows.Forms.Button();
            this.btnCounting = new System.Windows.Forms.Button();
            this.btnInsertion = new System.Windows.Forms.Button();
            this.btnSelection = new System.Windows.Forms.Button();
            this.btnBubble = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBinary = new System.Windows.Forms.Button();
            this.btnSequential = new System.Windows.Forms.Button();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarKecepatan = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerbandingan)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKecepatan)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnAutoPlay);
            this.groupBox1.Controls.Add(this.btnNextStep);
            this.groupBox1.Controls.Add(this.btnPrevStep);
            this.groupBox1.Controls.Add(this.lblKeterangan);
            this.groupBox1.Controls.Add(this.lblLangkah);
            this.groupBox1.Controls.Add(this.dgvData);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 600);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Visualisasi Data";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Pink;
            this.btnReset.Location = new System.Drawing.Point(342, 559);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 35);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAutoPlay
            // 
            this.btnAutoPlay.Location = new System.Drawing.Point(235, 559);
            this.btnAutoPlay.Name = "btnAutoPlay";
            this.btnAutoPlay.Size = new System.Drawing.Size(85, 35);
            this.btnAutoPlay.TabIndex = 5;
            this.btnAutoPlay.Text = "▶ Auto Play";
            this.btnAutoPlay.UseVisualStyleBackColor = true;
            this.btnAutoPlay.Click += new System.EventHandler(this.btnAutoPlay_Click);
            // 
            // btnNextStep
            // 
            this.btnNextStep.Location = new System.Drawing.Point(122, 559);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(85, 35);
            this.btnNextStep.TabIndex = 4;
            this.btnNextStep.Text = "Next";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // btnPrevStep
            // 
            this.btnPrevStep.Location = new System.Drawing.Point(17, 559);
            this.btnPrevStep.Name = "btnPrevStep";
            this.btnPrevStep.Size = new System.Drawing.Size(85, 35);
            this.btnPrevStep.TabIndex = 3;
            this.btnPrevStep.Text = "Prev";
            this.btnPrevStep.UseVisualStyleBackColor = true;
            this.btnPrevStep.Click += new System.EventHandler(this.btnPrevStep_Click);
            // 
            // lblKeterangan
            // 
            this.lblKeterangan.Location = new System.Drawing.Point(17, 482);
            this.lblKeterangan.Name = "lblKeterangan";
            this.lblKeterangan.Size = new System.Drawing.Size(410, 50);
            this.lblKeterangan.TabIndex = 2;
            this.lblKeterangan.Text = "-";
            // 
            // lblLangkah
            // 
            this.lblLangkah.AutoSize = true;
            this.lblLangkah.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLangkah.Location = new System.Drawing.Point(11, 441);
            this.lblLangkah.Name = "lblLangkah";
            this.lblLangkah.Size = new System.Drawing.Size(166, 32);
            this.lblLangkah.TabIndex = 1;
            this.lblLangkah.Text = "Langkah ke-0";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvData.Location = new System.Drawing.Point(17, 38);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 82;
            this.dgvData.RowTemplate.Height = 33;
            this.dgvData.Size = new System.Drawing.Size(410, 400);
            this.dgvData.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 34.34705F;
            this.Column1.HeaderText = "No";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.FillWeight = 150.2683F;
            this.Column2.HeaderText = "Nama";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.FillWeight = 115.3846F;
            this.Column3.HeaderText = "Nilai";
            this.Column3.MinimumWidth = 10;
            this.Column3.Name = "Column3";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblPertukaran);
            this.groupBox2.Controls.Add(this.lblPerbandingan);
            this.groupBox2.Controls.Add(this.dgvPerbandingan);
            this.groupBox2.Location = new System.Drawing.Point(482, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 250);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hasil Perbandingan";
            // 
            // lblPertukaran
            // 
            this.lblPertukaran.AutoSize = true;
            this.lblPertukaran.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPertukaran.Location = new System.Drawing.Point(289, 201);
            this.lblPertukaran.Name = "lblPertukaran";
            this.lblPertukaran.Size = new System.Drawing.Size(171, 37);
            this.lblPertukaran.TabIndex = 2;
            this.lblPertukaran.Text = "Pertukaran: 0";
            // 
            // lblPerbandingan
            // 
            this.lblPerbandingan.AutoSize = true;
            this.lblPerbandingan.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerbandingan.Location = new System.Drawing.Point(13, 201);
            this.lblPerbandingan.Name = "lblPerbandingan";
            this.lblPerbandingan.Size = new System.Drawing.Size(210, 37);
            this.lblPerbandingan.TabIndex = 1;
            this.lblPerbandingan.Text = "Perbandingan: 0";
            // 
            // dgvPerbandingan
            // 
            this.dgvPerbandingan.AllowUserToAddRows = false;
            this.dgvPerbandingan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerbandingan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvPerbandingan.Location = new System.Drawing.Point(20, 38);
            this.dgvPerbandingan.Name = "dgvPerbandingan";
            this.dgvPerbandingan.RowHeadersVisible = false;
            this.dgvPerbandingan.RowHeadersWidth = 82;
            this.dgvPerbandingan.RowTemplate.Height = 33;
            this.dgvPerbandingan.Size = new System.Drawing.Size(440, 150);
            this.dgvPerbandingan.TabIndex = 0;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 230.7692F;
            this.Column4.HeaderText = "Algotirma";
            this.Column4.MinimumWidth = 10;
            this.Column4.Name = "Column4";
            this.Column4.Width = 140;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 47.04347F;
            this.Column5.HeaderText = "Perbandingan";
            this.Column5.MinimumWidth = 10;
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 22.18729F;
            this.Column6.HeaderText = "Pertukaran";
            this.Column6.MinimumWidth = 10;
            this.Column6.Name = "Column6";
            this.Column6.Width = 145;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnTabelPerbandingan);
            this.groupBox3.Controls.Add(this.btnCounting);
            this.groupBox3.Controls.Add(this.btnInsertion);
            this.groupBox3.Controls.Add(this.btnSelection);
            this.groupBox3.Controls.Add(this.btnBubble);
            this.groupBox3.Location = new System.Drawing.Point(482, 283);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(480, 150);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pilih Algoritma Sorting";
            // 
            // btnTabelPerbandingan
            // 
            this.btnTabelPerbandingan.Location = new System.Drawing.Point(31, 99);
            this.btnTabelPerbandingan.Name = "btnTabelPerbandingan";
            this.btnTabelPerbandingan.Size = new System.Drawing.Size(270, 45);
            this.btnTabelPerbandingan.TabIndex = 4;
            this.btnTabelPerbandingan.Text = "Tampilkan Tabel";
            this.btnTabelPerbandingan.UseVisualStyleBackColor = true;
            this.btnTabelPerbandingan.Click += new System.EventHandler(this.btnTabelPerbandingan_Click);
            // 
            // btnCounting
            // 
            this.btnCounting.Location = new System.Drawing.Point(330, 99);
            this.btnCounting.Name = "btnCounting";
            this.btnCounting.Size = new System.Drawing.Size(130, 45);
            this.btnCounting.TabIndex = 3;
            this.btnCounting.Text = "Counting Sort";
            this.btnCounting.UseVisualStyleBackColor = true;
            this.btnCounting.Click += new System.EventHandler(this.btnCounting_Click);
            // 
            // btnInsertion
            // 
            this.btnInsertion.Location = new System.Drawing.Point(330, 38);
            this.btnInsertion.Name = "btnInsertion";
            this.btnInsertion.Size = new System.Drawing.Size(130, 45);
            this.btnInsertion.TabIndex = 2;
            this.btnInsertion.Text = "Insertion Sort";
            this.btnInsertion.UseVisualStyleBackColor = true;
            this.btnInsertion.Click += new System.EventHandler(this.btnInsertion_Click);
            // 
            // btnSelection
            // 
            this.btnSelection.Location = new System.Drawing.Point(181, 38);
            this.btnSelection.Name = "btnSelection";
            this.btnSelection.Size = new System.Drawing.Size(130, 45);
            this.btnSelection.TabIndex = 1;
            this.btnSelection.Text = "Selection Sort";
            this.btnSelection.UseVisualStyleBackColor = true;
            this.btnSelection.Click += new System.EventHandler(this.btnSelection_Click);
            // 
            // btnBubble
            // 
            this.btnBubble.Location = new System.Drawing.Point(31, 38);
            this.btnBubble.Name = "btnBubble";
            this.btnBubble.Size = new System.Drawing.Size(130, 45);
            this.btnBubble.TabIndex = 0;
            this.btnBubble.Text = "Bubble Sort";
            this.btnBubble.UseVisualStyleBackColor = true;
            this.btnBubble.Click += new System.EventHandler(this.btnBubble_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnBinary);
            this.groupBox4.Controls.Add(this.btnSequential);
            this.groupBox4.Controls.Add(this.txtCari);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(482, 439);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(480, 120);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pilih Algoritma Searching";
            // 
            // btnBinary
            // 
            this.btnBinary.Location = new System.Drawing.Point(142, 75);
            this.btnBinary.Name = "btnBinary";
            this.btnBinary.Size = new System.Drawing.Size(130, 39);
            this.btnBinary.TabIndex = 3;
            this.btnBinary.Text = "Binary Search";
            this.btnBinary.UseVisualStyleBackColor = true;
            this.btnBinary.Click += new System.EventHandler(this.btnBinary_Click);
            // 
            // btnSequential
            // 
            this.btnSequential.Location = new System.Drawing.Point(6, 75);
            this.btnSequential.Name = "btnSequential";
            this.btnSequential.Size = new System.Drawing.Size(130, 39);
            this.btnSequential.TabIndex = 2;
            this.btnSequential.Text = "Sequential Search";
            this.btnSequential.UseVisualStyleBackColor = true;
            this.btnSequential.Click += new System.EventHandler(this.btnSequential_Click);
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(194, 32);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(100, 39);
            this.txtCari.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Masukkan Nilai:";
            // 
            // trackBarKecepatan
            // 
            this.trackBarKecepatan.Location = new System.Drawing.Point(482, 565);
            this.trackBarKecepatan.Minimum = 1;
            this.trackBarKecepatan.Name = "trackBarKecepatan";
            this.trackBarKecepatan.Size = new System.Drawing.Size(480, 90);
            this.trackBarKecepatan.TabIndex = 4;
            this.trackBarKecepatan.Value = 1;
            this.trackBarKecepatan.Scroll += new System.EventHandler(this.trackBarKecepatan_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 679);
            this.Controls.Add(this.trackBarKecepatan);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerbandingan)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKecepatan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblKeterangan;
        private System.Windows.Forms.Label lblLangkah;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAutoPlay;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.Button btnPrevStep;
        private System.Windows.Forms.TrackBar trackBarKecepatan;
        private System.Windows.Forms.DataGridView dgvPerbandingan;
        private System.Windows.Forms.Label lblPertukaran;
        private System.Windows.Forms.Label lblPerbandingan;
        private System.Windows.Forms.Button btnTabelPerbandingan;
        private System.Windows.Forms.Button btnCounting;
        private System.Windows.Forms.Button btnInsertion;
        private System.Windows.Forms.Button btnSelection;
        private System.Windows.Forms.Button btnBubble;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Button btnBinary;
        private System.Windows.Forms.Button btnSequential;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}

