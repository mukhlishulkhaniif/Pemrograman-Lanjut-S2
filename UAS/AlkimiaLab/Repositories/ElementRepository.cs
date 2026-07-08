using AlkimiaLab.Models;
using AlkimiaLab.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace AlkimiaLab.Repositories
{
    public class ElementRepository
    {
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

        public bool IsDiscovered(int userId, int elementId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = @"SELECT COUNT(*) 
                         FROM progress
                         WHERE user_id = @userId
                         AND element_id = @elementId
                         AND ditemukan = TRUE";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@elementId", elementId);

                    return Convert.ToInt64(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public bool ProgressExists(int userId, int elementId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = @"SELECT COUNT(*)
                         FROM progress
                         WHERE user_id = @userId
                         AND element_id = @elementId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@elementId", elementId);

                    return Convert.ToInt64(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public void SaveDiscovery(int userId, int elementId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                if (ProgressExists(userId, elementId))
                {
                    string updateQuery =
                        @"UPDATE progress
                  SET ditemukan = TRUE
                  WHERE user_id = @userId
                  AND element_id = @elementId";

                    using (var cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@elementId", elementId);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string insertQuery =
                        @"INSERT INTO progress(user_id, element_id, ditemukan)
                  VALUES(@userId,@elementId,TRUE)";

                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@elementId", elementId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void UnlockBaseElement(int userId, int elementId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = @"INSERT INTO progress(user_id, element_id, ditemukan)
                         VALUES(@userId,@elementId,TRUE)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@elementId", elementId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}