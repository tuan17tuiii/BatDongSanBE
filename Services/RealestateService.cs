using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface RealestateService
    {
        public dynamic findAll();
        public bool create(Realestate realestate);
        public bool update(Realestate realestate);
        public bool delete(int id);
    }
}
