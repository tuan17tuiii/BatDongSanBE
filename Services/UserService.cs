using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface UserService
    {
        public dynamic findAll();
		public dynamic findAllAdmin();
		public dynamic findAllUser();
		public dynamic findAllAgent();
		public dynamic findByUsername(string username);
		public dynamic findById(int id);
		public dynamic Verify(string code, string username);
		public dynamic PasswordVerify(string password, string username);
		public bool Login(string username, string password);
		public bool ChangePass(string password, string username);
		public bool AccountExists(string username, string email);
		public bool updatePhoto(int id, string photo);
		public bool create(User user);
        public bool update(User user);
        public bool delete(int id);
    }
}
