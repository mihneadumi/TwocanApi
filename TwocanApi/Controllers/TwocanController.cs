using Microsoft.AspNetCore.Mvc;
using TwocanApi.Models;
using TwocanApi.Services;
using TwocanApi.Repositories;
using Microsoft.Extensions.Hosting;

namespace TwocanApi.Controllers
{
    [ApiController]
    [Route("twocan")]
    public class TwocanController : Controller
    {
        private readonly IService _service;
        private readonly ILogger<TwocanController> _logger;

        public TwocanController(ILogger<TwocanController> logger, IService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("postStream")]
        public async Task StreamEvents()
        {
            Response.Headers.Add("Content-Type", "text/event-stream");
            while (true)
            {
                _service.generatePosts();
                await Response.WriteAsync($"event: message\n");
                await Response.WriteAsync($"data: added new posts\n\n");
                await Response.Body.FlushAsync(); // clear response buffer
                await Task.Delay(10000); // simulate delay between events
            }
        }
        [HttpPut("setBotsNumber/{n}")]
        public IActionResult SetBotsNumber(int n)
        {
            if (n < 0)
            {
                return BadRequest("Number of bots cannot be negative");
            }

            _service.nrPostsToGenerate = n;
            return Ok("Number of bots set to " + n);
        }

        [HttpGet("posts", Name = "GetPosts")]
        public IEnumerable<Post> GetPosts()
        {
            return _service.GetPosts();
        }

        [HttpGet("posts/{postId}", Name = "GetPost")]
        public Post GetPost(int postId)
        {
            return _service.GetPost(postId);
        }

        [HttpPost("posts/add", Name = "AddPost")]
        public IActionResult AddPost([FromBody] Post post)
        {
            if (post == null)
            {
                return BadRequest("Post object cannot be deserialized");
            }
            _service.AddPost(post);
            return Ok("Post added");
        }

        [HttpDelete("posts/delete/{postId}", Name = "DeletePost")]
        public IActionResult RemovePost(int postId)
        {
            try
            {
                _service.RemovePost(postId);
            } catch
            {
                return NotFound("Post not found");
            }
            return Ok("Post removed");
        }

        [HttpPut("posts/update", Name = "UpdatePost")]
        public IActionResult UpdatePost([FromBody] Post post)
        {
            try
            {
                _service.UpdatePost(post);
            }
            catch
            {
                return NotFound("Post not found");
            }
            return Ok("Post updated");
        }

        [HttpGet("users", Name = "GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            return _service.GetUsers();
        }

        [HttpGet("users/{userId}", Name = "GetUser")]
        public User GetUser(int userId)
        {
            return _service.GetUser(userId);
        }

        [HttpPost("users/add", Name = "AddUser")]
        public IActionResult AddUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User object cannot be deserialized");
            }
            _service.AddUser(user);
            return Ok("User added");
        }

        [HttpDelete("users/delete/{userId}", Name = "DeleteUser")]
        public IActionResult RemoveUser(int userId)
        {
            try
            {
                _service.RemoveUser(userId);
            }
            catch
            {
                return NotFound("User not found");
            }
            return Ok("User removed");
        }

        [HttpPut("users/update", Name = "UpdateUser")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            try
            {
                _service.UpdateUser(user);
            }
            catch
            {
                return NotFound("User not found");
            }
            return Ok("User updated");
        }

        [HttpGet("users/{userId}/posts", Name = "GetUserPosts")]
        public IEnumerable<Post> GetUserPosts(int userId)
        {
            return _service.GetUserPosts(userId);
        }
    }
}
