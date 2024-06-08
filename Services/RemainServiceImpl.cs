using BatDongSan.Models;
using System.Data;
using System.Diagnostics;

namespace BatDongSan.Services
{
    public class RemainServiceImpl : RemainService
    {
        private DatabaseContext db;
        public RemainServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public bool create(Remain remain)
        {
            try
            {
                db.Remains.Add(remain);
                return db.SaveChanges()>0 ;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return false ;
            }
        }

        public bool delete(int id)
        {
            try
            {
                db.Remains.Remove(db.Remains.Find(id));
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
        
        public dynamic findAll()
        {
            return db.Remains.Select(c => new
            {
                id = c.Id,
                idUser = c.IdUser,
                idAdv = c.IdAdv,
                remaining = c.Remaining,
            }).ToList();
        }

        public dynamic findById(int id)
        {
            return db.Remains.Where(c => c.IdUser == id).Select(c => new
            {
                Id = c.Id,
                idUser = c.IdUser ,
                idAdv = c.IdAdv , 
                remaining = c.Remaining,
                createdend = c.Createdend,
            }).FirstOrDefault();//ko co firstordefault la tra ve list còn có là trả về đối tượng 
        }

        public bool update(Remain remain)
        {
            try
            {
                db.Entry(remain).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }
    }
}
