using System;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs;

public class ChatHub : Hub
{
  private readonly ILogger<ChatHub> _logger;

  public ChatHub(ILogger<ChatHub> logger)
  {
    _logger = logger;
  }
  public async Task SendMessage(string user, string message)
  {
    await Clients.All.SendAsync("ReceiveMessage", user, message);
  }

  public Task ReceiveMessage(string user, string message)
  {
    _logger.LogInformation("Received message from {user}: {message}", user, message);

    return Task.CompletedTask;
  }
}
