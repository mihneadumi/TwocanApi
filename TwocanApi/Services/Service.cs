using TwocanApi.Repositories;
using TwocanApi.Models;
namespace TwocanApi.Services;

public class Service
{
    IRepository repository;

    public Service(IRepository repository)
    {
        this.repository = repository;
    }

    public List<Post> GetPosts()
    {
        return repository.GetPosts();
    }

    public List<User> GetUsers()
    {
        return repository.GetUsers();
    }

    public Post GetPost(int id)
    {
        return repository.GetPost(id);
    }

    public void AddPost(Post post)
    {
        post.id = repository.GetPosts().Max(p => p.id) + 1;
        repository.AddPost(post);
    }

    public void RemovePost(int id)
    {
        repository.RemovePost(id);
    }

    public void UpdatePost(Post post)
    {
        repository.UpdatePost(post);
    }

}