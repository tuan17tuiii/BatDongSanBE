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
			db.Transactions.Add(transaction);
			return db.SaveChanges() > 0;
		}

		public dynamic dateRange(string from, string to)
		{
			var dateFrom = DateTime.ParseExact(from, "dd-MM-yyyy", CultureInfo.InvariantCulture);

			var dateTo = DateTime.ParseExact(to, "dd-MM-yyyy", CultureInfo.InvariantCulture);

			return db.Transactions.Where(t => t.CreatedAt >= dateFrom && t.CreatedAt <= dateTo).Select(t => new
			{
				Id = t.Id,
				IdUser = t.IdUser,
				IdAdv = t.IdAdv,
				CreatedAt = t.CreatedAt,
				Price = t.Price,
			}).ToList();

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
			return db.Transactions.Select(t => new
			{
				Id = t.Id,
				IdUser = t.IdUser,
				IdAdv = t.IdAdv,
				CreatedAt = t.CreatedAt,
				Price = t.Price,
			}).ToList();
		}

		public dynamic Today(string date)
		{
			var Today = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

			return db.Transactions.Where(t => t.CreatedAt == Today).Select(t =>new
			{
				Id = t.Id,
				IdUser = t.IdUser,
				IdAdv = t.IdAdv,
				CreatedAt = t.CreatedAt,
				Price = t.Price,
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
