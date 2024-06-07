using BatDongSan.Models;
using Microsoft.EntityFrameworkCore;
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
			catch (Exception ex)
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
			return db.Realestates.OrderByDescending(c => c.Id).Where(r => r.Status == true && r.Expired == false && r.Sold == false).Select(c => new
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
				transaction_Type = c.TransactionType,
				Usersell_Id = c.UsersellId,
				TypeRealState = c.TypeNavigation.Type,
				Nameusersell = c.Usersell.Name,
				image = c.ImageRealestates.Where(x => x.RealestateId == c.Id).Select(a => new
				{
					Id = a.Id,
					urlImage = a.UrlImage// Thêm các trường cần thiết khác từ ImageRealestate

				}).ToList(),
			}).ToList();
		}

		public dynamic findAll2()
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
				Bathrooms = c.Bathrooms,
				Status = c.Status,
				CreatedAt = c.CreatedAt,
				City = c.City,
				Region = c.Region,
				Street = c.Street,
				transaction_Type = c.TransactionType,
				Usersell_Id = c.UsersellId,
				sold = c.Sold,
				expired = c.Expired,
				created_end = c.CreatedEnd,
				TypeRealState = c.TypeNavigation.Type,
				Nameusersell = c.Usersell.Name,
				image = c.ImageRealestates.Where(x => x.RealestateId == c.Id).Select(a => new
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

		public dynamic findByType(int id)
		{
			return db.Realestates.Where(p => p.Type == id).Select(c => new
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

	
		public dynamic findByUserSell(int id)
		{
			return db.Realestates.Where(p => p.UsersellId == id).Select(c => new
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
				transaction_type = c.TransactionType,
				Usersell_Id = c.UsersellId,
				TypeRealState = c.TypeNavigation.Type,
				Nameusersell = c.Usersell.Name,
				image = c.ImageRealestates.Where(x => x.RealestateId == c.Id).Select(a => new
				{
					Id = a.Id,
					urlImage = a.UrlImage// Thêm các trường cần thiết khác từ ImageRealestate

				}).ToList(),
			}).ToList();
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

                LastImage = c.ImageRealestates.Select(img => new {
                    img.Id,
                    img.UrlImage, // Giả sử thuộc tính này tồn tại
                    
                }).FirstOrDefault()

			}).ToList();
		}

		public dynamic findByUserSellTrue(int id)
		{
			return db.Realestates.Where(p => p.UsersellId == id && p.Status == true).Select(c => new
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

                LastImage = c.ImageRealestates.Select(img => new {
                    img.Id,
                    img.UrlImage, // Giả sử thuộc tính này tồn tại

				}).FirstOrDefault(),
				Usersell_Id = c.UsersellId,
				TypeRealState = c.TypeNavigation.Type
			}).ToList();
		}

		public void MarkExpired()
		{
			var itemsToExpire = db.Realestates.Where(r => DateTime.Now > r.CreatedEnd).ToList();
			foreach (var item in itemsToExpire)
			{
				item.Expired = true;
			}
			db.SaveChanges();
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
        public dynamic totalById(int id)
        {
            return db.Realestates.Where(p => p.UsersellId == id).Select(c => new
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
            }).ToList();
        }

		public dynamic search(string key)
		{
			return db.Realestates.Where(p => p.Title == key || p.Acreage ==float.Parse(key)||p.Price==float.Parse(key)).Select(c => new
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
				transaction_type = c.TransactionType,
				Usersell_Id = c.UsersellId,
				TypeRealState = c.TypeNavigation.Type,
				Nameusersell = c.Usersell.Name,
				image = c.ImageRealestates.Where(x => x.RealestateId == c.Id).Select(a => new
				{
					Id = a.Id,
					urlImage = a.UrlImage// Thêm các trường cần thiết khác từ ImageRealestate

				}).ToList(),
			}).ToList();
		}

		public dynamic searchfilter(string? key, string? address, string? pricemin, string? pricemax, string? areamin, string? areamax)
		{
			// Kiểm tra và chuyển đổi các giá trị chuỗi sang kiểu dữ liệu phù hợp
			bool keyParsed = float.TryParse(key, out float keyFloat);
			bool priceminParsed = float.TryParse(pricemin, out float priceminFloat);
			bool pricemaxParsed = float.TryParse(pricemax, out float pricemaxFloat);
			bool areaminParsed = float.TryParse(areamin, out float areaminFloat);
			bool areamaxParsed = float.TryParse(areamax, out float areamaxFloat);

			return db.Realestates.Where(p =>
				// Kiểm tra điều kiện của 'key'
				(
					(string.IsNullOrEmpty(key) ||
					 p.Title.Contains(key) ||
					 p.City.Contains(key) ||
					 (keyParsed && (p.Acreage >= keyFloat || p.Price >= keyFloat))
					) &&
					// Kiểm tra các điều kiện khác
					(
						(string.IsNullOrEmpty(address) || p.City.Contains(address)) &&
						(!priceminParsed || p.Price >= priceminFloat) &&
						(!pricemaxParsed || p.Price <= pricemaxFloat) &&
						(!areaminParsed || p.Acreage >= areaminFloat) &&
						(!areamaxParsed || p.Acreage <= areamaxFloat)
					)
				)
			).Select(c => new
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
				transaction_type = c.TransactionType,
				UsersellId = c.UsersellId,
				TypeRealState = c.TypeNavigation.Type,
				Nameusersell = c.Usersell.Name,
				image = c.ImageRealestates.Where(x => x.RealestateId == c.Id).Select(a => new
				{
					Id = a.Id,
					urlImage = a.UrlImage // Thêm các trường cần thiết khác từ ImageRealestate
				}).ToList(),
			}).ToList();
		}


	}
}
