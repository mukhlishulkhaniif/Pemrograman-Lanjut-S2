using AlkimiaLab.Models;
using AlkimiaLab.Database;
using MySql.Data.MySqlClient;
using System;

namespace AlkimiaLab.Repositories
{
    public class UserRepository
    {
        public bool UsernameExists(string nama)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM users WHERE nama=@nama";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", nama);

                    return Convert.ToInt64(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public void Register(string nama, string password)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query =
                    "INSERT INTO users(nama,password) VALUES(@nama,@password)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", nama);
                    cmd.Parameters.AddWithValue("@password", password);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public User Login(string nama, string password)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query =
                    @"SELECT id,nama,password,created_at
                      FROM users
                      WHERE nama=@nama
                      AND password=@password";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", nama);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new User
                        {
                            Id = reader.GetInt32("id"),
                            Nama = reader.GetString("nama"),
                            Password = reader.GetString("password"),
                            CreatedAt = reader.GetDateTime("created_at")
                        };
                    }
                }
            }
        }
    }
}