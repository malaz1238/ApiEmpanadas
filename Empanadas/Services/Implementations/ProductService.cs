using Empanadas.Data.Entities;
using Empanadas.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Empanadas.Data;
using System;
using static Empanadas.Data.Class;

namespace Empanadas.Services.Implementations
{
        public class ProductService : IProductService
        {
            private readonly EmpanadasContext _contextEmp;

            public ProductService(EmpanadasContext contextEmp)
            {
                _contextEmp = contextEmp;
            }

            public List<Product> GetProducts()
            {
                return _contextEmp.Products
                    .Include(p => p.Tastes)
                    .ToList();
            }

            public Product GetById(int id)
            {
                return _contextEmp.Products
                    .Include(p => p.Tastes)
                    .FirstOrDefault(x => x.ProductId == id);
            }

            public Product Add(Product product)
            {
                _contextEmp.Products.Add(product);
                _contextEmp.SaveChanges();
                return product;
            }

            public void Delete(int productId)
            {
                Product productToBeRemoved = _contextEmp.Products.FirstOrDefault(p => p.ProductId == productId);
                _contextEmp.Remove(productToBeRemoved);
                _contextEmp.SaveChanges();
            }
        }
}
