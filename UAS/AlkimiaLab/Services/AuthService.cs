using AlkimiaLab.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using AlkimiaLab.Repositories;

namespace AlkimiaLab.Services
{
    /// Service untuk autentikasi user: register dan login.
    
    public class AuthService
    {

        private readonly UserRepository repository;

        public AuthService()
        {
            repository = new UserRepository();
        }

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
                if (repository.UsernameExists(nama))
                {
                    errorMessage = "Nama tersebut sudah digunakan.";
                    return false;
                }

                repository.Register(nama, password);

                return true;
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
                User user = repository.Login(nama, password);

                if (user == null)
                {
                    errorMessage = "Nama atau password salah.";
                }

                return user;
            }
            catch (Exception ex)
            {
                errorMessage = "Terjadi kesalahan database: " + ex.Message;
                return null;
            }
        }
    }
}
