using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using AlkimiaLab.Models;

namespace AlkimiaLab.Services
{
    
    /// Service untuk mengambil data elemen dan mengelola progress 
    
    public class ElementService
    {
        
        /// Menghitung total jumlah elemen yang ada di database 
        
        public int GetTotalElementCount()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM elements";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        /// Mengambil semua elemen dari database 
        
        public List<Element> GetAllElements()
        {
            var elements = new List<Element>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT id, nama, kategori, gambar FROM elements";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        elements.Add(new Element
                        {
                            Id = reader.GetInt32("id"),
                            Nama = reader.GetString("nama"),
                            Kategori = reader.IsDBNull(reader.GetOrdinal("kategori")) ? "" : reader.GetString("kategori"),
                            Gambar = reader.IsDBNull(reader.GetOrdinal("gambar")) ? "" : reader.GetString("gambar")
                        });
                    }
                }
            }

            return elements;
        }

        
        /// Mengambil elemen yang sudah ditemukan 
        
        public List<Element> GetDiscoveredElements(int userId)
        {
            var elements = new List<Element>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT e.id, e.nama, e.kategori, e.gambar
                    FROM elements e
                    INNER JOIN progress p ON p.element_id = e.id
                    WHERE p.user_id = @userId AND p.ditemukan = TRUE";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            elements.Add(new Element
                            {
                                Id = reader.GetInt32("id"),
                                Nama = reader.GetString("nama"),
                                Kategori = reader.IsDBNull(reader.GetOrdinal("kategori")) ? "" : reader.GetString("kategori"),
                                Gambar = reader.IsDBNull(reader.GetOrdinal("gambar")) ? "" : reader.GetString("gambar"),
                                Ditemukan = true
                            });
                        }
                    }
                }
            }

            return elements;
        }

        public void EnsureBaseElementsUnlocked(int userId, List<int> baseElementIds)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                foreach (var elementId in baseElementIds)
                {
                    string checkQuery = "SELECT COUNT(*) FROM progress WHERE user_id = @userId AND element_id = @elementId";
                    using (var checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@userId", userId);
                        checkCmd.Parameters.AddWithValue("@elementId", elementId);
                        long exists = Convert.ToInt64(checkCmd.ExecuteScalar());

                        if (exists == 0)
                        {
                            string insertQuery = @"INSERT INTO progress (user_id, element_id, ditemukan)
                                                    VALUES (@userId, @elementId, TRUE)";
                            using (var insertCmd = new MySqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@userId", userId);
                                insertCmd.Parameters.AddWithValue("@elementId", elementId);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Menandai sebuah elemen sebagai ditemukan untuk user tertentu.
        /// Dipanggil setiap kali hasil combine menghasilkan elemen baru.
        /// Mengembalikan true jika ini adalah penemuan BARU (belum pernah ditemukan sebelumnya).
        
        public bool MarkAsDiscovered(int userId, int elementId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM progress WHERE user_id = @userId AND element_id = @elementId AND ditemukan = TRUE";
                using (var checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@userId", userId);
                    checkCmd.Parameters.AddWithValue("@elementId", elementId);
                    long alreadyFound = Convert.ToInt64(checkCmd.ExecuteScalar());

                    if (alreadyFound > 0)
                    {
                        return false; // sudah pernah ditemukan, bukan penemuan baru
                    }
                }

                // Cek apakah baris progress sudah ada (tapi ditemukan = FALSE), atau belum ada sama sekali
                string existsQuery = "SELECT COUNT(*) FROM progress WHERE user_id = @userId AND element_id = @elementId";
                using (var existsCmd = new MySqlCommand(existsQuery, conn))
                {
                    existsCmd.Parameters.AddWithValue("@userId", userId);
                    existsCmd.Parameters.AddWithValue("@elementId", elementId);
                    long rowExists = Convert.ToInt64(existsCmd.ExecuteScalar());

                    if (rowExists > 0)
                    {
                        string updateQuery = "UPDATE progress SET ditemukan = TRUE WHERE user_id = @userId AND element_id = @elementId";
                        using (var updateCmd = new MySqlCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@userId", userId);
                            updateCmd.Parameters.AddWithValue("@elementId", elementId);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO progress (user_id, element_id, ditemukan) VALUES (@userId, @elementId, TRUE)";
                        using (var insertCmd = new MySqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@userId", userId);
                            insertCmd.Parameters.AddWithValue("@elementId", elementId);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }

                return true; // penemuan baru
            }
        }
    }
}