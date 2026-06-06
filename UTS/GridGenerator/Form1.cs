using System;
using System.Drawing;
using System.Windows.Forms;

namespace GridGenerator
{
    public partial class Form1 : Form
    {
        // Variabel penyimpan panel yang sedang diseret
        private Panel panelDiseret = null;

        public Form1()
        {
            InitializeComponent();

            // Mengaitkan kejadian (event) dengan fungsi
            trackBarRows.ValueChanged += UbahGeseran;
            trackBarColumns.ValueChanged += UbahGeseran;
            trackBarGap.ValueChanged += UbahGeseran;

            listBoxItems.SelectedIndexChanged += UbahDaftar;
            txtRename.TextChanged += UbahTeks;
            btnCopy.Click += SalinTeks;

            btnSortAZ.Click += UrutkanAZ;
            btnSortZA.Click += UrutkanZA;

            BuatGrid();
        }

        private void UbahGeseran(object sender, EventArgs e)
        {
            // Memperbarui teks label nilai
            lblRowsCount.Text = trackBarRows.Value.ToString();
            lblColumnsCount.Text = trackBarColumns.Value.ToString();
            lblGapValue.Text = trackBarGap.Value.ToString() + "px";

            BuatGrid();
        }

        private void BuatGrid()
        {
            int jumlahBaris = trackBarRows.Value;
            int jumlahKolom = trackBarColumns.Value;
            int jarakGrid = trackBarGap.Value;

            // Membersihkan tata letak sebelumnya
            previewPanel.Controls.Clear();
            previewPanel.RowCount = jumlahBaris;
            previewPanel.ColumnCount = jumlahKolom;

            // Membagi proporsi ukuran secara merata
            previewPanel.ColumnStyles.Clear();
            for (int kolom = 0; kolom < jumlahKolom; kolom++)
            {
                previewPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / jumlahKolom));
            }

            previewPanel.RowStyles.Clear();
            for (int baris = 0; baris < jumlahBaris; baris++)
            {
                previewPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / jumlahBaris));
            }

            // Proses pembuatan setiap kotak
            for (int baris = 0; baris < jumlahBaris; baris++)
            {
                for (int kolom = 0; kolom < jumlahKolom; kolom++)
                {
                    Panel panelKotak = new Panel();
                    panelKotak.Dock = DockStyle.Fill;
                    panelKotak.Margin = new Padding(jarakGrid / 2);

                    // Warna estetik: Biru muda dengan border biru royal
                    panelKotak.BackColor = Color.LightSkyBlue;
                    panelKotak.BorderStyle = BorderStyle.FixedSingle;
                    panelKotak.AllowDrop = true;

                    Label labelTeks = new Label();
                    labelTeks.Text = "Kotak " + (baris + 1) + "," + (kolom + 1);
                    labelTeks.ForeColor = Color.RoyalBlue;
                    labelTeks.TextAlign = ContentAlignment.MiddleCenter;
                    labelTeks.Dock = DockStyle.Fill;
                    labelTeks.Cursor = Cursors.Hand;

                    panelKotak.Controls.Add(labelTeks);

                    // Mengaktifkan fitur seret dan lepas
                    panelKotak.MouseDown += TekanKontrol;
                    labelTeks.MouseDown += TekanKontrol;
                    panelKotak.DragEnter += MasukArea;
                    labelTeks.DragEnter += MasukArea;
                    panelKotak.DragDrop += LepasKontrol;
                    labelTeks.DragDrop += LepasKontrol;

                    previewPanel.Controls.Add(panelKotak, kolom, baris);
                }
            }

            MuatDaftar();
            BuatCSS();
        }

        private void TekanKontrol(object sender, MouseEventArgs e)
        {
            Control kontrolDiklik = (Control)sender;
            panelDiseret = (kontrolDiklik is Label) ? (Panel)kontrolDiklik.Parent : (Panel)kontrolDiklik;
            panelDiseret.DoDragDrop(panelDiseret, DragDropEffects.Move);
        }

        private void MasukArea(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void LepasKontrol(object sender, DragEventArgs e)
        {
            Control kontrolDilepas = (Control)sender;
            Panel panelTujuan = (kontrolDilepas is Label) ? (Panel)kontrolDilepas.Parent : (Panel)kontrolDilepas;

            // Menukar posisi antar dua panel
            if (panelDiseret != null && panelDiseret != panelTujuan)
            {
                var posisiAsal = previewPanel.GetPositionFromControl(panelDiseret);
                var posisiTujuan = previewPanel.GetPositionFromControl(panelTujuan);

                previewPanel.SetCellPosition(panelDiseret, posisiTujuan);
                previewPanel.SetCellPosition(panelTujuan, posisiAsal);
                MuatDaftar();
            }
        }

        private void MuatDaftar()
        {
            listBoxItems.Items.Clear();
            foreach (Control item in previewPanel.Controls)
            {
                if (item is Panel pnl && pnl.Controls.Count > 0)
                    listBoxItems.Items.Add(pnl.Controls[0].Text);
            }
        }

        private void UrutkanAZ(object sender, EventArgs e) => ProsesUrutkan(true);
        private void UrutkanZA(object sender, EventArgs e) => ProsesUrutkan(false);

        private void ProsesUrutkan(bool dariAKeZ)
        {
            if (previewPanel.Controls.Count <= 1) return;

            Control[] daftarKotak = new Control[previewPanel.Controls.Count];
            previewPanel.Controls.CopyTo(daftarKotak, 0);

            // Pengurutan Bubble Sort
            for (int i = 0; i < daftarKotak.Length - 1; i++)
            {
                for (int j = i + 1; j < daftarKotak.Length; j++)
                {
                    string teksI = daftarKotak[i].Controls[0].Text;
                    string teksJ = daftarKotak[j].Controls[0].Text;

                    bool tukar = dariAKeZ ? string.Compare(teksI, teksJ) > 0 : string.Compare(teksI, teksJ) < 0;
                    if (tukar)
                    {
                        Control temp = daftarKotak[i];
                        daftarKotak[i] = daftarKotak[j];
                        daftarKotak[j] = temp;
                    }
                }
            }

            int kolomTotal = previewPanel.ColumnCount;
            for (int i = 0; i < daftarKotak.Length; i++)
                previewPanel.SetCellPosition(daftarKotak[i], new TableLayoutPanelCellPosition(i % kolomTotal, i / kolomTotal));

            MuatDaftar();
        }

        private void UbahDaftar(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedIndex >= 0) txtRename.Text = listBoxItems.SelectedItem.ToString();
        }

        private void UbahTeks(object sender, EventArgs e)
        {
            int indeks = listBoxItems.SelectedIndex;
            if (indeks >= 0)
            {
                listBoxItems.Items[indeks] = txtRename.Text;
                previewPanel.Controls[indeks].Controls[0].Text = txtRename.Text;
            }
        }

        private void BuatCSS()
        {
            // CSS Rapi dengan string interpolation
            string css = $@"
.grid-container {{
  display: grid;
  grid-template-columns: repeat({trackBarColumns.Value}, 1fr);
  grid-template-rows: repeat({trackBarRows.Value}, 1fr);
  gap: {trackBarGap.Value}px;
}}";
            txtCssOutput.Text = css.Trim();
        }

        private void SalinTeks(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCssOutput.Text))
            {
                Clipboard.SetText(txtCssOutput.Text);
                MessageBox.Show("Kode CSS berhasil disalin ke clipboard.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}