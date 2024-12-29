using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Plugins.DataStore.SQL
{
	public class TransactionSQLRepository : ITransactionRepository
	{
		private readonly InventoryContext db;

		public TransactionSQLRepository(InventoryContext db)
        {
			this.db = db;
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

			db.Transactions.Add(transaction);
			db.SaveChanges();
		}

		public IEnumerable<Transaction> GetByDayAndSeller(string sellerName, DateTime date)
		{
			if (string.IsNullOrWhiteSpace(sellerName))
			{
				return db.Transactions.Where(x => x.TimeStamp.Date == date.Date);
			}
			else
			{
				return db.Transactions.Where(x =>
					EF.Functions.Like(x.SellerName, $"%{sellerName}%") &&
					x.TimeStamp.Date == date.Date);
			}
		}

		public IEnumerable<Transaction> Search(string sellerName, DateTime startDate, DateTime endDate)
		{
			if (string.IsNullOrWhiteSpace(sellerName))
			{
				return db.Transactions.Where(x =>
					x.TimeStamp.Date >= startDate.Date &&
					x.TimeStamp.Date <= endDate.Date);
			} else
			{
				return db.Transactions.Where(x =>
					EF.Functions.Like(x.SellerName, $"%{sellerName}%") &&
					x.TimeStamp.Date >= startDate.Date &&
					x.TimeStamp.Date <= endDate.Date);
			}
		}
	}
}
