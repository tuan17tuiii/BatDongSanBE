using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface RealestateService
    {
        public dynamic findAll();
		public dynamic findAll2();
		public dynamic findById(int id);
        public dynamic findByUserSellTrue(int id);
        public dynamic findByUserSellFalse(int id);
        public dynamic findByCityRegion(string city , string region);
        public int create(Realestate realestate);
        public bool update(Realestate realestate);
        public bool delete(int id);
        public void MarkExpired();
        public dynamic totalById(int id);

    }
}
