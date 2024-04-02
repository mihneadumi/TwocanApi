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
            if (post == null || post.Title == "")
            {
                return BadRequest();
            }
            service.AddPost(post);
            return Ok();
        }

    }
}
