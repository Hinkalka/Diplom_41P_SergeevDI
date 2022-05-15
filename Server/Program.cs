using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    class Program
    {
        static TcpListener listener = new TcpListener(IPAddress.Any, 5050);
        static List<ConnectedClient> clients = new List<ConnectedClient>();
        static void Main(string[] args)
        {
            listener.Start();
            while(true)
            {
                var client = listener.AcceptTcpClient();
                Task.Factory.StartNew(() =>
                {
                    var sr = new StreamReader(client.GetStream());
                    while(client.Connected)
                    {
                        var line = sr.ReadLine();
                        if(line.Contains("Login: ")&& !string.IsNullOrWhiteSpace(line.Replace("Login: ", "")))
                        {
                            var nick = line.Replace("Login: ", "");
                            if(clients.FirstOrDefault(s=> s.Name == nick) ==null)
                            {
                                clients.Add(new ConnectedClient(client, nick));
                                Console.WriteLine($"New connection: {nick}");
                                break;
                            }
                            else
                            {
                                var sw = new StreamWriter(client.GetStream());
                                sw.AutoFlush = true;

                                sw.WriteLine("Пользователь с таким ником уже есть в чате");
                                client.Client.Disconnect(false);
                            }
                        }
                    }

                    while (client.Connected)
                    {
                        try
                        {
                            sr = new StreamReader(client.GetStream());
                            var line = sr.ReadLine();
                            SendToAllClients(line);
                            Console.WriteLine(line);
                        }
                        catch { }
                    }
                });
            }
        }

        static async void SendToAllClients(string message)
        {
            await Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    try
                    {
                        if(clients[i].Client.Connected)
                        {
                            var sw = new StreamWriter(clients[i].Client.GetStream());
                            sw.AutoFlush = true;
                            sw.WriteLine(message);
                        }
                        else
                        {
                            clients.RemoveAt(i);
                        }
                    }
                    catch { }
                }
            });
        }
    }
}
