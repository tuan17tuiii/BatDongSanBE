using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface StreetService
    {
        public dynamic findAll();
        public bool create(Street street);
        public bool update(Street street);
        public bool delete(int id);
    }
}
