using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface AdvertisementService
    {
        public dynamic findAll();
		public dynamic findById(int id);
		public dynamic searchByName(string name);
		public bool create(Advertisement advertisement);
        public bool update(Advertisement advertisement);
        public bool delete(int id);
    }
}
