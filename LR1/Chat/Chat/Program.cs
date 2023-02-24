using Chat;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

IPAddress localAddress = IPAddress.Parse("127.0.0.1");
int count = 0;
List<Client>clients = new List<Client>();
if(JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(@"C:\\ITiROD\LR1\Chat\Chat\History.json")) != null)
{
    clients = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(@"C:\\ITiROD\LR1\Chat\Chat\History.json"));
}
Console.Write("Enter your name: ");
string? username = Console.ReadLine();
Client client = new Client(username);
if (clients.Count > 0)
{
    foreach (Client c in clients)
    {
        if (c.name == username)
        {
            client = c;
            count++;
            break;
        }
    }
}
if(count == 0)
{
    clients.Add(client);
}
Console.Write("enter port for recieve messages: ");
if (!int.TryParse(Console.ReadLine(), out var localPort)) return;
Console.Write("Enter port for send messsages: ");
if (!int.TryParse(Console.ReadLine(), out var remotePort)) return;
Console.WriteLine();
foreach(string hist in client.history)
{
    Console.WriteLine(hist);
}

Task.Run(ReceiveMessageAsync);
await SendMessageAsync();




async Task SendMessageAsync()
{
    using UdpClient sender = new UdpClient();
    while (true)
    {
        var message = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(message)) break;
        client.history.Add(message);
        message = $"{username}: {message}";
        for(int i = 0; i < clients.Count; i++)
        {
            if(clients[i].name != username)
            {
                clients.RemoveAt(i);
                i--;
            }
        }
        foreach (Client c in clients)
        {
            Console.WriteLine(c.name);
        }
        if (JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(@"C:\\ITiROD\LR1\Chat\Chat\History.json")) != null)
        {
            foreach (Client c in JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(@"C:\\ITiROD\LR1\Chat\Chat\History.json")))
            {
                if (c.name != username)
                {
                    clients.Add(c);
                }
            }
        }
        File.WriteAllText(@"C:\\ITiROD\LR1\Chat\Chat\History.json", string.Empty);
        File.WriteAllText(@"C:\\ITiROD\LR1\Chat\Chat\History.json", JsonConvert.SerializeObject(clients));
        byte[] data = Encoding.UTF8.GetBytes(message);
        await sender.SendAsync(data, new IPEndPoint(localAddress, remotePort));
    }
}
async Task ReceiveMessageAsync()
{
    using UdpClient receiver = new UdpClient(localPort);
    while (true)
    {
        var result = await receiver.ReceiveAsync();
        var message = Encoding.UTF8.GetString(result.Buffer);
        client.history.Add(message);
        for (int i = 0; i < clients.Count; i++)
        {
            if (clients[i].name != username)
            {
                clients.RemoveAt(i);
                i--;
            }
        }
        foreach (Client c in clients)
        {
            Console.WriteLine(c.name);
        }
        if (JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(@"C:\\ITiROD\LR1\Chat\Chat\History.json")) != null)
        {
            foreach (Client c in JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(@"C:\\ITiROD\LR1\Chat\Chat\History.json")))
            {
                if (c.name != username)
                {
                    clients.Add(c);
                }
            }
        }
        File.WriteAllText(@"C:\\ITiROD\LR1\Chat\Chat\History.json", string.Empty);
        File.WriteAllText(@"C:\\ITiROD\LR1\Chat\Chat\History.json", JsonConvert.SerializeObject(clients));
        Console.WriteLine(message);
    }
}