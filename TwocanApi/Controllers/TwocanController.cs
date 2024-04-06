using Microsoft.AspNetCore.Mvc;
using TwocanApi.Models;
using TwocanApi.Services;
using TwocanApi.Repositories;

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
                await Response.WriteAsync($"posts generated:\n\n");
                await Response.Body.FlushAsync(); // clear response buffer
                await Task.Delay(5000); // simulate delay between events
            }
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

    }
}
