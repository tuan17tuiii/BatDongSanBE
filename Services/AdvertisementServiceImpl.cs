using BatDongSan.Models;

namespace BatDongSan.Services
{
    public class AdvertisementServiceImpl : AdvertisementService
    {
        private DatabaseContext db;
        public AdvertisementServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public bool create(Advertisement advertisement)
        {
            try
            {
                db.Advertisements.Add(advertisement);
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
                db.Advertisements.Remove(db.Advertisements.Find(id));
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            return db.Advertisements.Select(c => new
            {
                Id = c.Id,
                AdvertisementName = c.AdvertisementName,
                Price = c.Price,
                Describe = c.Describe,
                Time  = c.Time,
                Status = c.Status,
            }).ToList();
        }

		public dynamic findById(int id)
		{
			return db.Advertisements.Where(c => c.Id == id).Select(c => new
			{
				Id = c.Id,
				AdvertisementName = c.AdvertisementName,
				Price = c.Price,
				Describe = c.Describe,
				Time = c.Time,
				Status = c.Status,
			}).SingleOrDefault();
		}

		public bool update(Advertisement advertisement)
        {
            try
            {
                db.Entry(advertisement).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
