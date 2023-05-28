using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Interfaces;
using UseCases.UsecaseProductInterface;

namespace UseCases.UseCaseProduct
{
    public class DeleteProduct : IDeleteProduct
    {
        private readonly IProductRepository productRepository;

        public DeleteProduct(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void Delete(int productId)
        {
            productRepository.DeleteProduct(productId);
        }
    }
}
