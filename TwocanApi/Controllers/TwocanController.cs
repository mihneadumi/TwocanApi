﻿using Microsoft.AspNetCore.Mvc;
using TwocanApi.Models;
using TwocanApi.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

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

            _service.UpdateNrOfPosts(n);
            return Ok("Number of bots set to " + n);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("User object cannot be deserialized");
            }
            try
            {
                var user = _service.GetUserByUsername(userDTO.username);
                if (user == null)
                {
                    return NotFound("User not found");
                }
                if (user.password != userDTO.password)
                {
                    return Unauthorized("Incorrect password");
                }

                Session session = _service.GenerateSession(userDTO.username);
                return Ok(new { session });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("logout")]
        public IActionResult Logout([FromBody] int userId)
        {
            if (userId == null)
            {
                return BadRequest("Session object cannot be deserialized");
            }
            try
            {
                _service.RemoveSession(userId);
                return Ok("Session removed");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegistrationDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                {
                    return BadRequest("User object cannot be deserialized");
                }
                var user = new User
                {
                    username = userDTO.username,
                    password = userDTO.password,
                    displayName = userDTO.displayName,
                    bio = userDTO.bio,
                };
                _service.AddUser(user);
                return Ok("User added");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
        public IActionResult AddPost([FromBody] PostDTO postDTO)
        {
            if (postDTO == null)
            {
                return BadRequest("Post object cannot be deserialized");
            }
            var post = new Post
            {
                authorId = postDTO.authorId,
                title = postDTO.title,
                content = postDTO.content,
                author = _service.GetUser(postDTO.authorId),
            };
            _service.AddPost(post);
            return Ok("Post added");
        }

        [HttpDelete("posts/delete/{postId}", Name = "DeletePost")]
        public IActionResult RemovePost(int postId)
        {
            try
            {
                _service.RemovePost(postId);
            }
            catch
            {
                return NotFound("Post not found");
            }
            return Ok("Post removed");
        }

        [HttpPut("posts/update", Name = "UpdatePost")]
        public IActionResult UpdatePost([FromBody] PostDTO postDTO)
        {
            try
            {
                var oldPost = _service.GetPost(postDTO.id ?? 0);
                var post = new Post
                {
                    id = postDTO.id ?? 0,
                    title = postDTO.title,
                    content = postDTO.content,
                    authorId = oldPost.authorId,
                    date = oldPost.date,
                    author = _service.GetUser(oldPost.authorId),
                    score = oldPost.score,
                };
                _service.UpdatePost(post);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
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
