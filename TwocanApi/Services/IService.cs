using TwocanApi.Models;
namespace TwocanApi.Services;
public interface IService
{
    public int nrPostsToGenerate { get; set; }

    public List<Post> GetPosts();
    public List<User> GetUsers();
    public void AddPost(Post post);
    public Post GetPost(int id);
    public void RemovePost(int id);
    public void UpdatePost(Post post);

    public void generatePosts(int n);

    public void generatePosts();
}