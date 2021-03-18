using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Lab;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            int port = 13000;


            try
            {
                TcpClient tcpClient = new TcpClient(ip, port);
                Console.WriteLine("Успех");
                NetworkStream stream = tcpClient.GetStream();
                Manager manager = new Manager(stream);

                string text = manager.GetMessage(stream);

                string command = Console.ReadLine();
                manager.SendMessage(stream, command);
                while (manager.GetMessage(stream) != "ok")
                {
                    Console.WriteLine("Сервер тебя не понял. Попробуй еще раз: ");
                    command = Console.ReadLine();
                    manager.SendMessage(stream, command);
                }

                Console.WriteLine("конектд)");

                while (true)
                {
                    text = manager.GetMessage();
                    Console.WriteLine("[Сервер] " + text);

                    Console.ReadLine();
                    manager.SendMessage("1");   // запрос на бросок

                    text = manager.GetMessage();
                    Console.WriteLine($"вам выпал {(text == "6" ? "леон" : text)}");

                    Thread.Sleep(100);

                    text = manager.GetMessage();
                    Console.WriteLine($"dungeon masterу выпал {(text == "6" ? "леон" : text)}");
                    Thread.Sleep(100);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("sgssgfdg");
            }

            Console.ReadLine();
        }
    }
}
