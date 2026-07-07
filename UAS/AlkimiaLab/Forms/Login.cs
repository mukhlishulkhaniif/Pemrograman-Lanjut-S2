using System;
using System.Windows.Forms;
using AlkimiaLab.Services;

namespace AlkimiaLab.Forms
{
    public partial class Login : Form
    {
        private readonly AuthService authService = new AuthService();

        public Login()
        {
            InitializeComponent();

            // Setting tambahan yang tidak wajib diatur lewat Designer
            txtPassword.PasswordChar = '*';
            lblStatus.Text = "";

            btnLogin.Click += BtnLogin_Click;
            btnKeRegister.Click += BtnKeRegister_Click;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string nama = txtNama.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(password))
            {
                lblStatus.Text = "Nama dan password harus diisi.";
                return;
            }

            string errorMessage;
            var user = authService.Login(nama, password, out errorMessage);

            if (user == null)
            {
                lblStatus.Text = errorMessage;
                return;
            }

            // Login sukses, buka MainGame dan tutup form Login
            var mainGame = new MainGame(user);
            mainGame.Show();
            this.Hide();
        }

        private void BtnKeRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new Register();
            registerForm.Show();
            this.Hide();
        }
    }
}
