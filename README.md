# 📘 Pemrograman Lanjut - S2

Repository ini berisi dokumentasi tugas praktikum saya selama **Semester 2**. Tujuan dari repo ini adalah untuk menunjukkan hasil pengembangan aplikasi berbasis Windows Forms menggunakan bahasa pemrograman **C#**.

---

### 📂 Daftar Project

#### 1. Kalkulator Desktop (Windows Forms)
Aplikasi kalkulator GUI interaktif yang dirancang untuk menangani perhitungan matematika dengan alur yang halus.

* **Fitur Operasi Lengkap**: Mendukung aritmatika dasar (+, -, x, /), perhitungan persen (%), serta fitur hapus satu karakter (Del) dan reset total (C).
* **Logika DataTable Engine**: Memanfaatkan `System.Data` untuk menghitung ekspresi matematika kompleks dari teks secara otomatis.
* **Validasi & Error Handling**: Dilengkapi dengan sistem `try-catch` untuk mencegah aplikasi crash jika terjadi kesalahan input rumus.
* **Antarmuka User-Friendly**: Menggunakan *Event Sharing* agar navigasi tombol angka dan operator terasa responsif dan efisien.
  
#### 2. Game Mencocokkan Gambar (Matching Game)
Game asah otak sederhana di mana pemain harus menemukan pasangan gambar yang sama di balik kotak yang tertutup.

* **Sistem Acak Gambar**: Menggunakan algoritma `Random` untuk mengacak posisi ikon `Webdings` setiap kali game dimulai.
* **Logika Pencocokan**: Menggunakan variabel `firstClicked` dan `secondClicked` untuk membandingkan dua kotak yang dipilih pemain.
* **Fitur Delay Timer**: Implementasi `Timer` untuk memberikan jeda waktu agar pemain bisa melihat gambar sebelum tertutup otomatis jika tidak cocok.
* **Win Detection**: Sistem pengecekan otomatis yang memicu pesan kemenangan (`MessageBox`) ketika seluruh pasangan gambar berhasil ditemukan.

#### 3. Game Mencocokkan Gambar (Matching Game)
Aplikasi untuk memvisualisasikan cara kerja berbagai algoritma pengurutan dan pencarian data secara real-time.
* **Variasi Algoritma**: Implementasi algoritma pengurutan meliputi `Bubble Sort`, `Selection Sort`, `Insertion Sort`, dan `Counting Sort`, serta metode pencarian `Sequential Search` dan `Binary Search`.
* **Visualisasi Bertahap**: Menyediakan fitur penelusuran langkah demi langkah (step-by-step) dengan indikator warna tematik: **kuning** untuk proses perbandingan data dan **merah** untuk proses pertukaran posisi.
* **Kontrol Eksekusi**: Tersedia fitur pemutaran otomatis auto-play dengan pengaturan kecepatan yang dapat disesuaikan melalui komponen `TrackBar`.
* **Analisis Komparatif**: Menyediakan ringkasan performa pada akhir proses untuk membandingkan efisiensi antar-algoritma berdasarkan jumlah perbandingan dan frekuensi pertukaran data yang dilakukan.

---

### 🚀 Cara Menjalankan

1. **Clone** repository ini ke komputer kamu.
2. **Buka** folder project Kalkulator.
3. **Jalankan** file `.sln` menggunakan Visual Studio.
4. **Tekan F5** atau klik tombol **Start** untuk menjalankan aplikasi.

---
*Dibuat dengan semangat belajar oleh Ragasa - 2026*
