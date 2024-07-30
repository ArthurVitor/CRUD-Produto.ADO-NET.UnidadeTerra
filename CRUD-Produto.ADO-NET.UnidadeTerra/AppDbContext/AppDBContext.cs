using CRUD_Produto.ADO_NET.UnidadeTerra.Models;
using CRUD_Produto.ADO_NET.UnidadeTerra.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Produto.ADO_NET.UnidadeTerra.AppDbContext
{
    internal class AppDBContext
    {
        public DbSet<Product> Produto { get; set; } = new DbSet<Product>();

        public DbSet<Category> Categorias { get; set; } = new DbSet<Category>();
    }
}
