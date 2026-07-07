using System;

namespace AlkimiaLab.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }

        public User() { }

        public User(int id, string nama, string password)
        {
            Id = id;
            Nama = nama;
            Password = password;
        }
    }
}
