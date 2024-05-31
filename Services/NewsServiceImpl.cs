using BatDongSan.Models;

namespace BatDongSan.Services
{
    public class NewsServiceImpl : NewsService
    {
        private DatabaseContext db;
        public NewsServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public int create(News news)
        {
            try
            {
                db.News.Add(news);
				db.SaveChanges();
                News newss= db.News.OrderByDescending(x=>x.Id).FirstOrDefault();
				if (newss != null)
				{
					return newss.Id;
				}
				else
				{
					// Xử lý trường hợp không tìm thấy bản ghi nào
					throw new Exception("Could not retrieve the newly added news.");
				}
			
            }
            catch
            {
                return -1;
            }
        }

        public bool delete(int id)
        {
            try
            {
                db.News.Remove(db.News.Find(id));
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            return db.News.Select(c => new
            {
                Id = c.Id,
                Content = c.Content,
                Title=c.Title,
                Tag=c.Tag,
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

        public bool update(News news)
        {
            
                try
                {
                    db.Entry(news).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    return db.SaveChanges() > 0;
                }
                catch
                {
                    return false;
                }
            
        }
    }
}
