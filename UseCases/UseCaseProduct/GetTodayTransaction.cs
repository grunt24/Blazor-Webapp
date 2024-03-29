﻿using CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UseCases.Interfaces;
using UseCases.UsecaseProductInterface;

namespace UseCases.UseCaseProduct
{
    public class GetTodayTransaction : IGetTodayTransaction
    {
        private readonly ITransactionRepository transactionRepository;

        public GetTodayTransaction(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }
        public IEnumerable<Transaction> Execute(string cashierName)
        {
            return transactionRepository.GetByDay(cashierName, DateTime.Now);
        }
    }
}
