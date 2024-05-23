using BatDongSan.Models;
using System.Diagnostics;

namespace BatDongSan.Services
{
    public class ImageRealestateServiceImpl : ImageRealestateService
    {
        private DatabaseContext db;
        public ImageRealestateServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public bool create(ImageRealestate imageRealestate)
        {
            try
            {
                db.ImageRealestates.Add(imageRealestate);
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
                db.ImageRealestates.Remove(db.ImageRealestates.Find(id));
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            try
            {
                // Lấy tất cả dữ liệu vào bộ nhớ trước khi thực hiện GroupBy
                var allImages = db.ImageRealestates.ToList();

                // Thực hiện GroupBy và lấy ảnh đầu tiên từ mỗi nhóm
                var groupedData = allImages
                                  .GroupBy(c => c.RealestateId)
                                  .Select(g => g.FirstOrDefault())
                                  .Where(c => c != null)
                                  .ToList();

                // Chuyển đổi dữ liệu thành đối tượng ẩn danh
                var result = groupedData
                             .Select(c => new
                             {
                                 Id = c.Id,
                                 RealestateId = c.RealestateId,
                                 UrlImage = c.UrlImage,
                             }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }


        public dynamic findById(int id)
        {
            throw new NotImplementedException();
        }

        public bool update(ImageRealestate imageRealestate)
        {
            try
            {
                db.Entry(imageRealestate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
