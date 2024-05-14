using TwocanApi.Services;
using TwocanApi.Repositories;
using TwocanApi.Models;

namespace TwocanApiTests
{
    public class ServicesTest
    {
        [Fact]
        public void GetPosts_returns_all_posts()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            var posts = service.GetPosts();
            Assert.NotNull(posts);
        }

        [Fact]
        public void GetPost_returns_post_by_id()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            var post = service.GetPost(1);
            Assert.NotNull(post);
            Assert.Equal(1, post.id);
        }

        [Fact]
        public void AddPost_adds_post()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            var post = new Post { authorId = 1, title = "Test", content = "Test" };
            var initialCount = service.GetPosts().Count;
            service.AddPost(post);
            Assert.NotNull(post);
            Assert.Equal(initialCount+1, service.GetPosts().Count);
        }

        [Fact]
        public void RemovePost_removes_post()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            var initialCount = service.GetPosts().Count;
            service.RemovePost(1);
            Assert.Equal(initialCount-1, service.GetPosts().Count);
        }

        [Fact]
        public void UpdatePost_updates_post()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            var post = service.GetPost(2);
            post.title = "Updated";
            service.UpdatePost(post);
            Assert.Equal("Updated", service.GetPost(2).title);
        }

        [Fact]
        public void RemovePost_throws_exception_when_post_not_found()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            Assert.Throws<Exception>(() => service.RemovePost(11));
        }

        [Fact]
        public void GetPost_throws_exception_when_post_not_found()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            Assert.Throws<Exception>(() => service.GetPost(100));
        }

        [Fact]
        public void GetUsers_returns_all_users()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            var users = service.GetUsers();
            Assert.NotNull(users);
        }

        [Fact]
        public void GetUserPosts_returns_all_posts_by_user()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            var posts = service.GetUserPosts(1);
            Assert.NotNull(posts);
            for (int i = 0; i < posts.Count; i++)
            {
                Assert.Equal(1, posts[i].authorId);
            }
        }

        [Fact]
        public void GetUser_returns_user_by_id()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            var user = service.GetUser(1);
            Assert.NotNull(user);
            Assert.Equal(1, user.id);
        }

        [Fact]
        public void AddUser_adds_user()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            var user = new User {
                username = "Test",
                password = "Test",
                displayName = "Test",
                bio = "Test",
            };
            var initialCount = service.GetUsers().Count;
            service.AddUser(user);
            Assert.NotNull(user);
            Assert.Equal(initialCount+1, service.GetUsers().Count);
        }

        [Fact]
        public void RemoveUser_removes_user()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            var initialCount = service.GetUsers().Count;
            service.RemoveUser(1);
            Assert.Equal(initialCount-1, service.GetUsers().Count);
        }
    }
}