using RedisPostApi.Models;
using StackExchange.Redis;

namespace RedisPostApi.Services
{
    public interface IRedisPostService
    {
        Task<Post?> GetPostAsync(string id);
        Task CreatePostAsync(Post post);
        Task<bool> UpdatePostAsync(string id, Post updated);
        Task<bool> DeletePostAsync(string id);
    }
}
