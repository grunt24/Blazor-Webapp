using CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Interfaces;

namespace UseCases
{
    public class GetTransactions : IGetTransactions
    {
        private readonly ITransactionRepository transactionRepository;

        public GetTransactions(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }
        public IEnumerable<Transaction> Execute(
            string cashierName,
            DateTime startDate,
            DateTime endDate
            )
        {
            return transactionRepository.Search(cashierName, startDate, endDate);
        }
    }
}
