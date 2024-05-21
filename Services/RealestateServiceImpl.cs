using BatDongSan.Models;

namespace BatDongSan.Services
{
    public class RealestateServiceImpl : RealestateService
    {
        private DatabaseContext db;
        public RealestateServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public int create(Realestate realestate)
        {
            try
            {
                db.Realestates.Add(realestate);
                db.SaveChanges();
                return realestate.Id;

            }
            catch
            {
                return -1;
            }
        }

        public bool delete(int id)
        {
            try
            {
                db.Realestates.Remove(db.Realestates.Find(id));
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            return db.Realestates.Select(c => new
            {
                Id = c.Id,
                Title = c.Title,
                Describe = c.Describe,
                Price = c.Price,
                Type = c.Type,
                Acreage = c.Acreage,
                Bedrooms = c.Bedrooms,
                Bathrooms = c.Bathrooms ,
                Status = c.Status,
                CreatedAt = c.CreatedAt, 
                Userbuy_Id = c.UserbuyId,
                Usersell_Id = c.UsersellId,
            }).ToList();
        }

        public bool update(Realestate realestate)
        {
            try
            {
                db.Entry(realestate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
