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
        private readonly Service service;
        private readonly ILogger<TwocanController> _logger;

        public TwocanController(ILogger<TwocanController> logger)
        {
            _logger = logger;
            service = new Service(new MemoryRepository());
        }
        [HttpGet("posts", Name = "GetPosts")]
        public IEnumerable<Post> GetPosts()
        {
            return service.GetPosts();
        }

        [HttpPost("posts/add", Name = "AddPost")]
        public IActionResult AddPost([FromBody] Post post)
        {
            if (post == null)
            {
                return BadRequest("Post object cannot be deserialized");
            }
            service.AddPost(post);
            return Ok();
        }

        [HttpDelete("posts/delete/{postId}", Name = "DeletePost")]
        public IActionResult RemovePost(int postId)
        {
            try
            {
                service.RemovePost(postId);
            } catch
            {
                return NotFound("Post not found");
            }
            return Ok();
        }

        [HttpPut("posts/update", Name = "UpdatePost")]
        public IActionResult UpdatePost([FromBody] Post post)
        {
            try
            {
                service.UpdatePost(post);
            }
            catch
            {
                return NotFound("Post not found");
            }
            return Ok();
        }

    }
}
