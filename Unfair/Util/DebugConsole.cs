using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Unfair.Util
{
    public static class DebugConsole
    {
        private static bool _init;
        private static Socket _socket;

        private static void Prepare()
        {
#if DEBUG
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Connect(new IPEndPoint(IPAddress.Loopback, 17568));

            _init = true;
#endif
        }

        public static void Write(string text)
        {
#if DEBUG
            if (!_init)
            {
                Prepare();
            }

            _socket.Send(Encoding.ASCII.GetBytes(text + "\n"));
#endif
        }
    }
}