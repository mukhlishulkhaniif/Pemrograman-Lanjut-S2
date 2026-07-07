using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DivideConquerBruteForce
{
    public partial class Form1 : Form
    {
        // --- 1. DATA HARDCODE WAJIB ---
        private string[] hari = { "Hari 1", "Hari 2", "Hari 3", "Hari 4", "Hari 5", "Hari 6", "Hari 7", "Hari 8", "Hari 9", "Hari 10", "Hari 11", "Hari 12", "Hari 13", "Hari 14", "Hari 15" };
        private int[] dataSahamAwal = { 12, -15, 20, -5, 30, -10, 45, -60, 25, 10, -15, 35, -20, 15, -5 };

        // --- 2. STRUKTUR DATA VISUALISASI ---
        public class VisualStep
        {
            public List<int> KuningIdx { get; set; } = new List<int>();
            public List<int> MerahIdx { get; set; } = new List<int>();
            public List<int> HijauIdx { get; set; } = new List<int>();
            public string Pesan { get; set; }
        }

        private List<VisualStep> listRiwayat = new List<VisualStep>();
        private int pointerLangkah = 0;

        public Form1()
        {
            InitializeComponent();
            LoadDataToGrid();
        }

        private void LoadDataToGrid()
        {
            dgvData.Columns.Clear();
            dgvData.Columns.Add("hari", "Hari");
            dgvData.Columns.Add("saham", "Fluktuasi Saham");
            for (int i = 0; i < hari.Length; i++) dgvData.Rows.Add(hari[i], dataSahamAwal[i]);
            dgvData.ClearSelection();
        }

        // --- 3. EVENT HANDLERS (Sambungkan ini di Designer) ---

        private void btnBruteForce_Click(object sender, EventArgs e)
        {
            ResetVisual();
            int n = dataSahamAwal.Length;
            int maxSoFar = int.MinValue;
            int startMax = -1, endMax = -1;

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    int currentSum = 0;
                    VisualStep step = new VisualStep();

                    // Hitung sum & rekam rentang kuning
                    for (int k = i; k <= j; k++)
                    {
                        currentSum += dataSahamAwal[k];
                        step.KuningIdx.Add(k);
                    }

                    if (currentSum > maxSoFar)
                    {
                        maxSoFar = currentSum;
                        startMax = i; endMax = j;
                        step.Pesan = $"[Brute Force] New Max: {maxSoFar} (Indeks {i} s/d {j})";
                    }
                    else step.Pesan = $"[Brute Force] Cek subarray {i}-{j}. Total: {currentSum}";

                    // Rekam Hijau (Max sementara)
                    if (startMax != -1)
                        for (int k = startMax; k <= endMax; k++) step.HijauIdx.Add(k);

                    listRiwayat.Add(step);
                }
            }
            rtbLog.Text = "Brute Force recorded! Klik 'Next Step' untuk mulai.";
        }

        private void btnDnC_Click(object sender, EventArgs e)
        {
            ResetVisual();
            FindMaxSubDNC(0, dataSahamAwal.Length - 1);
            rtbLog.Text = "Divide & Conquer recorded! Klik 'Next Step' untuk mulai.";
        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            if (pointerLangkah >= listRiwayat.Count)
            {
                MessageBox.Show("Visualisasi Selesai!");
                return;
            }

            // Bersihkan warna lama
            foreach (DataGridViewRow row in dgvData.Rows) row.DefaultCellStyle.BackColor = Color.White;

            var step = listRiwayat[pointerLangkah];
            rtbLog.AppendText("\n" + step.Pesan);
            rtbLog.ScrollToCaret();

            // Warnai sesuai prioritas: Kuning -> Hijau -> Merah
            foreach (int i in step.KuningIdx) dgvData.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
            foreach (int i in step.HijauIdx) dgvData.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
            foreach (int i in step.MerahIdx) dgvData.Rows[i].DefaultCellStyle.BackColor = Color.Red;

            pointerLangkah++;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetVisual();
            rtbLog.Clear();
            rtbLog.Text = "Visualisasi di-reset.";
        }

        private void btnBenchmark_Click(object sender, EventArgs e)
        {
            int[] bigData = new int[10000];
            Random r = new Random();
            for (int i = 0; i < 10000; i++) bigData[i] = r.Next(-100, 100);

            Stopwatch sw = new Stopwatch();

            // BF Benchmark
            sw.Start();
            int bfRes = int.MinValue;
            for (int i = 0; i < 10000; i++)
            {
                int sum = 0;
                for (int j = i; j < 10000; j++)
                {
                    sum += bigData[j];
                    if (sum > bfRes) bfRes = sum;
                }
            }
            sw.Stop();
            lblHasilBF.Text = $"Brute Force $O(n^2)$: {sw.ElapsedMilliseconds} ms";

            // DC Benchmark
            sw.Restart();
            RunDCMurni(bigData, 0, 9999);
            sw.Stop();
            lblHasilDC.Text = $"Divide & Conquer $O(n \\log n)$: {sw.ElapsedMilliseconds} ms";
        }

        // --- 4. LOGIKA PENDUKUNG ---

        private int FindMaxSubDNC(int low, int high)
        {
            if (low == high)
            {
                var step = new VisualStep { Pesan = $"Base Case: Indeks {low} ({dataSahamAwal[low]})" };
                step.KuningIdx.Add(low);
                listRiwayat.Add(step);
                return dataSahamAwal[low];
            }

            int mid = (low + high) / 2;
            var stepDiv = new VisualStep { Pesan = $"Divide: {low}-{high} -> Mid: {mid}" };
            stepDiv.MerahIdx.Add(mid);
            for (int i = low; i <= high; i++) stepDiv.KuningIdx.Add(i);
            listRiwayat.Add(stepDiv);

            int leftMax = FindMaxSubDNC(low, mid);
            int rightMax = FindMaxSubDNC(mid + 1, high);
            int crossMax = FindMaxCrossing(low, mid, high);

            return Math.Max(Math.Max(leftMax, rightMax), crossMax);
        }

        private int FindMaxCrossing(int low, int mid, int high)
        {
            int leftSum = int.MinValue, sum = 0, maxL = mid;
            for (int i = mid; i >= low; i--)
            {
                sum += dataSahamAwal[i];
                if (sum > leftSum) { leftSum = sum; maxL = i; }
            }

            int rightSum = int.MinValue; sum = 0; int maxR = mid + 1;
            for (int j = mid + 1; j <= high; j++)
            {
                sum += dataSahamAwal[j];
                if (sum > rightSum) { rightSum = sum; maxR = j; }
            }

            var step = new VisualStep { Pesan = $"Crossing Found: {leftSum + rightSum} (Indeks {maxL}-{maxR})" };
            step.MerahIdx.Add(mid);
            for (int k = maxL; k <= maxR; k++) step.HijauIdx.Add(k);
            listRiwayat.Add(step);

            return leftSum + rightSum;
        }

        private int RunDCMurni(int[] arr, int low, int high)
        {
            if (low == high) return arr[low];
            int mid = (low + high) / 2;
            int l = RunDCMurni(arr, low, mid);
            int r = RunDCMurni(arr, mid + 1, high);
            int lS = int.MinValue, rS = int.MinValue, s = 0;
            for (int i = mid; i >= low; i--) { s += arr[i]; if (s > lS) lS = s; }
            s = 0;
            for (int j = mid + 1; j <= high; j++) { s += arr[j]; if (s > rS) rS = s; }
            return Math.Max(Math.Max(l, r), lS + rS);
        }

        private void ResetVisual()
        {
            pointerLangkah = 0;
            listRiwayat.Clear();
            foreach (DataGridViewRow row in dgvData.Rows) row.DefaultCellStyle.BackColor = Color.White;
        }
    }
}