using BatDongSan.Models;

namespace BatDongSan.Services
{
    public class UserServiceImpl : UserService
    {
        private DatabaseContext db;
        public UserServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public bool create(User user)
        {
            try
            {
                db.Users.Add(user);
                return db.SaveChanges() > 0;
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
                AdvertisementId = c.AdvertisementId
            }).ToList();
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
    }
}
