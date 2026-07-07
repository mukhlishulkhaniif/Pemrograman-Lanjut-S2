using System;

namespace AlkimiaLab.Models
{
    public class Element
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Kategori { get; set; }
        public string Gambar { get; set; }

        public bool Ditemukan { get; set; }

        public Element() { }

        public Element(int id, string nama, string kategori, string gambar)
        {
            Id = id;
            Nama = nama;
            Kategori = kategori;
            Gambar = gambar;
        }

        public override string ToString()
        {
            return Nama;
        }
    }
}
