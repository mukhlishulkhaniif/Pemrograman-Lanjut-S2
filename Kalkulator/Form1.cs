using System;
using System.Data;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        // Ingatan komputer untuk mengecek: Apakah kita baru saja menekan tombol Sama Dengan (=)?
        bool sudahAdaHasil = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void txtDisplay_TextChanged(object sender, EventArgs e) { }

        // --- 1. FUNGSI UNTUK TOMBOL SAMA DENGAN (=) ---
        private void btnHasil_Click(object sender, EventArgs e)
        {
            try
            {
                // Langkah 1: Baca tulisan yang ada di layar kalkulator saat ini
                string tulisanDiLayar = txtDisplay.Text;

                // Langkah 2: Komputer tidak paham koma (,) untuk desimal dan 'x' untuk kali.
                // terjemahkan dulu ke bahasa komputer:
                //tulisanDiLayar = tulisanDiLayar.Replace(",", "."); // Ubah koma menjadi titik
                tulisanDiLayar = tulisanDiLayar.Replace("x", "*"); // Ubah huruf x menjadi bintang (*)

                // Langkah 3: pinjam "mesin penghitung" otomatis bawaan C# (namanya DataTable)
                DataTable mesinPenghitung = new DataTable();

                // Langkah 4: Suruh mesinnya menghitung tulisan yang sudah diterjemahkan tadi
                object hasilHitungan = mesinPenghitung.Compute(tulisanDiLayar, "");

                // Langkah 5: Ubah hasil hitungan menjadi angka biasa
                double hasilAngka = Convert.ToDouble(hasilHitungan);

                // Langkah 6: Ubah lagi menjadi teks yang rapi agar bisa ditampilin di layar
                string teksHasil = hasilAngka.ToString(System.Globalization.CultureInfo.InvariantCulture);

                // Langkah 7: Terjemahkan balik dari bahasa komputer (titik) ke bahasa kita (koma)
                teksHasil = teksHasil.Replace(".", ",");

                // Langkah 8: Tampilkan hasil akhirnya ke layar!
                txtDisplay.Text = teksHasil;

                // Langkah 9: Ingatkan komputer bahwa angka yang tampil sekarang adalah hasil akhir
                sudahAdaHasil = true;
            }
            catch
            {
                // Kalau hitungannya ngawur (misal ngetik "5 + + 2"), tampilkan tulisan Error
                txtDisplay.Text = "Error";
                sudahAdaHasil = true;
            }
        }

        // --- 2. FUNGSI UNTUK TOMBOL ANGKA (0 SAMPAI 9) DAN KOMA ---
        private void Angka_Click(object sender, EventArgs e)
        {
            // Kita cek dulu kondisi layar saat ini
            bool layarMenampilkanNol = (txtDisplay.Text == "0");
            bool layarMenampilkanError = (txtDisplay.Text == "Error");

            // Kalau di layar cuma ada angka 0, ATAU ada tulisan Error, ATAU baru saja klik "=",
            // maka kita harus mengosongkan layar dulu sebelum ngetik angka baru.
            if (layarMenampilkanNol || layarMenampilkanError || sudahAdaHasil)
            {
                txtDisplay.Text = ""; // Kosongkan layar
                sudahAdaHasil = false; // Lupakan hasil yang lama
            }

            // Cari tahu tombol angka mana yang baru saja diklik olehmu
            Button tombolAngka = (Button)sender;

            // Tambahkan angka dari tombol itu ke layar
            txtDisplay.Text = txtDisplay.Text + tombolAngka.Text;
        }

        // --- 3. FUNGSI UNTUK TOMBOL TAMBAH, KURANG, KALI, BAGI, PERSEN ---
        private void Operasi_Click(object sender, EventArgs e)
        {
            // Kalau layar lagi error, ubah jadi 0 dulu biar aplikasinya tidak macet
            if (txtDisplay.Text == "Error")
            {
                txtDisplay.Text = "0";
            }

            // Cari tahu tombol simbol mana yang diklik
            Button tombolOperasi = (Button)sender;

            // Tambahkan simbol operasi itu ke layar
            txtDisplay.Text = txtDisplay.Text + tombolOperasi.Text;

            // Beritahu komputer bahwa kita sedang lanjut merangkai rumus, bukan menampilkan hasil akhir
            sudahAdaHasil = false;
        }

        // --- 4. FUNGSI UNTUK TOMBOL BERSIHKAN SEMUA (C) ---
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            // Kembalikan layar jadi angka 0
            txtDisplay.Text = "0";

            // Lupakan status hasil hitungan
            sudahAdaHasil = false;
        }

        // --- 5. FUNGSI UNTUK TOMBOL HAPUS SATU HURUF (DEL / BACKSPACE) ---
        private void btnHapus1_Click(object sender, EventArgs e)
        {
            // Kalau di layar ada tulisan Error atau angka hasil akhir, tombol hapus kita matikan
            if (sudahAdaHasil == true || txtDisplay.Text == "Error")
            {
                return; // Return artinya: "Berhenti di sini, jangan lanjut kerjakan kode ke bawah"
            }

            // Hitung ada berapa banyak huruf/angka di layar saat ini
            int jumlahHurufDiLayar = txtDisplay.Text.Length;

            // Kalau hurufnya masih lebih dari satu
            if (jumlahHurufDiLayar > 1)
            {
                // Ambil dan simpan semua huruf KECUALI satu huruf yang paling belakang
                txtDisplay.Text = txtDisplay.Text.Substring(0, jumlahHurufDiLayar - 1);
            }
            else
            {
                // Kalau hurufnya tinggal sisa satu dan dihapus, jadikan layarnya angka 0
                txtDisplay.Text = "0";
            }
        }
    }
}