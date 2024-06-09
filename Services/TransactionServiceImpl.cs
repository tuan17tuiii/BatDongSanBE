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
            throw new NotImplementedException();
        }

        public dynamic dateRange(string from, string to)
        {
            throw new NotImplementedException();
        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool update(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
