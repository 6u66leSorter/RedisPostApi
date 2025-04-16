using PostRedisApi.Services;
using RedisPostApi.Middlewares;
using RedisPostApi.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("redis:6379,abortConnect=false"));

builder.Services.AddScoped<IRedisPostService, RedisPostService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<HeadersMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
