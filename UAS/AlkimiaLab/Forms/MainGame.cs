using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AlkimiaLab.Models;
using AlkimiaLab.Services;

namespace AlkimiaLab.Forms
{
    public partial class MainGame : Form
    {
        private readonly User currentUser;
        private readonly ElementService elementService = new ElementService();
        private readonly RecipeService recipeService = new RecipeService();

        // ===================== Warna tema =====================
        private static readonly Color ColorHeaderBg = Color.FromArgb(30, 41, 59);     // navy gelap
        private static readonly Color ColorAccentGreen = Color.FromArgb(34, 153, 84);  // hijau tombol
        private static readonly Color ColorPageBg = Color.FromArgb(250, 248, 243);     // krem terang
        private static readonly Color ColorLogoutRed = Color.FromArgb(217, 83, 79);

        // ===================== Kontrol Header =====================
        private Panel panelHeader;
        private Label lblUserName;
        private Label lblProgressNumber;
        private ProgressBar progressBarElemen;
        private Button btnLogout;

        // ===================== Kontrol Inventory (kiri) =====================
        private Panel panelInventoryContainer;
        private TextBox txtSearch;
        private FlowLayoutPanel panelInventoryGrid;

        // ===================== Kontrol Area Eksperimen (kanan) =====================
        private Panel panelEksperimenContainer;
        private Panel slot1;
        private Panel slot2;
        private Button btnGabung;
        private Panel panelHasil;

        // Data elemen yang sedang ditaruh di slot 1 / slot 2 (null kalau kosong)
        private Element elementSlot1;
        private Element elementSlot2;

        private List<Element> discoveredElements = new List<Element>();
        private int totalElementCount;

        private static readonly List<int> BASE_ELEMENT_IDS = new List<int> { 1, 2, 3, 4, 5, 6 };

        public MainGame(User user)
        {
            InitializeComponent();
            currentUser = user;
            BuildUI();
            LoadGameData();
        }

        // =========================================================================
        // SETUP UI
        // =========================================================================

        private void BuildUI()
        {
            this.Text = "Alkimia Lab";
            this.Size = new Size(1180, 820);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ColorPageBg;
            this.MinimumSize = new Size(1000, 700);

            BuildHeader();
            BuildInventoryPanel();
            BuildEksperimenPanel();

            this.Resize += (s, e) => LayoutPanels();
            LayoutPanels();
        }

        /// Mengatur ulang posisi & ukuran panel utama setiap kali form di-resize,

        private void LayoutPanels()
        {
            int margin = 20;
            int headerHeight = 95;

            panelHeader.Location = new Point(0, 0);
            panelHeader.Size = new Size(this.ClientSize.Width, headerHeight);
            btnLogout.Location = new Point(panelHeader.Width - 145, 28);

            int contentTop = headerHeight + margin;
            int contentHeight = this.ClientSize.Height - contentTop - margin;

            int inventoryWidth = (int)(this.ClientSize.Width * 0.33);
            panelInventoryContainer.Location = new Point(margin, contentTop);
            panelInventoryContainer.Size = new Size(inventoryWidth, contentHeight);

            int eksperimenLeft = margin + inventoryWidth + margin;
            panelEksperimenContainer.Location = new Point(eksperimenLeft, contentTop);
            panelEksperimenContainer.Size = new Size(this.ClientSize.Width - eksperimenLeft - margin, contentHeight);

            LayoutEksperimenContent();
        }

        // ---------------------------- HEADER ----------------------------

