using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TugasPemrograman
{
    public partial class Form1 : Form
    {
        // Data awal bawaan dari tugas
        string[] namaAwal = {
            "Andi", "Budi", "Citra", "Deni", "Eka",
            "Fajar", "Gita", "Hana", "Ilham", "Joko",
            "Kiki", "Lina", "Miko", "Nadia", "Oscar",
            "Putri", "Qori", "Raka", "Sari", "Tono",
            "Umar", "Vina", "Widi", "Xena", "Yoga"
        };

        int[] nilaiAwal = {
            78, 55, 90, 42, 67,
            88, 33, 75, 91, 60,
            48, 82, 55, 70, 39,
            85, 63, 77, 91, 50,
            68, 44, 80, 57, 73
        };

        // Variabel kerja untuk nampung data yang diproses
        string[] nama;
        int[] nilai;

        // List buat nyimpen history tiap langkah algoritma
        List<int[]> stepsNilai = new List<int[]>();
        List<string[]> stepsNama = new List<string[]>();
        List<string> stepKeterangan = new List<string>();
        List<int[]> stepKuning = new List<int[]>(); // Warna buat elemen yang dibandingin
        List<int[]> stepMerah = new List<int[]>();  // Warna buat elemen yang ditukar
        List<int[]> stepHijau = new List<int[]>();  // Warna buat elemen yang udah fix
        int currentStep = 0;

        // Array buat nyatet rekor efisiensi algoritma
        int[] hasilPerbandingan = new int[4];
        int[] hasilPertukaran = new int[4];

        // Timer buat jalanin fitur Auto Play
        System.Windows.Forms.Timer timerAutoPlay = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
            SetupTimer();
            ResetData();
        }

        // Fungsi buat nyimpen snapshot data & warna di tiap langkah
        void SimpanLangkah(int[] nilaiSaatIni, string[] namaSaatIni, int[] kuning, int[] merah, int[] hijau, string keterangan)
        {
            stepsNilai.Add((int[])nilaiSaatIni.Clone());
            stepsNama.Add((string[])namaSaatIni.Clone());
            stepKuning.Add(kuning);
            stepMerah.Add(merah);
            stepHijau.Add(hijau);
            stepKeterangan.Add(keterangan);
        }

        // Fungsi buat update tampilan tabel sesuai posisi langkah
        void TampilkanDataGrid(int langkah)
        {
            if (stepsNilai.Count == 0) return;

            /* KODE LAMA (Bikin scroll lompat karena barisnya dihapus total):
            dgvData.Rows.Clear();
            int[] nilaiStepLama = stepsNilai[langkah];
            string[] namaStepLama = stepsNama[langkah];
            int[] kuningLama = stepKuning[langkah];
            int[] merahLama = stepMerah[langkah];
            int[] hijauLama = stepHijau[langkah];

            for (int i = 0; i < namaStepLama.Length; i++)
            {
                dgvData.Rows.Add(i + 1, namaStepLama[i], nilaiStepLama[i]);

                if (Array.IndexOf(merahLama, i) >= 0)
                    dgvData.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                else if (Array.IndexOf(kuningLama, i) >= 0)
                    dgvData.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                else if (Array.IndexOf(hijauLama, i) >= 0)
                    dgvData.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                else
                    dgvData.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
            */

            // KODE BARU: Update nilai sel aja tanpa hapus baris biar scroll aman
            int[] nilaiStep = stepsNilai[langkah];
            string[] namaStep = stepsNama[langkah];
            int[] kuning = stepKuning[langkah];
            int[] merah = stepMerah[langkah];
            int[] hijau = stepHijau[langkah];

            for (int i = 0; i < namaStep.Length; i++)
            {
                // Update teks
                dgvData.Rows[i].Cells[0].Value = i + 1;
                dgvData.Rows[i].Cells[1].Value = namaStep[i];
                dgvData.Rows[i].Cells[2].Value = nilaiStep[i];

                // Update warna
                if (Array.IndexOf(merah, i) >= 0)
                    dgvData.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                else if (Array.IndexOf(kuning, i) >= 0)
                    dgvData.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                else if (Array.IndexOf(hijau, i) >= 0)
                    dgvData.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                else
                    dgvData.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }

            lblLangkah.Text = $"Langkah ke-{langkah + 1} dari {stepsNilai.Count}";
            lblKeterangan.Text = stepKeterangan[langkah];
        }

        // Balikin data ke posisi semula (acak)
        void ResetData()
        {
            nama = (string[])namaAwal.Clone();
            nilai = (int[])nilaiAwal.Clone();

            stepsNilai.Clear(); stepsNama.Clear(); stepKeterangan.Clear();
            stepKuning.Clear(); stepMerah.Clear(); stepHijau.Clear();

            currentStep = 0;
            lblPerbandingan.Text = "Perbandingan: 0";
            lblPertukaran.Text = "Pertukaran: 0";
            lblKeterangan.Text = "-";
            lblLangkah.Text = "Langkah: -";

            dgvData.Rows.Clear();
            for (int i = 0; i < namaAwal.Length; i++)
                dgvData.Rows.Add(i + 1, namaAwal[i], nilaiAwal[i]);
        }

        // Setting kecepatan Auto Play
        void SetupTimer()
        {
            timerAutoPlay.Tick += (s, e) =>
            {
                if (currentStep < stepsNilai.Count - 1)
                {
                    currentStep++;
                    TampilkanDataGrid(currentStep);
                }
                else
                {
                    timerAutoPlay.Stop();
                    btnAutoPlay.Text = "▶ Auto Play";
                }
            };
        }

        // BUBBLE SORT: Geser elemen terbesar ke kanan dengan nuker elemen bersebelahan
        void JalankanBubbleSort()
        {
            ResetData();
            string[] n = (string[])nama.Clone(); int[] v = (int[])nilai.Clone();
            int perbandingan = 0, pertukaran = 0, panjang = v.Length;
            List<int> sudahUrut = new List<int>();

            for (int i = 0; i < panjang - 1; i++)
            {
                bool adaTukar = false;
                for (int j = 0; j < panjang - i - 1; j++)
                {
                    perbandingan++;
                    SimpanLangkah(v, n, new int[] { j, j + 1 }, new int[] { }, sudahUrut.ToArray(),
                        $"Bandingkan {n[j]} ({v[j]}) dengan {n[j + 1]} ({v[j + 1]}).");

                    if (v[j] > v[j + 1])
                    {
                        // Posisi salah, tukar
                        int tmpNilai = v[j]; v[j] = v[j + 1]; v[j + 1] = tmpNilai;
                        string tmpNama = n[j]; n[j] = n[j + 1]; n[j + 1] = tmpNama;
                        pertukaran++; adaTukar = true;

                        SimpanLangkah(v, n, new int[] { }, new int[] { j, j + 1 }, sudahUrut.ToArray(),
                            $"Tukar posisi {v[j + 1]} dengan {v[j]}.");
                    }
                }
                sudahUrut.Insert(0, panjang - i - 1);
                SimpanLangkah(v, n, new int[] { }, new int[] { }, sudahUrut.ToArray(), $"Iterasi selesai.");
                if (!adaTukar) break;
            }

            int[] semuaIndex = new int[panjang];
            for (int i = 0; i < panjang; i++) semuaIndex[i] = i;
            SimpanLangkah(v, n, new int[] { }, new int[] { }, semuaIndex, $"Bubble Sort selesai.");

            lblPerbandingan.Text = $"Perbandingan: {perbandingan}"; lblPertukaran.Text = $"Pertukaran: {pertukaran}";
            hasilPerbandingan[0] = perbandingan; hasilPertukaran[0] = pertukaran;

            currentStep = 0; TampilkanDataGrid(0);
        }

        // SELECTION SORT: Cari elemen terkecil, taruh paling depan
        void JalankanSelectionSort()
        {
            ResetData();
            string[] n = (string[])nama.Clone(); int[] v = (int[])nilai.Clone();
            int perbandingan = 0, pertukaran = 0, panjang = v.Length;
            List<int> sudahUrut = new List<int>();

            for (int i = 0; i < panjang - 1; i++)
            {
                int indexMin = i;
                for (int j = i + 1; j < panjang; j++)
                {
                    perbandingan++;
                    SimpanLangkah(v, n, new int[] { j, indexMin }, new int[] { }, sudahUrut.ToArray(),
                        $"Cari nilai minimum. Bandingkan dengan {n[indexMin]}.");

                    if (v[j] < v[indexMin])
                    {
                        // Ketemu yang lebih kecil
                        indexMin = j;
                        SimpanLangkah(v, n, new int[] { indexMin }, new int[] { }, sudahUrut.ToArray(), $"Minimum baru: {n[indexMin]}.");
                    }
                }

                if (indexMin != i)
                {
                    // Pindah posisi ke depan
                    int tmpNilai = v[i]; v[i] = v[indexMin]; v[indexMin] = tmpNilai;
                    string tmpNama = n[i]; n[i] = n[indexMin]; n[indexMin] = tmpNama;
                    pertukaran++;
                    SimpanLangkah(v, n, new int[] { }, new int[] { i, indexMin }, sudahUrut.ToArray(), $"Tukar ke indeks {i}.");
                }
                sudahUrut.Add(i);
            }

            int[] semuaIndex = new int[panjang];
            for (int i = 0; i < panjang; i++) semuaIndex[i] = i;
            SimpanLangkah(v, n, new int[] { }, new int[] { }, semuaIndex, $"Selection Sort selesai.");

            lblPerbandingan.Text = $"Perbandingan: {perbandingan}"; lblPertukaran.Text = $"Pertukaran: {pertukaran}";
            hasilPerbandingan[1] = perbandingan; hasilPertukaran[1] = pertukaran;

            currentStep = 0; TampilkanDataGrid(0);
        }

        // INSERTION SORT: Sisipin elemen ke posisi yang pas secara bertahap
        void JalankanInsertionSort()
        {
            ResetData();
            string[] n = (string[])nama.Clone(); int[] v = (int[])nilai.Clone();
            int perbandingan = 0, pertukaran = 0, panjang = v.Length;

            for (int i = 1; i < panjang; i++)
            {
                int kunciNilai = v[i]; string kunciNama = n[i]; int j = i - 1;
                SimpanLangkah(v, n, new int[] { i }, new int[] { }, new int[] { }, $"Ambil data {kunciNama}.");

                // Geser elemen lain ke kanan buat ngasih ruang
                while (j >= 0 && v[j] > kunciNilai)
                {
                    perbandingan++;
                    v[j + 1] = v[j]; n[j + 1] = n[j]; pertukaran++;
                    SimpanLangkah(v, n, new int[] { j }, new int[] { j + 1 }, new int[] { }, $"Geser {n[j]} ke kanan.");
                    j--;
                }
                if (j >= 0) perbandingan++;

                // Masukin elemen di ruang yang udah disiapin
                v[j + 1] = kunciNilai; n[j + 1] = kunciNama;

                int[] sudahUrut = new int[i + 1];
                for (int k = 0; k <= i; k++) sudahUrut[k] = k;
                SimpanLangkah(v, n, new int[] { }, new int[] { }, sudahUrut, $"Sisipin {kunciNama}.");
            }

            int[] semuaIndex = new int[panjang];
            for (int i = 0; i < panjang; i++) semuaIndex[i] = i;
            SimpanLangkah(v, n, new int[] { }, new int[] { }, semuaIndex, $"Insertion Sort selesai.");

            lblPerbandingan.Text = $"Perbandingan: {perbandingan}"; lblPertukaran.Text = $"Pergeseran: {pertukaran}";
            hasilPerbandingan[2] = perbandingan; hasilPertukaran[2] = pertukaran;

            currentStep = 0; TampilkanDataGrid(0);
        }

        // COUNTING SORT: Hitung kemunculan tiap angka, lalu susun tanpa dibandingin
        void JalankanCountingSort()
        {
            ResetData();
            string[] n = (string[])nama.Clone(); int[] v = (int[])nilai.Clone();
            int panjang = v.Length;
            int min = v[0], max = v[0];

            for (int i = 1; i < panjang; i++)
            {
                if (v[i] < min) min = v[i];
                if (v[i] > max) max = v[i];
            }
            int[] counting = new int[max - min + 1];

            // Hitung frekuensi angka
            for (int i = 0; i < panjang; i++)
            {
                counting[v[i] - min]++;
                SimpanLangkah(v, n, new int[] { i }, new int[] { }, new int[] { }, $"Hitung frekuensi nilai {v[i]}.");
            }

            int[] outputNilai = new int[panjang]; string[] outputNama = new string[panjang];
            int posisi = 0;

            // Jejerin ulang dari hasil hitungan tadi
            for (int val = min; val <= max; val++)
            {
                for (int i = 0; i < panjang && counting[val - min] > 0; i++)
                {
                    if (v[i] == val)
                    {
                        outputNilai[posisi] = val; outputNama[posisi] = n[i];
                        posisi++; counting[val - min]--;
                        SimpanLangkah(outputNilai, outputNama, new int[] { }, new int[] { posisi - 1 }, new int[] { }, $"Taruh {n[i]} ke posisi akhir.");
                    }
                }
            }

            // Copy data jadi ke array utama
            for (int i = 0; i < panjang; i++) { v[i] = outputNilai[i]; n[i] = outputNama[i]; }
            int[] semuaIndex = new int[panjang];
            for (int i = 0; i < panjang; i++) semuaIndex[i] = i;
            SimpanLangkah(v, n, new int[] { }, new int[] { }, semuaIndex, $"Counting Sort selesai.");

            lblPerbandingan.Text = "Perbandingan: 0"; lblPertukaran.Text = "Pertukaran: 0";
            hasilPerbandingan[3] = 0; hasilPertukaran[3] = 0;

            currentStep = 0; TampilkanDataGrid(0);
        }

        // SEQUENTIAL SEARCH: Cari data dengan ngecek dari atas sampai bawah
        void JalankanSequentialSearch(int nilaiCari)
        {
            ResetData();
            string[] n = (string[])namaAwal.Clone(); int[] v = (int[])nilaiAwal.Clone();
            int panjang = v.Length, langkah = 0;
            List<int> hasilDitemukan = new List<int>();

            for (int i = 0; i < panjang; i++)
            {
                langkah++;
                if (v[i] == nilaiCari)
                {
                    hasilDitemukan.Add(i);
                    SimpanLangkah(v, n, new int[] { }, new int[] { }, hasilDitemukan.ToArray(), $"Ditemukan {nilaiCari} di indeks {i}.");
                }
                else
                {
                    SimpanLangkah(v, n, new int[] { i }, new int[] { }, hasilDitemukan.ToArray(), $"Cek indeks {i}, bukan {nilaiCari}.");
                }
            }

            int[] semuaHijau = hasilDitemukan.ToArray();
            SimpanLangkah(v, n, new int[] { }, new int[] { }, semuaHijau, $"Pencarian selesai. Total langkah: {langkah}.");
            lblPerbandingan.Text = $"Langkah: {langkah}";
            lblPertukaran.Text = hasilDitemukan.Count > 0 ? $"Ketemu di indeks: {string.Join(", ", hasilDitemukan)}" : "Tidak ditemukan";

            currentStep = 0; TampilkanDataGrid(0);
        }

        // BINARY SEARCH: Cari data dengan belah tengah (Syarat: Data harus diurutin dulu)
        void JalankanBinarySearch(int nilaiCari)
        {
            ResetData();
            string[] n = (string[])namaAwal.Clone(); int[] v = (int[])nilaiAwal.Clone();
            int panjang = v.Length;

            /* KODE LAMA:
            Array.Sort(v, n); 
            */

            // Ngurutin data di balik layar pakai Bubble Sort (Syarat tugas)
            for (int i = 0; i < panjang - 1; i++)
            {
                for (int j = 0; j < panjang - i - 1; j++)
                {
                    if (v[j] > v[j + 1])
                    {
                        int tmpV = v[j]; v[j] = v[j + 1]; v[j + 1] = tmpV;
                        string tmpN = n[j]; n[j] = n[j + 1]; n[j + 1] = tmpN;
                    }
                }
            }
            SimpanLangkah(v, n, new int[] { }, new int[] { }, new int[] { }, $"Data diurutkan buat syarat Binary Search.");

            int low = 0, high = panjang - 1, langkah = 0, hasilIndex = -1;

            while (low <= high)
            {
                int mid = (low + high) / 2; langkah++;
                List<int> rentangAktif = new List<int>();
                for (int i = low; i <= high; i++) rentangAktif.Add(i);

                SimpanLangkah(v, n, new int[] { mid }, new int[] { }, rentangAktif.ToArray(), $"Bandingin nilai tengah {v[mid]} dengan {nilaiCari}.");

                if (v[mid] == nilaiCari)
                {
                    hasilIndex = mid;
                    SimpanLangkah(v, n, new int[] { }, new int[] { }, new int[] { mid }, $"Ketemu di indeks {mid}."); break;
                }
                else if (v[mid] < nilaiCari) { low = mid + 1; } // Cari di area kanan
                else { high = mid - 1; } // Cari di area kiri
            }

            lblPerbandingan.Text = $"Langkah: {langkah}";
            lblPertukaran.Text = hasilIndex >= 0 ? $"Ketemu di indeks: {hasilIndex}" : "Tidak ditemukan";

            currentStep = 0; TampilkanDataGrid(0);
        }

        // Tampilkan rekap performa ke tabel kanan
        void TampilkanTabelPerbandingan()
        {
            dgvPerbandingan.Rows.Clear();
            string[] namaAlgoritma = { "Bubble Sort", "Selection Sort", "Insertion Sort", "Counting Sort" };

            for (int i = 0; i < 4; i++) dgvPerbandingan.Rows.Add(namaAlgoritma[i], hasilPerbandingan[i], hasilPertukaran[i]);

            // Cari juara (skor terendah) buat diwarnain hijau
            int minP = int.MaxValue, minT = int.MaxValue, idxP = 0, idxT = 0;
            for (int i = 0; i < 4; i++)
            {
                // Nilai 0 diabaikan biar adil buat algoritma lain
                if (hasilPerbandingan[i] > 0 && hasilPerbandingan[i] < minP) { minP = hasilPerbandingan[i]; idxP = i; }
                if (hasilPertukaran[i] < minT) { minT = hasilPertukaran[i]; idxT = i; }
            }
            if (dgvPerbandingan.Rows.Count > 0)
            {
                dgvPerbandingan.Rows[idxP].Cells[1].Style.BackColor = Color.LightGreen;
                dgvPerbandingan.Rows[idxT].Cells[2].Style.BackColor = Color.LightGreen;
            }
        }

        // Sambungan tombol ke tiap fungsi
        private void btnReset_Click(object sender, EventArgs e) { ResetData(); }
        private void btnNextStep_Click(object sender, EventArgs e) { if (currentStep < stepsNilai.Count - 1) { currentStep++; TampilkanDataGrid(currentStep); } }
        private void btnPrevStep_Click(object sender, EventArgs e) { if (currentStep > 0) { currentStep--; TampilkanDataGrid(currentStep); } }
        private void btnAutoPlay_Click(object sender, EventArgs e)
        {
            if (timerAutoPlay.Enabled) { timerAutoPlay.Stop(); btnAutoPlay.Text = "▶ Auto Play"; }
            else { timerAutoPlay.Interval = 1100 - (trackBarKecepatan.Value * 100); timerAutoPlay.Start(); btnAutoPlay.Text = "⏸ Pause"; }
        }
        private void trackBarKecepatan_Scroll(object sender, EventArgs e) { timerAutoPlay.Interval = 1100 - (trackBarKecepatan.Value * 100); }
        private void btnBubble_Click(object sender, EventArgs e) { JalankanBubbleSort(); }
        private void btnSelection_Click(object sender, EventArgs e) { JalankanSelectionSort(); }
        private void btnInsertion_Click(object sender, EventArgs e) { JalankanInsertionSort(); }
        private void btnCounting_Click(object sender, EventArgs e) { JalankanCountingSort(); }
        private void btnSequential_Click(object sender, EventArgs e) { if (int.TryParse(txtCari.Text, out int val)) JalankanSequentialSearch(val); }
        private void btnBinary_Click(object sender, EventArgs e) { if (int.TryParse(txtCari.Text, out int val)) JalankanBinarySearch(val); }
        private void btnTabelPerbandingan_Click(object sender, EventArgs e) { TampilkanTabelPerbandingan(); }
    }
}