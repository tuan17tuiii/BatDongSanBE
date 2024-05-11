using BatDongSan.Models;

namespace BatDongSan.Services
{
    public class CityServiceImpl : CityService
    {
        private DatabaseContext db;
        public CityServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public bool create(City city)
        {
            try
            {
                db.Cities.Add(city);
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
                db.Cities.Remove(db.Cities.Find(id));
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            return db.Cities.Select(c => new
            {
                Id = c.Id,
                CityName = c.CityName
            }).ToList();
        }

        public bool update(City city)
        {
            try
            {
                db.Entry(city).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
