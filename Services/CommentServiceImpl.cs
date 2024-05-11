using BatDongSan.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BatDongSan.Services
{
    public class CommentServiceImpl : CommentService
    {
        private DatabaseContext db;
        public CommentServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public bool create(Comment comment)
        {
            try
            {
                db.Comments.Add(comment);
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
                db.Comments.Remove(db.Comments.Find(id));
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            return db.Comments.Select(c => new
            {
                Id = c.Id,
                UserId = c.UserId,
                BatdongsanId = c.BatdongsanId,
                Content = c.Content,
                CreatedAt = c.CreatedAt
            }).ToList();
        }

        public bool update(Comment comment)
        {
            try
            {
                db.Entry(comment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
