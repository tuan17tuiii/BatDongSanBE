
using BatDongSan.Helpers;
using BatDongSan.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Security;

namespace BatDongSan.Services
{
	public class UserServiceImpl : UserService
	{
		private DatabaseContext db;
		private IConfiguration configuration;
<<<<<<< HEAD


=======
>>>>>>> 6027ce989e59b07495f889d719a96ee3c77bb009
		public UserServiceImpl(DatabaseContext _db, IConfiguration _configuration)
		{
			db = _db;
			this.configuration = _configuration;
		}
		public bool create(User user)
		{
			try
			{
				var hashpassword = BCrypt.Net.BCrypt.HashString(user.Password);
				user.Password = hashpassword;
				user.Status = false;
				var SecurityCode = RandomHelper.GenerateScurityCode();
				user.SecurityCode = SecurityCode;
				user.Avatar = "NoImage.jpg";
<<<<<<< HEAD

=======
				user.Statusupdate = false;
>>>>>>> 6027ce989e59b07495f889d719a96ee3c77bb009

				var content = "Nhan vao <a href='http://localhost:4200/verify;securityCode=" + SecurityCode + ";username=" + user.Username + "' >day</a> de kich hoat tai khoan";
				var mailHelper = new MailHelper(configuration);

<<<<<<< HEAD

				if (mailHelper.Send("hankanderson2201@gmail.com", user.Email, "Verify", content))
				{
					db.Users.Add(user);
					return db.SaveChanges() > 0;
				}
				else
				{
					return false;
				}



=======
                if (mailHelper.Send("hankanderson2201@gmail.com", user.Email, "Verify", content))
                {
                    db.Users.Add(user);
                    return db.SaveChanges() > 0;
                }
                else
                {
                    return false;
                }
>>>>>>> 6027ce989e59b07495f889d719a96ee3c77bb009
			}
			catch
			{
				return false;
			}
		}

<<<<<<< HEAD

		public bool delete(int id)
=======
		public bool delete(int id)
		{
			try
			{
				db.Users.Remove(db.Users.Find(id));
				return db.SaveChanges() > 0;
			}
			catch
			{
				return false;
			}
		}

		public dynamic findAll()
        {
            return db.Users.Select(c => new
            {
                Id = c.Id,
                Username = c.Username,
                Password = c.Password,
                Name = c.Name,
                Phone = c.Phone,
                RoleId = c.RoleId,
                AdvertisementId = c.AdvertisementId,
                Status = c.Status,
                securityCode = c.SecurityCode,
                email = c.Email,
                StatusUpdate = c.Statusupdate,
                avatar = configuration["ImageUrl"] + c.Avatar
            }).ToList();
        }
        public dynamic findAllAdmin()
        {
            return db.Users.Where(c => c.RoleId == 1).Select(c => new
            {
                Id = c.Id,
                Username = c.Username,
                Password = c.Password,
                Name = c.Name,
                Phone = c.Phone,
                RoleId = c.RoleId,
                AdvertisementId = c.AdvertisementId,
                Status = c.Status,
                securityCode = c.SecurityCode,
                email = c.Email,
                StatusUpdate = c.Statusupdate,
                avatar = configuration["ImageUrl"] + c.Avatar
            }).ToList();
        }

        public dynamic findAllUser()
        {
            return db.Users.Where(c => c.RoleId == 2).Select(c => new
            {
                Id = c.Id,
                Username = c.Username,
                Password = c.Password,
                Name = c.Name,
                Phone = c.Phone,
                RoleId = c.RoleId,
                AdvertisementId = c.AdvertisementId,
                Status = c.Status,
                securityCode = c.SecurityCode,
                email = c.Email,
                StatusUpdate = c.Statusupdate,
                avatar = configuration["ImageUrl"] + c.Avatar,
            }).ToList();
        }

        public dynamic findAllAgent()
        {
            return db.Users.Where(c => c.RoleId == 4).Select(c => new
            {
                Id = c.Id,
                Username = c.Username,
                Password = c.Password,
                Name = c.Name,
                Phone = c.Phone,
                RoleId = c.RoleId,
                AdvertisementId = c.AdvertisementId,
                Status = c.Status,
                securityCode = c.SecurityCode,
                email = c.Email,
                StatusUpdate = c.Statusupdate,
                avatar = configuration["ImageUrl"] + c.Avatar
            }).ToList();
        }

