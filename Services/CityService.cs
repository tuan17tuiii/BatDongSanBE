using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface CityService
    {
        public dynamic findAll();
        public bool create(City city);
        public bool update(City city);
        public bool delete(int id);
    }
}
