using System;
using System.Windows.Forms;
using AlkimiaLab.Services;

namespace AlkimiaLab.Forms
{
    public partial class Register : Form
    {
        private readonly AuthService authService = new AuthService();

        public Register()
        {
            InitializeComponent();

            txtPassword.PasswordChar = '*';
            txtKonfirmasiPassword.PasswordChar = '*';
            lblStatus.Text = "";

            btnRegister.Click += BtnRegister_Click;
            btnKeLogin.Click += BtnKeLogin_Click;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string nama = txtNama.Text.Trim();
            string password = txtPassword.Text;
            string konfirmasi = txtKonfirmasiPassword.Text;

            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(password))
            {
                lblStatus.Text = "Nama dan password harus diisi.";
                return;
            }

            if (password != konfirmasi)
            {
                lblStatus.Text = "Konfirmasi password tidak cocok.";
                return;
            }

            string errorMessage;
            bool sukses = authService.Register(nama, password, out errorMessage);

            if (!sukses)
            {
                lblStatus.Text = errorMessage;
                return;
            }

            MessageBox.Show("Registrasi berhasil! Silakan login.", "Sukses",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            var loginForm = new Login();
            loginForm.Show();
            this.Close();
        }

        private void BtnKeLogin_Click(object sender, EventArgs e)
        {
            var loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }
    }
}
