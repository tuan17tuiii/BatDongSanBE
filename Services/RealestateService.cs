<<<<<<< HEAD

﻿using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface RealestateService
    {
        public dynamic findAll();
		public dynamic findAll2();
		public dynamic findById(int id);
        public dynamic findByUserSellTrue(int id);
        
		public dynamic findByUserSell(int id);
		
        public dynamic findByUserSellFalse(int id);
        public dynamic findByCityRegion(string city , string region);
        public dynamic findByType(int id);
		public int create(Realestate realestate);
        public bool update(Realestate realestate);
        public bool delete(int id);
        public void MarkExpired();
        public dynamic totalById(int id);

    }
}

=======
using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface RealestateService
    {
        public dynamic findAll();

		public dynamic search(string key);
        public dynamic searchfilter(string? key, string? address,string? pricemin,string? pricemax, string? areamin, string? areamax);
		public dynamic findAll2();
		public dynamic findById(int id);
        public dynamic findByUserSellTrue(int id);
		public dynamic findByUserSell(int id);
        public dynamic findByUserSellFalse(int id);
        public dynamic findByCityRegion(string city , string region);
        public dynamic findByType(int id);
		public int create(Realestate realestate);
        public bool update(Realestate realestate);
        public bool delete(int id);
        public void MarkExpired();
        public dynamic totalById(int id);

    }
}

>>>>>>> 10b3227b56d6d7998535024507ff17d3185b23c3
