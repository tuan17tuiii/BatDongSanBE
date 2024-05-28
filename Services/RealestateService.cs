using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface RealestateService
    {
        public dynamic findAll();
        public dynamic findById(int id);
        public dynamic findByCityRegion(string city , string region);
        public int create(Realestate realestate);
        public bool update(Realestate realestate);
        public bool delete(int id);
    }
}
