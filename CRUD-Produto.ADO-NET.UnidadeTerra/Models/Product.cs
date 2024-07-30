using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Produto.ADO_NET.UnidadeTerra.Models
{
    internal class Product
    {
        public Product()
        {

        }

        public Product(string name, bool isPerishable, DateTime validDate)
        {
            Name = name;
            IsPerishable = isPerishable;
            ValidDate = validDate;
        }

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsPerishable { get; set; }

        public DateTime ValidDate { get; set; }
    }
}
