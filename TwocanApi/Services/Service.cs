using TwocanApi.Repositories;
using TwocanApi.Models;
namespace TwocanApi.Services;

public class Service : IService
{
    IRepository repository;
    public int nrPostsToGenerate { get; set;} = 0;

    public Service(IRepository repository)
    {
        this.repository = repository;
        generatePosts(10);
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

    public void generatePosts(int n)
    {
        var maxUserId = repository.GetUsers().Max(u => u.id);
        for(int i = 0; i < n; i++)
        {
            Post post = new Post
            {
                authorId = Faker.RandomNumber.Next(0, maxUserId),
                title = Faker.Lorem.Sentence(),
                content = String.Join(" ", Faker.Lorem.Sentences(3)),
                score = Faker.RandomNumber.Next(0, 15),
        };
            AddPost(post);
        }   
    }

    public void generatePosts()
    {
        generatePosts(this.nrPostsToGenerate);
    }

    public User GetUser(int id)
    {
        return repository.GetUser(id);
    }

    public void AddUser(User user)
    {
        repository.AddUser(user);
    }

    public void RemoveUser(int id)
    {
        repository.RemoveUser(id);
    }

    public void UpdateUser(User user)
    {
        repository.UpdateUser(user);
    }

    public List<Post> GetUserPosts(int userId)
    {
        return repository.GetPosts().Where(p => p.authorId == userId).ToList();
    }
}