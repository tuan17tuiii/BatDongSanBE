using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface AdvertisementService
    {
        public dynamic findAll();
        public bool create(Advertisement advertisement);
        public bool update(Advertisement advertisement);
        public bool delete(int id);
    }
}
