using CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Interfaces;

namespace DataAccess
{
    public class TransactionRepository : ITransactionRepository
    {
        private List<Transaction> _transactions;
        public TransactionRepository()  
        {
            _transactions = new List<Transaction>();
        }

        public IEnumerable<Transaction> Get(string cashierName)
        {
            if (string.IsNullOrWhiteSpace(cashierName)) 
                return _transactions;
            else
                return _transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return _transactions.Where(x => x.TimeStamp.Date == date.Date);
            else
                return _transactions.Where(x => 
                string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase) &&
                x.TimeStamp.Date == date.Date);

            
        }

        public void Save(string cashierName ,int productId, string productName, double price, int beforeQty, int soldQty)
        {
            int transactionId = 0;
            if(_transactions != null && _transactions.Count > 0) 
            {
                int maxId = _transactions.Max(x => x.TransactionId);
                transactionId = maxId + 1;
            }
            else
            {
                transactionId = 1;
            }

            _transactions.Add(new Transaction 
            { 
                TransactionId = transactionId,
                ProductId = productId, 
                ProductName = productName,
                TimeStamp = DateTime.Now,
                Price = price, 
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                CashierName = cashierName
            });
        }
    }
}
