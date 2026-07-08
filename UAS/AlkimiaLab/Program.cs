using System;
using System.Windows.Forms;
using AlkimiaLab.Forms;
using AlkimiaLab.Database;

namespace AlkimiaLab
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Cek koneksi database sebelum membuka form utama,
            // supaya error koneksi langsung ketahuan di awal, bukan saat klik Login.
            string errorMessage;
            if (!DatabaseHelper.TestConnection(out errorMessage))
            {
                MessageBox.Show(
                    "Gagal terhubung ke database MySQL.\n\n" + errorMessage +
                    "\n\nPastikan MySQL server berjalan dan App.config sudah benar.",
                    "Koneksi Database Gagal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Application.Run(new Login());
        }
    }
}