using BatDongSan.Models;
using Microsoft.AspNetCore.Mvc;

namespace BatDongSan.Services
{
    public class TypeRealestateServiceImpl : TypeRealestateService
    {
        private DatabaseContext db;
        public TypeRealestateServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public bool create(TypeRealestate typeRealestate)
        {
            try
            {
                db.TypeRealestates.Add(typeRealestate);
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
                db.TypeRealestates.Remove(db.TypeRealestates.Find(id));
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            return db.TypeRealestates.Select(c => new
            {
                Id = c.Id,
                Type = c.Type,
            }).ToList();
        }

		public dynamic findById(int id)
		{
			return db.TypeRealestates.Where(c => c.Id == id).Select(c => new
			{
				Id = c.Id,
				Type = c.Type,
			}).SingleOrDefault();
		}

		public bool update(TypeRealestate typeRealestate)
        {
            try
            {
                db.Entry(typeRealestate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
