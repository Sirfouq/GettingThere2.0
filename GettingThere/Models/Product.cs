using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace GettingThere.Models
{
    public class Product
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }


        public int Rating { get; set; }
    }
}
