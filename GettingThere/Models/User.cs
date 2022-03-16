using System;
using SQLite;
namespace GettingThere.Models
{
    public class User
    {

        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Pass { get; set; }

        public string Email { get; set; }
    }
}
