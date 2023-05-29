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
    public class RecordTransaction : IRecordTransaction
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IGetProductById getProductById;
        public RecordTransaction(ITransactionRepository transactionRepository, IGetProductById getProductById)
        {
            this.transactionRepository = transactionRepository;
            this.getProductById = getProductById;
        }

        public void Execute(string cashierName, int productId, int qty)
        {
            var product = getProductById.Execute(productId);

            transactionRepository.Save(cashierName, productId, product.Name, product.Price.Value, product.Quantity.Value, qty);
        }
    }
}
