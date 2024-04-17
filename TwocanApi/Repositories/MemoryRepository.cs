using System;
using TwocanApi.Models;

namespace TwocanApi.Repositories;
public class MemoryRepository: IRepository
{
    static List<Post> posts = [];
	static List<User> users = [];
    public MemoryRepository(){
        #region mockUsers
        var user1 = new User
        {
            id = 0,
            username = "aliciaH",
            displayName = "Alicia H",
            posts = [],
            followers = 0,
            following = 0,
            bio = "I am a developer"
        };
        var user2 = new User
        {
            id = 1,
            username = "billyBal",
            displayName = "Billy Balosu",
            posts = [],
            followers = 0,
            following = 0,
            bio = "I am definitely not a bot"
        };
        var user3 = new User
        {
            id = 2,
            username = "SunshineLove123",
            displayName = "Samira",
            posts = [],
            followers = 0,
            following = 0,
            bio = "It is always sunny in my world"
        };
        var user4 = new User
        {
            id = 3,
            username = "ye",
            displayName = "Kanye East",
            posts = [posts[3], posts[9]],
            followers = 0,
            following = 0,
            bio = "I am the Greatest artist of all T I M E"
        };
        #endregion
        AddUser(user1);
        AddUser(user2);
        AddUser(user3);
        AddUser(user4);
        #region mockPosts
        var post0 = new Post
        {
            id = 0,
            authorId = 0,
            title = "My first post",
            score = 0,
            date = "2023-12-27",
            content = "This is my first post on this platform",
        };

        var post1 = new Post
        {
            id = 1,
            authorId = 1,
            title = "The second post ever",
            score = 12,
            date = "2024-02-14",
        };

        var post2 = new Post
        {
            id = 2,
            authorId = 2,
            title = "Hey y'all",
            score = 9,
            date = "2024-02-14",
        };

        var post3 = new Post
        {
            id = 3,
            authorId = 3,
            title = "Hear me out guys",
            score = 10,
            date = "2024-03-09",
            content = "Every human being has something of value that they brought to the table, especially Hitler"
        };

        var post4 = new Post
        {
            id = 4,
            authorId = 0,
            title = "This is a bot post",
            score = 3,
            date = "2024-03-09",
            content = "Playwright is a decent testing framework because i cant make jest work how I want damn"
        };

        var post5 = new Post
        {
            id = 5,
            authorId = 0,
            title = "I am looking for a job",
            score = 11,
            date = "2024-03-09",
            content = "I can sing, dance, cook meth, code, cut hair, and do a lot of other things, Please hmu if you have a job for me"
        };

        var post6 = new Post
        {
            id = 6,
            authorId = 1,
            title = "Kanye shut yo bitch ass up and drop Vultures 2 man fr",
            score = 12,
            date = "2024-03-10",
        };

        var post7 = new Post
        {
            id = 7,
            authorId = 0,
            title = "I am looking for a job",
            score = 19,
            date = "2024-03-14",
            content = "I can sing, dance, cook meth, code, cut hair, and do a lot of other things, Please hmu if you have a job for me"
        };

        var post8 = new Post
        {
            id = 8,
            authorId = 2,
            title = "I made that b famooooous",
            score = 10,
            date = "2024-03-16",
        };

        var post9 = new Post
        {
            id = 9,
            authorId = 3,
            title = "O noapte",
            score = 6,
            date = "2024-03-16",
            content = "TEEEEEEEEEEEEEEEEE EEEEEEEEEEEE EEEEEEEEE EEEEEEEEEEEE EEEEEEEEEEE EEEEEEEEEE EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEXT."
        };
        #endregion
        AddPost(post0);
        AddPost(post1);
        AddPost(post2);
        AddPost(post3);
        AddPost(post4);
        AddPost(post5);
        AddPost(post6);
        AddPost(post7);
        AddPost(post8);
        AddPost(post9);
    }

    public List<Post> GetPosts() { return posts; }
    public List<User> GetUsers() {  return users; }

    public void AddPost(Post post)
    {
        post.id = posts.Count > 0 ? posts.Max(p => p.id) + 1 : 0;
        var author = users.Find(u => u.id == post.authorId);
        if (author == null)
        {
            throw new Exception("Author not found");
        }
        author.posts.Add(post);
        post.author = author;
        posts.Add(post);
    }

    public Post GetPost(int id) { return posts.Find(p => p.id == id)?? throw new Exception("Post not found"); }

    public void RemovePost(int id)
    {
        var post = posts.Find(p => p.id == id);
        if (post == null) throw new Exception("Post not found");
        var author = users.Find(u => u.id == post.authorId);
        if (author == null) throw new Exception("Author not found");
        author.posts.Remove(post);
        posts.Remove(post);
    }

    public void UpdatePost(Post post)
    {
        Post dbPpost = posts.Find(p  => p.id == post.id);
        if (dbPpost == null) throw new Exception("Post not found");
        dbPpost.title = post.title;
        dbPpost.content = post.content;
    }

    public void AddUser(User user)
    {
        user.id = users.Max(u => u.id) + 1;
        users.Add(user);
    }

    public User GetUser(int id) { return users.Find(u => u.id == id)?? throw new Exception("User not found"); }

    public void RemoveUser(int id)
    {
        var user = users.Find(u => u.id == id);
        if (user == null) throw new Exception("User not found");
        users.Remove(user);
    }

    public void UpdateUser(User user)
    {
        User dbUser = users.Find(u => u.id == user.id);
        if (dbUser == null) throw new Exception("User not found");
        dbUser.displayName = user.displayName;
        dbUser.bio = user.bio;
    }


}
