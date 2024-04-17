using System;
using System.Collections.Generic;
using System.Linq;
using TwocanApi.Models;

namespace TwocanApi.Repositories
{
    public class SqlRepository : IRepository
    {
        private readonly YourDbContext _context;

        public SqlRepository(YourDbContext context)
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
            return _context.Posts.FirstOrDefault(p => p.Id == id) ?? throw new Exception("Post not found");
        }

        public void RemovePost(int id)
        {
            var post = _context.Posts.Find(id);
            if (post == null)
                throw new Exception("Post not found");

            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUser(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id) ?? throw new Exception("User not found");
        }

        public void RemoveUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                throw new Exception("User not found");

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
