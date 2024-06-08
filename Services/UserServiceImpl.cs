
﻿using BatDongSan.Helpers;
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

				var content = "Nhan vao <a href='http://localhost:4200/verify;securityCode=" + SecurityCode + ";username=" + user.Username + "' >day</a> de kich hoat tai khoan";
				var mailHelper = new MailHelper(configuration);

                if (mailHelper.Send("hankanderson2201@gmail.com", user.Email, "Verify", content))
                {
					db.Users.Add(user);
					return true;
                }
                else { 
                    return false; 
                }

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
				StatusUpdate = c.Statusupdate,
				avatar = configuration["ImageUrl"] + c.Avatar,
				Advertisement =c.Advertisement != null ?  new
				{
					Id = c.Advertisement.Id ,
					Name = c.Advertisement.AdvertisementName,
					QuantityDates = c.Advertisement.Quantitydate,
				}:null,
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

    }
}