        public dynamic Verify(string code, string username)
        {
            try
            {
                var user = db.Users.SingleOrDefault(c => c.SecurityCode == code && c.Username == username);

                if (user != null)
                {
                    user.Status = true;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public dynamic findByUsername(string username)
        {
            return db.Users.Where(c => c.Username == username).Select(c => new
            {
                Id = c.Id,
                Username = c.Username,
                Password = c.Password,
                Name = c.Name,
                Phone = c.Phone,
                RoleId = c.RoleId,
                AdvertisementId = c.AdvertisementId,
                Status = c.Status,
                securityCode = c.SecurityCode,
                email = c.Email,
                Advertisement = c.Advertisement != null ? new
                {
                    Id = c.Advertisement.Id,
                    Name = c.Advertisement.AdvertisementName,
                    QuantityDates = c.Advertisement.Quantitydate,
                    Price = c.Advertisement.Price
                } : null,
                avatar = configuration["ImageUrl"] + c.Avatar,
                StatusUpdate = c.Statusupdate,

            }).FirstOrDefault();
        }

        public bool update(User user)
        {
            try
            {
                db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }


        public bool Login(string username, string password)
        {
            var account = db.Users.SingleOrDefault(c => c.Username == username && c.Status == true);
            if (account != null)
            {
                return BCrypt.Net.BCrypt.Verify(password, account.Password);
            }
            return false;
        }

        public dynamic findById(int id)
        {
            return db.Users.Where(c => c.Id == id).Select(c => new
            {
                Id = c.Id,
                Username = c.Username,
                Password = c.Password,
                Name = c.Name,
                Phone = c.Phone,
                RoleId = c.RoleId,
                AdvertisementId = c.AdvertisementId,
                Status = c.Status,
                securityCode = c.SecurityCode,
                email = c.Email,
                StatusUpdate = c.Statusupdate,
                avatar = configuration["ImageUrl"] + c.Avatar,
                image = c.ImageRealestates.Where(img => img.Userid == c.Id).Select(img => new
                {
                    Userid = img.Userid,
                    UrlImage = configuration["ImageUrl"] + img.UrlImage
                }).ToList()
            }).FirstOrDefault();
        }

        public dynamic PasswordVerify(string password, string username)
        {
            var account = db.Users.SingleOrDefault(c => c.Username == username);
            if (account != null)
            {
                return BCrypt.Net.BCrypt.Verify(password, account.Password);
            }
            return false;
        }

        public bool ChangePass(string password, string username)
        {
            var user = db.Users.SingleOrDefault(u => u.Username == username);
            if (user != null)
            {
                user.Password = BCrypt.Net.BCrypt.HashString(password);
                return db.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public bool AccountExists(string username, string email)
        {
            var user = db.Users.SingleOrDefault(u => u.Username == username || u.Email == email);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool updatePhoto(int id, string photo)
        {
            try
            {
                var user = db.Users.Find(id);
                user.Avatar = photo;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

		public dynamic SearchByUsername(string username, int role)
>>>>>>> 6027ce989e59b07495f889d719a96ee3c77bb009
		{
			return db.Users.Where(c => c.Username.Contains(username) && c.RoleId == role).Select(c => new
			{
				Id = c.Id,
				Username = c.Username,
				Password = c.Password,
				Name = c.Name,
				Phone = c.Phone,
				RoleId = c.RoleId,
				AdvertisementId = c.AdvertisementId,
				Status = c.Status,
				securityCode = c.SecurityCode,
				email = c.Email,
				Advertisement = c.Advertisement != null ? new
				{
					Id = c.Advertisement.Id,
					Name = c.Advertisement.AdvertisementName,
					QuantityDates = c.Advertisement.Quantitydate,
					Price = c.Advertisement.Price
				} : null,
				avatar = configuration["ImageUrl"] + c.Avatar,
				StatusUpdate = c.Statusupdate,

			}).ToList();
		}

		public dynamic SearchByEmail(string email, int role)
		{
			return db.Users.Where(c => c.Email.Contains(email) && c.RoleId == role).Select(c => new
			{
				Id = c.Id,
				Username = c.Username,
				Password = c.Password,
				Name = c.Name,
				Phone = c.Phone,
				RoleId = c.RoleId,
				AdvertisementId = c.AdvertisementId,
                Advertisement = c.Advertisement != null ? new
                {
                    Id = c.Advertisement.Id,
                    Name = c.Advertisement.AdvertisementName,
                    QuantityDates = c.Advertisement.Quantitydate,
                } : null,
                Status = c.Status,
				securityCode = c.SecurityCode,
				email = c.Email,
				Advertisement = c.Advertisement != null ? new
				{
					Id = c.Advertisement.Id,
					Name = c.Advertisement.AdvertisementName,
					QuantityDates = c.Advertisement.Quantitydate,
					Price = c.Advertisement.Price
				} : null,
				avatar = configuration["ImageUrl"] + c.Avatar,
				StatusUpdate = c.Statusupdate,

			}).ToList();
		}
	}
}
<<<<<<< HEAD

=======
>>>>>>> 6027ce989e59b07495f889d719a96ee3c77bb009
