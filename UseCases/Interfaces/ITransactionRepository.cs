﻿using CoreEntities;

namespace UseCases.Interfaces
{
    public interface ITransactionRepository
    {
        public IEnumerable<Transaction> Get(string cashierName);
        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date);
        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate);
        public void Save(string cashierName ,int productId, string productName, double price, int beforeQty, int soldQty);

    }
} 