using BatDongSan.Models;

namespace BatDongSan.Services
{
    public class StreetServiceImpl : StreetService
    {
        private DatabaseContext db;
        public StreetServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public bool create(Street street)
        {
            try
            {
                db.Streets.Add(street);
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
                db.Streets.Remove(db.Streets.Find(id));
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            return db.Streets.Select(c => new
            {
                Id = c.Id,
                StreetName = c.StreetName,
                IdRegion = c.IdRegion,
            }).ToList();
        }

        public bool update(Street street)
        {
            try
            {
                db.Entry(street).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
