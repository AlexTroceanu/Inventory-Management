﻿using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TransactionsInMemoryRepository : ITransactionRepository
    {
        private List<Transaction> transactions = new List<Transaction>();

        public IEnumerable<Transaction> GetByDayAndSeller(string sellerName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(sellerName))
                return transactions.Where(x => x.TimeStamp.Date == date.Date);
            else
                return transactions.Where(x =>
                    x.SellerName.ToLower().Contains(sellerName.ToLower()) &&
                    x.TimeStamp.Date == date.Date);
        }

        public IEnumerable<Transaction> Search(string sellerName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(sellerName))
                return transactions.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
            else
                return transactions.Where(x =>
                    x.SellerName.ToLower().Contains(sellerName.ToLower()) &&
                    x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
        }

        public void Add(string sellerName, int productId, string productName, double price, int beforeQty, int soldQty)
        {
            var transaction = new Transaction
            {
                ProductId = productId,
                ProductName = productName,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                SellerName = sellerName
            };

            if (transactions != null && transactions.Count > 0)
            {
                var maxId = transactions.Max(x => x.TransactionId);
                transaction.TransactionId = maxId + 1;
            } else
            {
                transaction.TransactionId = 1;
            }

            transactions?.Add(transaction);
        }
    }
}