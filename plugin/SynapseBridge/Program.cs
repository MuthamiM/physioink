using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    private static ClientWebSocket _client = new ClientWebSocket();

    static async Task Main(string[] args)
    {
        Console.WriteLine("Synapse Bridge Starting...");
        try
        {
            await _client.ConnectAsync(new Uri("ws://127.0.0.1:8001/ws"), CancellationToken.None);
            Console.WriteLine("Connected to Brain!");

            // Start listening for messages from Python
            _ = ReceiveLoop();

            // Simulate sending events (Replace this with actual Logi SDK hooks)
            Console.WriteLine("Press 'D' to simulate Dial Turn, 'K' for Fixer, 'S' for Scribe, 'R' for Refactor.");
            while (true)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.D)
                {
                    await SendEvent("dial_turn", "15");
                }
                else if (key == ConsoleKey.K)
                {
                    await SendEvent("key_press", "fixER_agent");
                }
                else if (key == ConsoleKey.S)
                {
                    await SendEvent("key_press", "scribe_agent");
                }
                else if (key == ConsoleKey.R)
                {
                    await SendEvent("key_press", "refactor_agent");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static async Task SendEvent(string action, string value)
    {
        string json;
        if (action == "key_press")
        {
            json = $"{{\"action\": \"{action}\", \"key_id\": \"{value}\"}}";
        }
        else
        {
            json = $"{{\"action\": \"{action}\", \"value\": \"{value}\"}}";
        }
        var buffer = Encoding.UTF8.GetBytes(json);
        await _client.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        Console.WriteLine($"Sent: {json}");
    }

    static async Task ReceiveLoop()
    {
        var buffer = new byte[1024];
        while (_client.State == WebSocketState.Open)
        {
            var result = await _client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
            Console.WriteLine($"Received from Brain: {message}");
        }
    }
}
