using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InvokingWebAPI.Models;

namespace InvokingWebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly List<Product> _products;

        public ProductsController()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Keyboards", Price = 2000 },
                new Product { Id = 2, Name = "IPad", Price = 6000 },
                new Product { Id = 3, Name = "Mobiles", Price = 18000 },
                new Product { Id = 4, Name = "Laptops", Price = 52000 },
                new Product { Id = 5, Name = "Toys", Price = 5000 }
            };
        }

        public IEnumerable<Product> Get()
        {
            return _products;
        }

        public Product Get(int id)
        {
            return _products.Find(x => x.Id == id);
        }
    }
}
