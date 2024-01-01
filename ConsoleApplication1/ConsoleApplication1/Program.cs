using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace THEAR
{
    internal class Program
    {
        private DiscordSocketClient _client;
        public static void Main(string[] args)
        {
        }
        
        public async void MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.Log += Log;
            string token = Environment.GetEnvironmentVariable("API_TOKEN");
            
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            await Task.Delay(-1);
        }
        
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
        
        private async Task MessageUpdated(Cacheable<IMessage, ulong> before, SocketMessage after, ISocketMessageChannel channel)
        {
            // If the message was not in the cache, downloading it will result in getting a copy of `after`.
            var message = await before.GetOrDownloadAsync();
            Console.WriteLine($"{message} -> {after}");
        }
        
        private async Task MemberJoined(SocketUser user)
        {
            
        }
    }
}