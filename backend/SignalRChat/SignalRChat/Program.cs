using SignalRChat.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(
    builder =>
    {
      builder.WithOrigins("http://localhost:3000", "http://localhost:3001")
      .AllowAnyHeader()
      .WithMethods("GET", "POST")
      .AllowCredentials();
    }
  );
});

var app = builder.Build();

app.UseCors();

app.MapGet("/", () => "Hello World!");

app.MapHub<ChatHub>("/chatHub");

app.Run();
