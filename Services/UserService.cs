using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface UserService
    {
        public dynamic findAll();
        public bool create(User user);
        public bool update(User user);
        public bool delete(int id);
    }
}
