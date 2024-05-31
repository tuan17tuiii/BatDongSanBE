using BatDongSan.Models;
using System.Diagnostics;

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
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
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
<<<<<<< HEAD
                Street = c.Street,
                Usersell_Id = c.UsersellId,
                TypeRealState = c.TypeNavigation.Type,
                Nameusersell=c.Usersell.Name,
                transaction_type = c.TransactionType , 
=======
                Street = c.Street,	
                transaction_type = c.TransactionType ,
                Usersell_Id = c.UsersellId,
                TypeRealState = c.TypeNavigation.Type,
                Nameusersell=c.Usersell.Name,
>>>>>>> 4800974bf50f7deef1b2e6627bc174e7390dae23
                image = c.ImageRealestates.Where(x=>x.RealestateId==c.Id).Select(a => new
                {
					Id = a.Id,
					urlImage = a.UrlImage// Thêm các trường cần thiết khác từ ImageRealestate
				    
			}).ToList(),
			}).ToList();
        }

        public dynamic findByCityRegion(string city, string region)
        {
            return db.Realestates.Where(p => p.City == city && p.Region == region).Select(c => new
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
<<<<<<< HEAD

=======
>>>>>>> 4800974bf50f7deef1b2e6627bc174e7390dae23
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
                Usersell_Id = c.UsersellId,
                TypeRealState = c.TypeNavigation.Type
            }).SingleOrDefault();
        }

        public dynamic findByUserSellFalse(int id)
        {
            return db.Realestates.Where(p => p.UsersellId == id && p.Status == false).Select(c => new
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
                Usersell_Id = c.UsersellId,
                TypeRealState = c.TypeNavigation.Type,

                LastImage = c.ImageRealestates.OrderByDescending(img => img.Id).Select(img => new {
                    img.Id,
                    img.UrlImage, // Giả sử thuộc tính này tồn tại
                    
                }).FirstOrDefault()

            }).ToList();
        }

        public dynamic findByUserSellTrue(int id)
        {
            return db.Realestates.Where(p => p.UsersellId == id && p.Status == true ).Select(c => new
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
<<<<<<< HEAD

=======
>>>>>>> 4800974bf50f7deef1b2e6627bc174e7390dae23
                LastImage = c.ImageRealestates.OrderByDescending(img => img.Id).Select(img => new {
                    img.Id,
                    img.UrlImage, // Giả sử thuộc tính này tồn tại

                }).FirstOrDefault(),
                Usersell_Id = c.UsersellId,
                TypeRealState = c.TypeNavigation.Type
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
