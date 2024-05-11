using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface RegionService
    {
        public dynamic findAll();
        public bool create(Region region);
        public bool update(Region region);
        public bool delete(int id);
    }
}
