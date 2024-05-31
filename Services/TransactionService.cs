using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface TransactionService
    {
        public dynamic findAll();
        public dynamic dateRange(string from, string to);
		public dynamic Today(string date);
		public bool create(Transaction transaction);
        public bool update(Transaction transaction);
        public bool delete(int id);
    }
}
