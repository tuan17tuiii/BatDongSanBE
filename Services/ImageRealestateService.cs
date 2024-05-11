using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface ImageRealestateService

    {
        public dynamic findAll();
        public bool create(ImageRealestate imageRealestate);
        public bool update(ImageRealestate imageRealestate);
        public bool delete(int id);
    }
}
