using System;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tạo Server EndPoint, EndPoint này sẽ tham chiếu đến địa chỉ IP và Port của Server:
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 5000);
            // Tạo Server Socket, Socket này sẽ được kết nối với Server EndPoint:
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Liên kết và lắng nghe kết nối từ các máy khách
            serverSocket.Bind(serverEndPoint);
            serverSocket.Listen(10);
            while (true)
            {
                // Chấp nhận kết nối từ máy khách
                Socket clientSocket = serverSocket.Accept();

                // Lấy địa chỉ IP của máy khách
                IPAddress clientIP = ((IPEndPoint)clientSocket.RemoteEndPoint).Address;
                Console.WriteLine($"Client IP: {clientIP}");

                // Đóng kết nối
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
    }
}
