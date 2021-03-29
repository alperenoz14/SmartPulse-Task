using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.API.Entity
{
    public class Data
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Conract { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
