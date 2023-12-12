using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UnfairDebug
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Loopback, 17568));
            socket.Listen(4); // ?
            Console.WriteLine("[UnfairDebug] Listening on port 17568");
            
            reconnect:
            var client = socket.Accept();
            try
            {
                while (client.Connected)
                {
                    var buffer = new byte[ushort.MaxValue];
                    var bytesReceived = client.Receive(buffer);
                    
                    var data = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
                    if (bytesReceived == 0) // Client disconnected
                    {
                        Console.WriteLine("[UnfairDebug] Client disconnected");
                        client.Close();
                        goto reconnect;
                    }
                    Console.WriteLine(data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                goto reconnect;
            }
        }
    }
}