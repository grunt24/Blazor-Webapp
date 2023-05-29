using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Interfaces;
using UseCases.UsecaseProductInterface;

namespace UseCases.UseCaseProduct
{
    public class SellProduct : ISellProduct
    {
        private readonly IProductRepository productRepository;
        private readonly IRecordTransaction recordTransaction;

        public SellProduct(
            IProductRepository productRepository,
            IRecordTransaction recordTransaction
            )
        {
            this.productRepository = productRepository;
            this.recordTransaction = recordTransaction;
        }

        public void Execute(string cashierName, int productId, int qtyToSell)
        {
            var product = productRepository.GetProductById(productId);
            if (product == null) return;

            recordTransaction.Execute(cashierName, productId, qtyToSell);
            product.Quantity -= qtyToSell;
            productRepository.UpdateProduct(product);

        }
    }
}
