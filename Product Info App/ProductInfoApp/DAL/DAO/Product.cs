using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInfoApp.DAL.DAO
{
    internal class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }

        public Product(string code, string name, string quantity):this()
        {
            Code = code;
            Name = name;
            Quantity = quantity;

        }

        public Product()
        {
            
        }
}
}
