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

				var content = "Nhan vao <a href='http://localhost:4200/verify;securityCode=" + SecurityCode + ";username=" + user.Username + "' >day</a> de kich hoat tai khoan";
				var mailHelper = new MailHelper(configuration);

                if (mailHelper.Send("hankanderson2201@gmail.com", user.Email, "Verify", content))
                {
					db.Users.Add(user);
					return db.SaveChanges() > 0;
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

		public bool LoginAdmin(string username, string password)
		{
			var account = db.Users.SingleOrDefault(c => c.Username == username && c.Status == true && c.RoleId == 1);
			if (account != null)
			{
				return BCrypt.Net.BCrypt.Verify(password, account.Password);
			}
			return false;
		}
	}
}