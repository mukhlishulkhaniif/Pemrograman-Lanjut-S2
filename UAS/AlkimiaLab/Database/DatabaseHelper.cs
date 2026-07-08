using MySql.Data.MySqlClient;
using System;
using System.Configuration;

namespace AlkimiaLab.Database
{
    
    /// Helper untuk membuka koneksi ke database MySQL alkimia_lab.
    
    public static class DatabaseHelper
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["AlkimiaLabDb"].ConnectionString;

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        
        /// Tes koneksi ke database. 
        
        public static bool TestConnection(out string errorMessage)
        {
            errorMessage = null;
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
