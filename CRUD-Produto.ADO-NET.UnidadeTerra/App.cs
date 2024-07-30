using CRUD_Produto.ADO_NET.UnidadeTerra.AppDbContext;
using CRUD_Produto.ADO_NET.UnidadeTerra.Models;
using CRUD_Produto.ADO_NET.UnidadeTerra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Produto.ADO_NET.UnidadeTerra
{
    internal class App
    {
        private readonly IProductRepository _productRepository;

        public App(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Run()
        {
            Console.WriteLine("Hello fellow user. I'd like to explain you the idea of this project. This project started as an UnidadeTerra's challenge.\n" +
                            "The Idea was to create a CRUD using ADO.NET.\n" +
                            "After creating the CRUD I realized that it would be funny if I tried to recreate the DBSet<T> from EF.Core.\n" +
                            "So, I created a basic version of it.\n" +
                            "It features the main methods to communicate with a DB {Create, List, Update, and Delete}.\n" +
                            "For now, it doesn't support N to N relationships natively.\n" +
                            "But you can generate something similar with LINQ.");

            Console.WriteLine("If you have any feedback, you can create an Issue on the main repo.\n" +
                            "Thanks for reading!");

            Console.WriteLine("Also, it's great to note that I didn't create a menu because the idea was to simulate how EF.Core works.\n" +
                            "You can try the CRUD operations as you would with EF.Core.\n" +
                            "Create or use a DBContext\n" +
                            "And create repositories, services, whatever you feel like.");

        }
    }
}
