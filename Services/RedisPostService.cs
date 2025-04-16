using RedisPostApi.Models;
using RedisPostApi.Services;
using StackExchange.Redis;
using System.Text.Json;

namespace PostRedisApi.Services;

public class RedisPostService : IRedisPostService
{
    private readonly IDatabase _db;

    public RedisPostService(IConnectionMultiplexer redis)
    {
        _db = redis.GetDatabase();
    }

    private string GetKey(string id) => $"post:{id}";

    public async Task<Post?> GetPostAsync(string id)
    {
        var value = await _db.StringGetAsync(GetKey(id));
        return value.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Post>(value);
    }

    public async Task CreatePostAsync(Post post)
    {
        var json = JsonSerializer.Serialize(post);
        await _db.StringSetAsync(GetKey(post.Id), json);
    }

    public async Task<bool> UpdatePostAsync(string id, Post updated)
    {
        if (!await _db.KeyExistsAsync(GetKey(id))) return false;
        updated.Id = id;
        return await _db.StringSetAsync(GetKey(id), JsonSerializer.Serialize(updated));
    }

    public async Task<bool> DeletePostAsync(string id)
    {
        return await _db.KeyDeleteAsync(GetKey(id));
    }
}
