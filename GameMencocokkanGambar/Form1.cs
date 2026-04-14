using System;
using System.Collections.Generic; //untuk mengelola banyak data
using System.ComponentModel; 
using System.Data;
using System.Drawing; //untuk visual
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameMencocokkanGambar
{
    public partial class Form1 : Form
    {
        // Variabel untuk mengacak gambar
        Random random = new Random();

        // Daftar ikon (tiap huruf mewakili gambar berbeda di font Webdings, masing-masing ada sepasang)
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };

        // Variabel untuk menyimpan kotak pertama dan kedua yang diklik pemain
        Label firstClicked = null;
        Label secondClicked = null;

        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        private void AssignIconsToSquares()
        {
            // Cek setiap kotak di dalam TableLayoutPanel
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    // Pilih satu ikon acak dari daftar
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];

                    // Sembunyikan ikon dengan membuat warna font sama dengan warna background kotak
                    iconLabel.ForeColor = iconLabel.BackColor;

                    // Hapus ikon yang sudah dipakai dari daftar
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Matikan timer
            timer1.Stop();

            // Sembunyikan lagi kedua ikon dengan menyamakan warna font dan background
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            // Reset variabel untuk tebakan berikutnya
            firstClicked = null;
            secondClicked = null;
        }

        private void label_Click(object sender, EventArgs e)
        {
            // Kalau timer lagi jalan (lagi jeda nutup gambar), abaikan klik pemain
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // Kalau kotak yang diklik udah kebuka (warnanya hitam), abaikan
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                // Kalau ini adalah klik pertama pemain
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black; // Ubah warna font jadi hitam biar ikonnya kelihatan
                    return;
                }

                // Kalau sampai sini, berarti ini adalah klik kedua pemain
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                // Cek apakah gambar pertama dan kedua SAMA?
                if (firstClicked.Text == secondClicked.Text)
                {
                    // Kalau sama, biarkan terbuka dan reset variabel untuk tebakan berikutnya
                    firstClicked = null;
                    secondClicked = null;

                    // --- TAMBAHAN BARU: Cek apakah pemain sudah menang ---
                    CheckForWinner();

                    return;
                }

                // Kalau BEDA, nyalakan timer untuk menutup gambar kembali setelah jeda 750ms
                timer1.Start();
            }
        }

        // --- FUNGSI BARU: Mengecek apakah semua gambar sudah terbuka ---
        private void CheckForWinner()
        {
            // Cek semua kotak satu per satu
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    // Kalau masih ada ikon yang warnanya sama dengan background (masih tersembunyi), berarti game belum selesai
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            // Kalau semua kotak udah dicek dan gak ada yang tersembunyi, berarti MENANG!
            MessageBox.Show("Selamat bro! Kamu berhasil menyelesaikan gamenya!", "You Win!");
            Close(); // Menutup game otomatis setelah klik OK.
        }
    }
}