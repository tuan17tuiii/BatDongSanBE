using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface WardService
    {
        public dynamic findAll();
        public bool create(Ward ward);
        public bool update(Ward ward);
        public bool delete(int id);
    }
}
