using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface NewsService
    {
        public dynamic findAll();
        public int create(News news);
        public bool update(News news);
        public bool delete(int id);
        public dynamic findById(int id);
    }
}
