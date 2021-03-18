using System;
using System.Net.Sockets;

namespace Lab
{
    public class Manager
    {
        private NetworkStream _stream;

        public Manager(NetworkStream stream) => _stream = stream;

        public string GetMessage()
        {
            byte[] buffer = new byte[256];
            return System.Text.Encoding.UTF8.GetString(buffer, 0, _stream.Read(buffer, 0, buffer.Length));
        }

        public string GetMessage(NetworkStream stream)
        {
            _stream = stream;
            return GetMessage();
        }

        public void SendMessage(string message)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(message);
            _stream.Write(buffer, 0, buffer.Length);
        }

        public void SendMessage(NetworkStream stream, string message)
        {
            _stream = stream;
            SendMessage(message);
        }

        public void Print(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
