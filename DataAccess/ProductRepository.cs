
using CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Interfaces;

namespace DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;
        public ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product() {ProductId =  1, CategoryId = 1,Name = "banana", Price = 100.00, Quantity = 200},
                new Product() {ProductId =  2, CategoryId = 2,Name = "apple", Price = 80.00, Quantity = 12},
                new Product() {ProductId =  3, CategoryId = 3,Name = "grapes", Price = 100.00, Quantity = 52},
                new Product() {ProductId =  4, CategoryId = 1,Name = "eggp", Price = 1000.00, Quantity = 24}
            };
        }

        public void AddProduct(Product product)
        {
            if (_products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;

            if (_products != null && _products.Count > 0)
            {
                var maxId = _products.Max(x => x.ProductId);
                product.ProductId = maxId + 1;
            }
            else
            {
                product.ProductId = 1;
            }

            _products.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        public void DeleteProduct(int productId)
        {
            _products?.Remove(GetProductById(productId));

        }

        public Product GetProductById(int productId)
        {
            return _products?.FirstOrDefault(x => x.ProductId == productId);

        }


        public void UpdateProduct(Product product)
        {
            var productToUpdate = GetProductById(product.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
                productToUpdate.Quantity = product.Quantity;
                productToUpdate.CategoryId = product.CategoryId;
            }
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return _products.Where(x=>x.CategoryId == categoryId);
        }
    }
}
