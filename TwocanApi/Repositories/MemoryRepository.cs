using System;
using TwocanApi.Models;

namespace TwocanApi.Repositories;
public class MemoryRepository: IRepository
{
    #region mockData
    static List<Post> posts = [
        new Post {
            id = 0,
            authorId = 0,
            title = "My first post",
            score = 0,
            date = "2023-12-27",
            content = "This is my first post on this platform",
        },

        new Post {
            id = 1,
            authorId = 1,
            title = "The second post ever",
            score = 12,
            date = "2024-02-14",
        },

        new Post {
            id = 2,
            authorId = 2,
            title = "Hey y'all",
            score = 9,
            date = "2024-02-14",
        },

        new Post {
            id = 3,
            authorId = 3,
            title = "Hear me out guys",
            score = 10,
            date = "2024-03-09",
            content = "Every human being has something of value that they brought to the table, especially Hitler"
        },
        new Post {
            id = 4,
            authorId = 0,
            title = "This is a bot post",
            score = 3,
            date = "2024-03-09",
            content = "Playwright is a decent testing framework because i cant make jest work how I want damn"
        },

        new Post {
            id = 5,
            authorId = 0,
            title = "I am looking for a job",
            score = 11,
            date = "2024-03-09",
            content = "I can sing, dance, cook meth, code, cut hair, and do a lot of other things, Please hmu if you have a job for me"
        },

        new Post {
            id = 6,
            authorId = 1,
            title = "Kanye shut yo bitch ass up and drop Vultures 2 man fr",
            score = 12,
            date = "2024-03-10",
        },

        new Post {
            id = 7,
            authorId = 0,
            title = "I am looking for a job",
            score = 19,
            date = "2024-03-14",
            content = "I can sing, dance, cook meth, code, cut hair, and do a lot of other things, Please hmu if you have a job for me"
        },

        new Post {
            id = 8,
            authorId = 2,
            title = "I made that b famooooous",
            score = 10,
            date = "2024-03-16",
        },

        new Post {
            id = 9,
            authorId = 3,
            title = "O noapte",
            score = 6,
            date = "2024-03-16",
            content = "TEEEEEEEEEEEEEEEEE EEEEEEEEEEEE EEEEEEEEE EEEEEEEEEEEE EEEEEEEEEEE EEEEEEEEEE EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEXT."
        }
    ];
	static List<User> users = [
        new User {
            id = 0,
            username = "aliciaH",
            displayName = "Alicia H",
            posts = 2,
            followers = 0,
            following = 0,
            bio = "I am a developer"
        },
        new User {
            id = 1,
            username = "billyBal",
            displayName = "Billy Balosu",
            posts = 1,
            followers = 0,
            following = 0,
            bio = "I am definitely not a bot"
        },

        new User {
            id = 2,
            username = "SunshineLove123",
            displayName = "Samira",
            posts = 1,
            followers = 0,
            following = 0,
            bio = "It is always sunny in my world"
        },
        new User {
            id = 3,
            username = "ye",
            displayName = "Kanye East",
            posts = 1,
            followers = 0,
            following = 0,
            bio = "I am the Greatest artist of all T I M E"
        },
    ];
    #endregion
    public MemoryRepository(){}

    public List<Post> GetPosts() { return posts; }
    public List<User> GetUsers() {  return users; }

    public void AddPost(Post post) { posts.Add(post);}

    public Post GetPost(int id) { return posts.Find(p => p.id == id)?? throw new Exception("Post not found"); }

    public void RemovePost(int id)
    {
        var post = posts.Find(p => p.id == id);
        if (post == null) throw new Exception("Post not found");
        posts.Remove(post);
    }

    public void UpdatePost(Post post)
    {
        Post dbPpost = posts.Find(p  => p.id == post.id);
        if (dbPpost == null) throw new Exception("Post not found");
        dbPpost.title = post.title;
        dbPpost.content = post.content;
    }

}
