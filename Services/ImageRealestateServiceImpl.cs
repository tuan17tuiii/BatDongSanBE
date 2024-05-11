using BatDongSan.Models;

namespace BatDongSan.Services
{
    public class ImageRealestateServiceImpl : ImageRealestateService
    {
        private DatabaseContext db;
        public ImageRealestateServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public bool create(ImageRealestate imageRealestate)
        {
            try
            {
                db.ImageRealestates.Add(imageRealestate);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool delete(int id)
        {
            try
            {
                db.ImageRealestates.Remove(db.ImageRealestates.Find(id));
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            return db.ImageRealestates.Select(c => new
            {
                Id = c.Id,
                RealestateId = c.RealestateId,
                UrlImage = c.UrlImage,
            }).ToList();
        }

        public bool update(ImageRealestate imageRealestate)
        {
            try
            {
                db.Entry(imageRealestate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