        private void BuildHeader()
        {
            panelHeader = new Panel { BackColor = ColorHeaderBg };

            var lblLogo = new Label
            {
                Text = "ALKIMIA LAB",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(25, 30)
            };

            lblUserName = new Label
            {
                Text = currentUser.Nama,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(300, 33)
            };

            var lblProgressTitle = new Label
            {
                Text = "Progres Elemen",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gainsboro,
                AutoSize = true,
                Location = new Point(480, 18)
            };

            lblProgressNumber = new Label
            {
                Text = "0 / 0",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(480, 38)
            };

            progressBarElemen = new ProgressBar
            {
                Location = new Point(480, 68),
                Size = new Size(220, 12),
                Minimum = 0,
                Maximum = 100,
                Value = 0,
                Style = ProgressBarStyle.Continuous
            };

            btnLogout = new Button
            {
                Text = "Logout",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = ColorLogoutRed,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(120, 38),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += BtnLogout_Click;

            panelHeader.Controls.Add(lblLogo);
            panelHeader.Controls.Add(lblUserName);
            panelHeader.Controls.Add(lblProgressTitle);
            panelHeader.Controls.Add(lblProgressNumber);
            panelHeader.Controls.Add(progressBarElemen);
            panelHeader.Controls.Add(btnLogout);

            this.Controls.Add(panelHeader);
        }

        // ---------------------------- INVENTORY (KIRI) ----------------------------

        private void BuildInventoryPanel()
        {
            panelInventoryContainer = new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblTitle = new Label
            {
                Text = "INVENTORY",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = ColorHeaderBg,
                AutoSize = true,
                Location = new Point(15, 15)
            };

            txtSearch = new TextBox
            {
                Location = new Point(15, 50),
                Width = 0, // diatur ulang di Resize
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                Text = "Cari elemen..."
            };
            // Implementasi placeholder manual (kompatibel di semua versi .NET Framework,
            // tidak mengandalkan properti PlaceholderText yang baru ada di .NET 4.7.2+)
            txtSearch.Enter += (s, e) =>
            {
                if (txtSearch.Text == "Cari elemen...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };
            txtSearch.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Cari elemen...";
                    txtSearch.ForeColor = Color.Gray;
                }
            };
            txtSearch.TextChanged += TxtSearch_TextChanged;

            panelInventoryGrid = new FlowLayoutPanel
            {
                Location = new Point(15, 85),
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                BorderStyle = BorderStyle.None
            };

            panelInventoryContainer.Controls.Add(lblTitle);
            panelInventoryContainer.Controls.Add(txtSearch);
            panelInventoryContainer.Controls.Add(panelInventoryGrid);

            panelInventoryContainer.Resize += (s, e) =>
            {
                txtSearch.Width = panelInventoryContainer.Width - 30;
                panelInventoryGrid.Size = new Size(
                    panelInventoryContainer.Width - 30,
                    panelInventoryContainer.Height - 95);
            };

            this.Controls.Add(panelInventoryContainer);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshInventoryPanel();
        }

        // ---------------------------- AREA EKSPERIMEN (KANAN) ----------------------------

        private void BuildEksperimenPanel()
        {
            panelEksperimenContainer = new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblTitle = new Label
            {
                Text = "AREA EKSPERIMEN",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = ColorHeaderBg,
                AutoSize = true,
                Location = new Point(15, 15)
            };
            panelEksperimenContainer.Controls.Add(lblTitle);

            slot1 = CreateSlotPanel();
            slot1.AllowDrop = true;
            slot1.DragEnter += Slot_DragEnter;
            slot1.DragDrop += (s, e) => Slot_DragDrop(e, isSlot1: true);
            panelEksperimenContainer.Controls.Add(slot1);

            var lblPlus = new Label
            {
                Text = "+",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.Gray,
                AutoSize = true,
                Name = "lblPlus"
            };
            panelEksperimenContainer.Controls.Add(lblPlus);

            slot2 = CreateSlotPanel();
            slot2.AllowDrop = true;
            slot2.DragEnter += Slot_DragEnter;
            slot2.DragDrop += (s, e) => Slot_DragDrop(e, isSlot1: false);
            panelEksperimenContainer.Controls.Add(slot2);

            btnGabung = new Button
            {
                Text = "GABUNG",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = ColorAccentGreen,
                FlatStyle = FlatStyle.Flat,
                Height = 45
            };
            btnGabung.FlatAppearance.BorderSize = 0;
            btnGabung.Click += BtnGabung_Click;
            panelEksperimenContainer.Controls.Add(btnGabung);

            var lblArrow = new Label
            {
                Text = "↓",
                Font = new Font("Segoe UI", 16),
                ForeColor = Color.Gray,
                AutoSize = true,
                Name = "lblArrow"
            };
            panelEksperimenContainer.Controls.Add(lblArrow);

            panelHasil = CreateSlotPanel("HASIL MERGE");
            panelEksperimenContainer.Controls.Add(panelHasil);

            panelEksperimenContainer.Resize += (s, e) => LayoutEksperimenContent();

            this.Controls.Add(panelEksperimenContainer);
        }

        /// Membuat panel kotak putus-putus standar untuk slot 1, slot 2, dan hasil merge.
        
        private Panel CreateSlotPanel(string placeholderText = "PILIH ELEMEN")
        {
            var panel = new Panel
            {
                BackColor = Color.FromArgb(248, 246, 240),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = placeholderText
            };

            var lbl = new Label
            {
                Text = "⚗\n\n" + placeholderText,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.Gray,
                Dock = DockStyle.Fill,
                Name = "lblPlaceholder"
            };
            panel.Controls.Add(lbl);

            return panel;
        }

        /// Mengatur ulang posisi slot1, plus, slot2, tombol gabung, arrow, dan hasil

        private void LayoutEksperimenContent()
        {
            if (panelEksperimenContainer == null) return;

            int containerWidth = panelEksperimenContainer.Width;
            int top = 60;
            int slotSize = 160;
            int plusWidth = 50;

            int totalRowWidth = slotSize + plusWidth + slotSize;
            int rowLeft = Math.Max(15, (containerWidth - totalRowWidth) / 2);

            slot1.Location = new Point(rowLeft, top);
            slot1.Size = new Size(slotSize, slotSize);

            var lblPlus = panelEksperimenContainer.Controls["lblPlus"];
            if (lblPlus != null)
            {
                lblPlus.Location = new Point(rowLeft + slotSize + (plusWidth - lblPlus.Width) / 2, top + slotSize / 2 - 15);
            }

            slot2.Location = new Point(rowLeft + slotSize + plusWidth, top);
            slot2.Size = new Size(slotSize, slotSize);

            int gabungTop = top + slotSize + 25;
            int gabungWidth = Math.Min(260, containerWidth - 30);
            btnGabung.Location = new Point((containerWidth - gabungWidth) / 2, gabungTop);
            btnGabung.Size = new Size(gabungWidth, 45);

            var lblArrow = panelEksperimenContainer.Controls["lblArrow"];
            if (lblArrow != null)
            {
                lblArrow.Location = new Point((containerWidth - lblArrow.Width) / 2, gabungTop + 55);
            }

            int hasilTop = gabungTop + 95;
            int hasilWidth = Math.Min(340, containerWidth - 30);
            int hasilHeight = Math.Max(140, panelEksperimenContainer.Height - hasilTop - 20);
            panelHasil.Location = new Point((containerWidth - hasilWidth) / 2, hasilTop);
            panelHasil.Size = new Size(hasilWidth, hasilHeight);
        }

        // =========================================================================
        // LOAD DATA & INVENTORY
        // =========================================================================

        private void LoadGameData()
        {
            elementService.EnsureBaseElementsUnlocked(currentUser.Id, BASE_ELEMENT_IDS);

            discoveredElements = elementService.GetDiscoveredElements(currentUser.Id);
            totalElementCount = elementService.GetTotalElementCount();

            RefreshInventoryPanel();
            RefreshProgressBar();
        }

        private void RefreshProgressBar()
        {
            lblProgressNumber.Text = $"{discoveredElements.Count} / {totalElementCount}";
            progressBarElemen.Maximum = Math.Max(1, totalElementCount);
            progressBarElemen.Value = Math.Min(discoveredElements.Count, progressBarElemen.Maximum);
        }

        /// <summary>
        /// Menggambar ulang seluruh isi panel inventory, difilter berdasarkan teks pencarian.
        /// </summary>
        private void RefreshInventoryPanel()
        {
            panelInventoryGrid.Controls.Clear();

            string keyword = (txtSearch?.Text ?? "").Trim().ToLower();
            if (keyword == "cari elemen...") keyword = "";

            var filtered = string.IsNullOrEmpty(keyword)
                ? discoveredElements
                : discoveredElements.Where(el => el.Nama.ToLower().Contains(keyword)).ToList();

            foreach (var element in filtered)
            {
                var card = CreateElementCard(element, isDraggableSource: true);
                panelInventoryGrid.Controls.Add(card);
            }
        }

        // =========================================================================
        // KARTU ELEMEN (placeholder warna + nama, sesuai keputusan tanpa icon/gambar)
        // =========================================================================

        private const int CARD_SIZE = 95;

        /// Folder tempat asset gambar elemen disimpan, relatif ke folder output (bin/Debug).
        
        private static readonly string AssetsFolder = System.IO.Path.Combine(Application.StartupPath, "Assets");

        
        /// Cache gambar yang sudah pernah di-load, supaya tidak membaca file yang sama
        /// berulang kali dari disk setiap kali sebuah kartu elemen dibuat.
        
        private static readonly Dictionary<string, Image> imageCache = new Dictionary<string, Image>();

        private Image LoadElementImage(Element element)
        {
            if (string.IsNullOrWhiteSpace(element.Gambar)) return null;

            if (imageCache.TryGetValue(element.Gambar, out var cached))
            {
                return cached;
            }

            string fullPath = System.IO.Path.Combine(AssetsFolder, element.Gambar);

            if (!System.IO.File.Exists(fullPath))
            {
                return null; // fallback ke placeholder warna+teks akan ditangani di pemanggil
            }

            try
            {
                // Load lewat MemoryStream agar file tidak terkunci (locked) oleh proses,
                // supaya tidak error kalau file diakses berulang kali.
                byte[] bytes = System.IO.File.ReadAllBytes(fullPath);
                using (var ms = new System.IO.MemoryStream(bytes))
                {
                    var image = Image.FromStream(ms);
                    imageCache[element.Gambar] = image;
                    return image;
                }
            }
            catch
            {
                return null;
            }
        }

        
        /// Membuat kartu elemen. Gambar dan label dibuat sebagai 2 kontrol yang benar-benar
        /// independen dengan ukuran & posisi dihitung manual (tidak pakai Dock.Fill), supaya
        /// proporsinya predictable di ukuran card berapa pun (kecil di inventory, besar di hasil).
        
        /// <param name="cardSize">Ukuran total kartu (lebar = tinggi).</param>
        /// <param name="imageBoxSize">Ukuran kotak gambar di dalam kartu (harus lebih kecil dari cardSize).</param>
        private Panel CreateElementCard(Element element, bool isDraggableSource, bool showBorder = true,
            int cardSize = CARD_SIZE, int imageBoxSize = 0)
        {
            if (imageBoxSize <= 0) imageBoxSize = cardSize - 24; // default: sisakan ruang untuk label

            var card = new Panel
            {
                Width = cardSize,
                Height = cardSize,
                Margin = new Padding(6),
                BorderStyle = showBorder ? BorderStyle.FixedSingle : BorderStyle.None,
                BackColor = Color.White,
                Tag = element
            };

            var image = LoadElementImage(element);
            const int labelHeight = 20;

            if (image != null)
            {
                // Kotak gambar:

                var pictureBox = new PictureBox
                {
                    Image = image,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = imageBoxSize,
                    Height = imageBoxSize,
                    Location = new Point((cardSize - imageBoxSize) / 2, 4),
                    BackColor = Color.Transparent
                };
                card.Controls.Add(pictureBox);

                var lblNama = new Label
                {
                    Text = element.Nama,
                    Width = cardSize,
                    Height = labelHeight,
                    Location = new Point(0, pictureBox.Bottom + 2),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 8, FontStyle.Bold),
                    ForeColor = Color.Black
                };
                card.Controls.Add(lblNama);

                if (isDraggableSource)
                {
                    MouseEventHandler startDrag = (s, e) => card.DoDragDrop(element, DragDropEffects.Copy);
                    card.MouseDown += startDrag;
                    pictureBox.MouseDown += startDrag;
                    lblNama.MouseDown += startDrag;
                }
            }
            else
            {
                // Fallback: gambar belum ada / gagal dimuat -> tampilkan kotak warna + nama
                
                card.BackColor = GetColorForKategori(element.Kategori);

                var lblNama = new Label
                {
                    Text = element.Nama,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = Color.Black,
                    BackColor = Color.Transparent
                };
                card.Controls.Add(lblNama);

                if (isDraggableSource)
                {
                    MouseEventHandler startDrag = (s, e) => card.DoDragDrop(element, DragDropEffects.Copy);
                    card.MouseDown += startDrag;
                    lblNama.MouseDown += startDrag;
                }
            }

            return card;
        }

