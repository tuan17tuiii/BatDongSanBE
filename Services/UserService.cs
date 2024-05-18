﻿using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface UserService
    {
        public dynamic findAll();
		public dynamic findAllAdmin();
		public dynamic findAllUser();
		public dynamic findByUsername(string username);
		public dynamic Verify(string code, string username);
        public bool LoginAdmin(string username, string password);
		public bool create(User user);
        public bool update(User user);
        public bool delete(int id);
    }
}
