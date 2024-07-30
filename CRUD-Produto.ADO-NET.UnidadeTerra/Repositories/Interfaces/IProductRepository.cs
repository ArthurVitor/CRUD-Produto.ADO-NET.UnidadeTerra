using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Produto.ADO_NET.UnidadeTerra.Models;

namespace CRUD_Produto.ADO_NET.UnidadeTerra.Repositories.Interfaces
{
    internal interface IProductRepository
    {
        void CreateProduct(Product product);

        Product GetProductById(int id);

        void UpdateProduct(Product product);

        void DeleteProduct(int id);
    }
}
