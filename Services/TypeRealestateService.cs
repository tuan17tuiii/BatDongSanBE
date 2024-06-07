using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface TypeRealestateService
    {
        public dynamic findAll();
		public dynamic findById(int id);
		public bool create(TypeRealestate typeRealestate);
        public bool update(TypeRealestate typeRealestate);
        public bool delete(int id);
    }
}
