using AlkimiaLab.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;

namespace AlkimiaLab.Services
{
    /// Service untuk autentikasi user: register dan login.
    
    public class AuthService
    {
      
        /// Mendaftarkan user baru. 
        
        public bool Register(string nama, string password, out string errorMessage)
        {
            errorMessage = null;

            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Nama dan password tidak boleh kosong.";
                return false;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Cek apakah nama sudah dipakai
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE nama = @nama";
                    using (var checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@nama", nama);
                        long count = Convert.ToInt64(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            errorMessage = "Nama tersebut sudah digunakan.";
                            return false;
                        }
                    }

                    // Insert user baru
                    string insertQuery = "INSERT INTO users (nama, password) VALUES (@nama, @password)";
                    using (var insertCmd = new MySqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@nama", nama);
                        insertCmd.Parameters.AddWithValue("@password", password);
                        insertCmd.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Terjadi kesalahan database: " + ex.Message;
                return false;
            }
        }

        
        /// Melakukan login. 
        
        public User Login(string nama, string password, out string errorMessage)
        {
            errorMessage = null;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT id, nama, password, created_at FROM users WHERE nama = @nama AND password = @password";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    Id = reader.GetInt32("id"),
                                    Nama = reader.GetString("nama"),
                                    Password = reader.GetString("password"),
                                    CreatedAt = reader.GetDateTime("created_at")
                                };
                            }
                            else
                            {
                                errorMessage = "Nama atau password salah.";
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Terjadi kesalahan database: " + ex.Message;
                return null;
            }
        }
    }
}
