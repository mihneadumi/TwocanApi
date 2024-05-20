
using Microsoft.Extensions.Hosting;
using TwocanApi.Models;

namespace TwocanApi.Repositories;

public interface IRepository
{
    public List<Post> GetPosts();
    public List<User> GetUsers();
    public void AddPost(Post post);
    public Post GetPost(int id);
    public void RemovePost(int id);
    public void UpdatePost(Post post);

    public void AddUser(User user);
    public User GetUser(int id);
    public User GetUserByUsername(string username);
    public void RemoveUser(int id);
    public void UpdateUser(User user);
    public List<Post> GetUserPosts(int userId);
    public bool ValidToken(string token);
    public void RemoveSession(string token);
    public void AddSession(Session session);
}