        private Color GetColorForKategori(string kategori)
        {
            switch ((kategori ?? "").ToLower())
            {
                case "dasar": return Color.LightSkyBlue;
                case "alam": return Color.LightGreen;
                case "tumbuhan": return Color.PaleGreen;
                case "makhluk": return Color.LightSalmon;
                case "permukiman": return Color.Wheat;
                case "transportasi": return Color.LightSteelBlue;
                case "teknologi": return Color.Plum;
                case "bahan": return Color.Khaki;
                case "kosmik": return Color.MediumPurple;
                default: return Color.LightGray;
            }
        }

        // =========================================================================
        // DRAG & DROP: Inventory 
        // =========================================================================

        private void Slot_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Element)))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Slot_DragDrop(DragEventArgs e, bool isSlot1)
        {
            if (!e.Data.GetDataPresent(typeof(Element))) return;

            var element = (Element)e.Data.GetData(typeof(Element));

            if (isSlot1)
            {
                elementSlot1 = element;
                FillSlotVisual(slot1, element);
            }
            else
            {
                elementSlot2 = element;
                FillSlotVisual(slot2, element);
            }
        }

        /// Mengganti isi visual sebuah slot dari placeholder "PILIH ELEMEN" menjadi kartu elemen.
        
        private void FillSlotVisual(Panel slot, Element element)
        {
            slot.Controls.Clear();

            // Ukuran card disesuaikan dengan slot itu sendiri, supaya gambar besar
            // di panel Hasil (yang slotnya besar) tetap proporsional dan tidak mepet border:
            // sisakan margin sekitar 20px dari tepi slot di semua sisi.
            int availableSize = Math.Min(slot.ClientSize.Width, slot.ClientSize.Height) - 40;
            int cardSize = Math.Max(120, Math.Min(220, availableSize));
            int imageBoxSize = cardSize - 30; // sisakan ruang untuk label di bawah gambar

            var card = CreateElementCard(element, isDraggableSource: false, showBorder: false,
                cardSize: cardSize, imageBoxSize: imageBoxSize);
            card.Margin = new Padding(0);
            card.Anchor = AnchorStyles.None; // supaya tetap center walau slot di-resize

            slot.Controls.Add(card);
            card.Location = new Point(
                (slot.ClientSize.Width - card.Width) / 2,
                (slot.ClientSize.Height - card.Height) / 2);

            // Pastikan tetap center kalau slot berubah ukuran (misal saat window di-resize)
            slot.Resize += (s, e) =>
            {
                if (slot.Controls.Contains(card))
                {
                    card.Location = new Point(
                        (slot.ClientSize.Width - card.Width) / 2,
                        (slot.ClientSize.Height - card.Height) / 2);
                }
            };
        }

        /// <summary>
        /// Mengembalikan sebuah slot ke tampilan placeholder kosong "PILIH ELEMEN".
        /// </summary>
        private void ResetSlotVisual(Panel slot)
        {
            string placeholderText = (string)slot.Tag;
            slot.Controls.Clear();
            var lbl = new Label
            {
                Text = "⚗\n\n" + placeholderText,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.Gray,
                Dock = DockStyle.Fill,
                Name = "lblPlaceholder"
            };
            slot.Controls.Add(lbl);
        }

        // =========================================================================
        // TOMBOL GABUNG
        // =========================================================================

        private void BtnGabung_Click(object sender, EventArgs e)
        {
            if (elementSlot1 == null || elementSlot2 == null)
            {
                MessageBox.Show("Pilih dua elemen terlebih dahulu (drag ke slot kiri dan kanan).",
                    "Slot Belum Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var hasil = recipeService.FindResult(elementSlot1.Id, elementSlot2.Id);

            if (hasil == null)
            {
                MessageBox.Show($"{elementSlot1.Nama} + {elementSlot2.Nama} tidak menghasilkan apa-apa.",
                    "Kombinasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetSlotVisual(slot1);
                ResetSlotVisual(slot2);
                elementSlot1 = null;
                elementSlot2 = null;
                return;
            }

            bool penemuanBaru = elementService.MarkAsDiscovered(currentUser.Id, hasil.Id);

            FillSlotVisual(panelHasil, hasil);

            ResetSlotVisual(slot1);
            ResetSlotVisual(slot2);
            elementSlot1 = null;
            elementSlot2 = null;

            if (penemuanBaru)
            {
                discoveredElements = elementService.GetDiscoveredElements(currentUser.Id);
                RefreshInventoryPanel();
                RefreshProgressBar();

                MessageBox.Show($"Penemuan baru: {hasil.Nama}!",
                    "Elemen Baru Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // =========================================================================
        // LOGOUT
        // =========================================================================

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            var loginForm = new Login();
            loginForm.Show();
            this.Close();
        }
    }
}