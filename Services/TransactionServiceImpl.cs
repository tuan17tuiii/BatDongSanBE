using BatDongSan.Models;
using System.Globalization;

namespace BatDongSan.Services
{
    public class TransactionServiceImpl : TransactionService
    {
        private DatabaseContext db;
        public TransactionServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public bool create(Transaction transaction)
        {
            try
            {
                db.Transactions.Add(transaction);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

		public dynamic dateRange(string from, string to)
		{
			var dateFrom = DateTime.ParseExact(from, "dd-MM-yyyy", CultureInfo.InvariantCulture);

			var dateTo = DateTime.ParseExact(to, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            return db.Transactions.Where(p => p.TransactionDate >= dateFrom && p.TransactionDate <= dateTo).Select(c => new
			{
				Id = c.Id,
				BuyerId = c.BuyerId,
				SellerId = c.SellerId,
				TransactionDate = c.TransactionDate,
				Amount = c.Amount,
				RealestateId = c.RealestateId,
			}).ToList();
		}

		public dynamic Today(string date)
		{
			var today = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

			return db.Transactions.Where(p => p.TransactionDate == today).Select(c => new
			{
				Id = c.Id,
				BuyerId = c.BuyerId,
				SellerId = c.SellerId,
				TransactionDate = c.TransactionDate,
				Amount = c.Amount,
				RealestateId = c.RealestateId,
			}).ToList().Take(4);
		}

		public bool delete(int id)
        {
            try
            {
                db.Transactions.Remove(db.Transactions.Find(id));
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            return db.Transactions.Select(c => new
            {
                Id = c.Id,
                BuyerId = c.BuyerId,
                SellerId = c.SellerId,
                TransactionDate = c.TransactionDate,
                Amount = c.Amount,
                RealestateId =c.RealestateId,
            }).ToList();
        }

        public bool update(Transaction transaction)
        {
            try
            {
                db.Entry(transaction).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
