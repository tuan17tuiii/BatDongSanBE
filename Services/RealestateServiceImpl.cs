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
            return db.Realestates.OrderByDescending(c => c.Id).Select(c => new
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
                City = c.City,
                Region = c.Region,
                Street = c.Street,
                Userbuy_Id = c.UserbuyId,
                Usersell_Id = c.UsersellId,
                TypeRealState = c.TypeNavigation.Type
            }).ToList();
        }

        public dynamic findById(int id)
        {
            return db.Realestates.Where(p => p.Id == id).OrderByDescending(c => c.Id).Select(c => new
            {
                Id = c.Id,
                Title = c.Title,
                Describe = c.Describe,
                Price = c.Price,
                Type = c.Type,
                Acreage = c.Acreage,
                Bedrooms = c.Bedrooms,
                Bathrooms = c.Bathrooms,
                Status = c.Status,
                CreatedAt = c.CreatedAt,
                City = c.City,
                Region = c.Region,
                Street = c.Street,
                Userbuy_Id = c.UserbuyId,
                Usersell_Id = c.UsersellId,
                TypeRealState = c.TypeNavigation.Type
            }).SingleOrDefault();
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
