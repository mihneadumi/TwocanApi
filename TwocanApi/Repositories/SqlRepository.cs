using Microsoft.EntityFrameworkCore;
using TwocanApi.Data;
using TwocanApi.Models;

namespace TwocanApi.Repositories
{
    public class SqlRepository : IRepository
    {
        public readonly DataContext _context;

        public SqlRepository(DataContext context)
        {
            _context = context;
        }

        public List<Post> GetPosts()
        {
            return _context.Posts.ToList();
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public Post GetPost(int id)
        {
            return _context.Posts.FirstOrDefault(p => p.id == id);
        }

        public void RemovePost(int id)
        {
            var post = GetPost(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
        }

        public void UpdatePost(Post post)
        {
            var existingPost = _context.Posts.FirstOrDefault(p => p.id == post.id);
            if (existingPost == null)
            {
                throw new Exception("Post not found");
            }

            if (existingPost.authorId != post.authorId)
            {
                throw new Exception("Cannot change author of post");
            }

            if (existingPost.date != post.date)
            {
                throw new Exception("Cannot change date of post");
            }

            // Detach the existing post entity
            _context.Entry(existingPost).State = EntityState.Detached;

            // Attach the updated post entity
            _context.Entry(post).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUser(int id)
        {
            return _context.Users.FirstOrDefault(u => u.id == id);
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.username == username);
        }

        public void RemoveUser(int id)
        {
            var user = GetUser(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public List<Post> GetUserPosts(int userId)
        {
            return _context.Posts.Where(p => p.authorId == userId).ToList();
        }

        public void AddSession(Session session)
        {
            if (_context.Sessions.Any(s => s.userId == session.userId))
            {
                RemoveSession(session.userId);
            }
            _context.Sessions.Add(session);
            _context.SaveChanges();
        }

        public bool ValidToken(string token)
        {
            return _context.Sessions.Any(s => s.token == token);
        }

        public void RemoveSession(int userId)
        {
            var session = _context.Sessions.FirstOrDefault(s => s.userId == userId);
            if (session != null)
            {
                _context.Sessions.Remove(session);
                _context.SaveChanges();
                return;
            }
            throw new Exception("Session not found");
        }
    }
}
