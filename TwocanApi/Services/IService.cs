using Microsoft.AspNetCore.Mvc;
using TwocanApi.Models;
namespace TwocanApi.Services;
public interface IService
{
    public static int nrPostsToGenerate { get; set; }

    public void UpdateNrOfPosts(int n);
    public List<Post> GetPosts();
    public List<User> GetUsers();
    public void AddPost(Post post);
    public void AddUser(User user);
    public Post GetPost(int id);
    public User GetUser(int id);
    public User GetUserByUsername(string username);
    public List<Post> GetUserPosts(int userId);
    public void RemovePost(int id);
    public void RemoveUser(int id);
    public void UpdatePost(Post post);
    public void UpdateUser(User user);
    public void generatePosts(int n);
    public void generatePosts();

    public string GenerateToken(string username);
    public bool ValidateToken(string token);
    public void RemoveSession(string token);

}