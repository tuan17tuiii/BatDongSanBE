using BatDongSan.Models;

namespace BatDongSan.Services
{
    public class RoleServiceImpl : RoleService
    {
        private DatabaseContext db;
        public RoleServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public bool create(Role role)
        {
            try
            {
                db.Roles.Add(role);
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
                db.Roles.Remove(db.Roles.Find(id));
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            return db.Roles.Select(c => new
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }

        public bool update(Role role)
        {
            {
                try
                {
                    db.Entry(role).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    return db.SaveChanges() > 0;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
