namespace AlkimiaLab.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public int Element1 { get; set; }
        public int Element2 { get; set; }
        public int Hasil { get; set; }

        public Recipe() { }

        public Recipe(int id, int element1, int element2, int hasil)
        {
            Id = id;
            Element1 = element1;
            Element2 = element2;
            Hasil = hasil;
        }
    }
}
