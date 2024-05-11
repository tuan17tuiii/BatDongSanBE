using BatDongSan.Models;

namespace BatDongSan.Services
{
    public class RegionServiceImpl : RegionService
    {
        private DatabaseContext db;
        public RegionServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public bool create(Region region)
        {
            try
            {
                db.Regions.Add(region);
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
                db.Regions.Remove(db.Regions.Find(id));
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            return db.Regions.Select(c => new
            {
                Id = c.Id,
                RegionName = c.RegionName,
                IdCity = c.IdCity,
            }).ToList();
        }

        public bool update(Region region)
        {
            try
            {
                db.Entry(region).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
