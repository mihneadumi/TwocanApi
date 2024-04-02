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
            Assert.Equal(10, posts.Count);
        }

        [Fact]
        public void GetUsers_returns_all_users()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            var users = service.GetUsers();
            Assert.NotNull(users);
            Assert.Equal(4, users.Count);
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
            service.AddPost(post);
            Assert.NotNull(post);
            Assert.Equal(11, service.GetPosts().Count);
            Assert.Equal(10, post.id);
        }

        [Fact]
        public void RemovePost_removes_post()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            service.RemovePost(1);
            Assert.Equal(10, service.GetPosts().Count);
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
        public void UpdatePost_throws_exception_when_post_not_found()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            var post = new Post { id = 11, authorId = 1, title = "Test", content = "Test" };
            Assert.Throws<Exception>(() => service.UpdatePost(post));
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
    }
}