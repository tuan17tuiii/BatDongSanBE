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

        public dynamic findById(int id)
        {
            return db.Roles.Where(c => c.Id == id).Select(c => new
            {
                Id = c.Id,
                Name = c.Name,
            }).FirstOrDefault();//ko co firstordefault la tra ve list còn có là trả về đối tượng 
        }

        public bool update(Role role)
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
