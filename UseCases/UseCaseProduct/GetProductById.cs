using CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Interfaces;
using UseCases.UsecaseProductInterface;

namespace UseCases.UseCaseProduct
{
    public class GetProductById : IGetProductById
    {
        private readonly IProductRepository productRepository;

        public GetProductById(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public Product Execute(int productId)
        {
            return productRepository.GetProductById(productId);
        }
    }
}
