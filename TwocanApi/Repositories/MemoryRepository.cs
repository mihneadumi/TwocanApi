using System;
using TwocanApi.Models;

namespace TwocanApi.Repositories;
public class MemoryRepository: IRepository
{
	static List<Post> posts = [
            new Post {
                Id = 0,
                AuthorId = 0,
                Title = "My first post",
                Score = 0,
                Date = "2023-12-27",
                Content = "This is my first post on this platform",
            },

            new Post {
                Id = 1,
                AuthorId = 1,
                Title = "The second post ever",
                Score = 12,
                Date = "2024-02-14",
            },

            new Post {
                Id = 2,
                AuthorId = 2,
                Title = "Hey y'all",
                Score = 9,
                Date = "2024-02-14",
                Content = "I am really happy to see you guys here, honestly"
            },

            new Post {
                Id = 3,
                AuthorId = 3,
                Title = "Hear me out guys",
                Score = 10,
                Date = "2024-03-09",
                Content = "Every human being has something of value that they brought to the table, especially Hitler"
            },
            new Post {
                Id = 4,
                AuthorId = 0,
                Title = "This is a bot post",
                Score = 3,
                Date = "2024-03-09",
                Content = "Playwright is a decent testing framework because i cant make jest work how I want damn"
            },

            new Post {
                Id = 5,
                AuthorId = 0,
                Title = "I am looking for a job",
                Score = 11,
                Date = "2024-03-09",
                Content = "I can sing, dance, cook meth, code, cut hair, and do a lot of other things, Please hmu if you have a job for me"
            },

            new Post {
                Id = 6,
                AuthorId = 1,
                Title = "Kanye shut yo bitch ass up and drop Vultures 2 man fr",
                Score = 12,
                Date = "2024-03-10",
            },

            new Post {
                Id = 7,
                AuthorId = 0,
                Title = "I am looking for a job",
                Score = 19,
                Date = "2024-03-14",
                Content = "I can sing, dance, cook meth, code, cut hair, and do a lot of other things, Please hmu if you have a job for me"
            },

            new Post {
                Id = 8,
                AuthorId = 2,
                Title = "I made that b famooooous",
                Score = 10,
                Date = "2024-03-16",
            },

            new Post {
                Id = 9,
                AuthorId = 3,
                Title = "O noapte in Medellin",
                Score = 6,
                Date = "2024-03-16",
                Content = "Hai sa fugim o noapte in Medellin, sa ne bucuram putin, eu de tine tu de viiiiiin."
            }
        ];
	static List<User> users;
	public MemoryRepository()
	{
		// populateMockData();
    }
	private void populateMockData()
	{
        posts = [
            new Post {
                Id = 0,
                AuthorId = 0,
                Title = "My first post",
                Score = 0,
                Date = "2023-12-27",
                Content = "This is my first post on this platform",
            },

            new Post {
                Id = 1,
                AuthorId = 1,
                Title = "The second post ever",
                Score = 12,
                Date = "2024-02-14",
            },

            new Post {
                Id = 2,
                AuthorId = 2,
                Title = "Hey y'all",
                Score = 9,
                Date = "2024-02-14",
                Content = "I am really happy to see you guys here, honestly"
            },

            new Post {
                Id = 3,
                AuthorId = 3,
                Title = "Hear me out guys",
                Score = 10,
                Date = "2024-03-09",
                Content = "Every human being has something of value that they brought to the table, especially Hitler"
            },
            new Post {
                Id = 4,
                AuthorId = 0,
                Title = "This is a bot post",
                Score = 3,
                Date = "2024-03-09",
                Content = "Playwright is a decent testing framework because i cant make jest work how I want damn"
            },

            new Post {
                Id = 5,
                AuthorId = 0,
                Title = "I am looking for a job",
                Score = 11,
                Date = "2024-03-09",
                Content = "I can sing, dance, cook meth, code, cut hair, and do a lot of other things, Please hmu if you have a job for me"
            },

            new Post {
                Id = 6,
                AuthorId = 1,
                Title = "Kanye shut yo bitch ass up and drop Vultures 2 man fr",
                Score = 12,
                Date = "2024-03-10",
            },

            new Post {
                Id = 7,
                AuthorId = 0,
                Title = "I am looking for a job",
                Score = 19,
                Date = "2024-03-14",
                Content = "I can sing, dance, cook meth, code, cut hair, and do a lot of other things, Please hmu if you have a job for me"
            },

            new Post {
                Id = 8,
                AuthorId = 2,
                Title = "I made that b famooooous",
                Score = 10,
                Date = "2024-03-16",
            },

            new Post {
                Id = 9,
                AuthorId = 3,
                Title = "O noapte in Medellin",
                Score = 6,
                Date = "2024-03-16",
                Content = "Hai sa fugim o noapte in Medellin, sa ne bucuram putin, eu de tine tu de viiiiiin."
            }
        ];

        users = [
            new User {
                Id = 0,
                Username = "aliciaH",
                DisplayName = "Alicia H",
                Posts = 2,
                Followers = 0,
                Following = 0,
                Bio = "I am a developer"
            },
            new User {
                Id = 1,
                Username = "billyBal",
                DisplayName = "Billy Balosu",
                Posts = 1,
                Followers = 0,
                Following = 0,
                Bio = "I am definitely not a bot"
            },

            new User {
                Id = 2,
                Username = "SunshineLove123",
                DisplayName = "Samira",
                Posts = 1,
                Followers = 0,
                Following = 0,
                Bio = "It is always sunny in my world"
            },
            new User {
                Id = 3,
                Username = "ye",
                DisplayName = "Kanye East",
                Posts = 1,
                Followers = 0,
                Following = 0,
                Bio = "I am the Greatest artist of all T I M E"
            },
        ];
	}

    public List<Post> GetPosts() { return posts; }
    public List<User> GetUsers() {  return users; }

    public void AddPost(Post post) { posts.Add(post);}

    public Post GetPost(int id) { return posts.Find(p => p.Id == id); }

    public void RemovePost(int id)
    {
        var post = posts.Find(p => p.Id == id);
        posts.Remove(post);
    }

    public void UpdatePost(Post post)
    {
        Post dbPpost = posts.Find(p  => p.Id == post.Id);
        dbPpost.Content = post.Content;
    }

}
