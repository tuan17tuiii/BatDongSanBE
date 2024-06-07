using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface RemainService
    {
        public dynamic findAll();
        public dynamic findById(int id);
        public bool create(Remain remain);
        public bool update(Remain remain);
        public bool delete(int id);
    }
}
