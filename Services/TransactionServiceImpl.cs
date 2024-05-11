using BatDongSan.Models;

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
                TransactionType = c.TransactionType,
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
