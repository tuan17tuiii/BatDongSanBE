using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface RoleService
    {
        public dynamic findAll();
        public bool create(Role role);
        public bool update(Role role);
        public bool delete(int id);
    }
}
