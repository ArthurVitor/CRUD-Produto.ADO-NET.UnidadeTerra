using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Produto.ADO_NET.UnidadeTerra.AppDbContext;
using CRUD_Produto.ADO_NET.UnidadeTerra.Models;
using CRUD_Produto.ADO_NET.UnidadeTerra.Repositories.Interfaces;

namespace CRUD_Produto.ADO_NET.UnidadeTerra.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _context;

        public ProductRepository(AppDBContext context)
        {
            _context = context;
        }

        public void CreateProduct(Product product)
        {
            _context.Produto.Create(product);
        }

        public void DeleteProduct(int id)
        {
            _context.Produto.Delete(id);
        }

        public Product? GetProductById(int id)
        {
            return _context.Produto.ToList().FirstOrDefault(x => x.Id == id);
        }

        public void UpdateProduct(Product product)
        {
            _context.Produto.Update(product);
        }
    }
}
