using Microsoft.AspNetCore.Mvc;
using PostRedisApi.Services;
using RedisPostApi.Models;
using RedisPostApi.Services;

namespace PostRedisApi.Controllers;

[ApiController]
[Route("posts")]
public class PostController : ControllerBase
{
    private readonly IRedisPostService _service;

    public PostController(IRedisPostService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost(Post post)
    {
        await _service.CreatePostAsync(post);
        return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPost(string id)
    {
        var post = await _service.GetPostAsync(id);
        return post is null ? NotFound() : Ok(post);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost(string id, Post post)
    {
        var updated = await _service.UpdatePostAsync(id, post);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(string id)
    {
        var deleted = await _service.DeletePostAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
