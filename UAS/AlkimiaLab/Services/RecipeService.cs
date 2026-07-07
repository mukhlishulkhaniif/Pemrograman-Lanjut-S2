using AlkimiaLab.Models;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace AlkimiaLab.Services
{
 
    /// Service untuk mengecek kombinasi recipe dua elemen.
  
    public class RecipeService
    {
       
        /// Mengecek apakah kombinasi dua elemen menghasilkan elemen baru.
        
        public Element FindResult(int elementId1, int elementId2)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                // Cek dua arah 
                string query = @"
                    SELECT e.id, e.nama, e.kategori, e.gambar
                    FROM recipes r
                    INNER JOIN elements e ON e.id = r.hasil
                    WHERE (r.element1 = @id1 AND r.element2 = @id2)
                       OR (r.element1 = @id2 AND r.element2 = @id1)
                    LIMIT 1";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id1", elementId1);
                    cmd.Parameters.AddWithValue("@id2", elementId2);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Element
                            {
                                Id = reader.GetInt32("id"),
                                Nama = reader.GetString("nama"),
                                Kategori = reader.IsDBNull(reader.GetOrdinal("kategori")) ? "" : reader.GetString("kategori"),
                                Gambar = reader.IsDBNull(reader.GetOrdinal("gambar")) ? "" : reader.GetString("gambar")
                            };
                        }
                    }
                }
            }

            return null; // tidak ada recipe yang cocok untuk kombinasi ini
        }
    }
}
