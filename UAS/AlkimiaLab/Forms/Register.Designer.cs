namespace AlkimiaLab.Forms
{
    partial class Register
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

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblKonfirmasiPassword;
        private System.Windows.Forms.TextBox txtKonfirmasiPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnKeLogin;
        private System.Windows.Forms.Label lblStatus;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNama = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblKonfirmasiPassword = new System.Windows.Forms.Label();
            this.txtKonfirmasiPassword = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnKeLogin = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(80, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "DAFTAR AKUN";

            // lblNama
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(40, 80);
            this.lblNama.Name = "lblNama";
            this.lblNama.Text = "Nama:";

            // txtNama
            this.txtNama.Location = new System.Drawing.Point(40, 100);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(300, 23);

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(40, 135);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Text = "Password:";

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(40, 155);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(300, 23);

            // lblKonfirmasiPassword
            this.lblKonfirmasiPassword.AutoSize = true;
            this.lblKonfirmasiPassword.Location = new System.Drawing.Point(40, 190);
            this.lblKonfirmasiPassword.Name = "lblKonfirmasiPassword";
            this.lblKonfirmasiPassword.Text = "Konfirmasi Password:";

            // txtKonfirmasiPassword
            this.txtKonfirmasiPassword.Location = new System.Drawing.Point(40, 210);
            this.txtKonfirmasiPassword.Name = "txtKonfirmasiPassword";
            this.txtKonfirmasiPassword.Size = new System.Drawing.Size(300, 23);

            // btnRegister
            this.btnRegister.Location = new System.Drawing.Point(40, 250);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(140, 35);
            this.btnRegister.Text = "Daftar";
            this.btnRegister.UseVisualStyleBackColor = true;

            // btnKeLogin
            this.btnKeLogin.Location = new System.Drawing.Point(200, 250);
            this.btnKeLogin.Name = "btnKeLogin";
            this.btnKeLogin.Size = new System.Drawing.Size(140, 35);
            this.btnKeLogin.Text = "Kembali ke Login";
            this.btnKeLogin.UseVisualStyleBackColor = true;

            // lblStatus
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(40, 295);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(300, 40);
            this.lblStatus.Text = "";

            // Register (Form)
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 355);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblNama);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblKonfirmasiPassword);
            this.Controls.Add(this.txtKonfirmasiPassword);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnKeLogin);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alkimia Lab - Register";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
