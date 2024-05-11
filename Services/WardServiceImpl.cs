using BatDongSan.Models;

namespace BatDongSan.Services
{
    public class WardServiceImpl : WardService
    {
        private DatabaseContext db;
        public WardServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public bool create(Ward ward)
        {
            try
            {
                db.Wards.Add(ward);
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
                db.Wards.Remove(db.Wards.Find(id));
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            return db.Wards.Select(c => new
            {
                Id = c.Id,
                WardName = c.WardName ,
                IdStreet = c.IdStreet ,
            }).ToList();
        }

        public bool update(Ward ward)
        {
            try
            {
                db.Entry(ward).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
