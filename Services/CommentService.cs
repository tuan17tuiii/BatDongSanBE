using BatDongSan.Models;

namespace BatDongSan.Services
{
    public interface CommentService
    {
        public dynamic findAll();
        public bool create(Comment comment);
        public bool update(Comment comment);
        public bool delete(int id);
    }
}
