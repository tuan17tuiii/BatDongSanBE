<<<<<<< HEAD

=======
>>>>>>> 4c053e2dbe75d7c5eb0f02a12492c9f605ae8dab
using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface RealestateService
    {
        public dynamic findAll();
<<<<<<< HEAD

		public dynamic search(string key);
        public dynamic searchfilter(string? key, string? address,string? pricemin,string? pricemax, string? areamin, string? areamax);
		public dynamic findAll2();
		public dynamic findById(int id);
        public dynamic findByUserSellTrue(int id);
		public dynamic findByUserSell(int id);
=======
		public dynamic findAll2();
		public dynamic findById(int id);
        public dynamic findByUserSellTrue(int id);
        
		public dynamic findByUserSell(int id);
		
>>>>>>> 4c053e2dbe75d7c5eb0f02a12492c9f605ae8dab
        public dynamic findByUserSellFalse(int id);
        public dynamic findByCityRegion(string city , string region);
        public dynamic findByType(int id);
		public int create(Realestate realestate);
        public bool update(Realestate realestate);
        public bool delete(int id);
        public void MarkExpired();
        public dynamic totalById(int id);
<<<<<<< HEAD

    }
}

=======
        public dynamic searchfilter(string? key, string? address, string? pricemin, string? pricemax, string? areamin, string? areamax);


	}
}
>>>>>>> 4c053e2dbe75d7c5eb0f02a12492c9f605ae8dab
