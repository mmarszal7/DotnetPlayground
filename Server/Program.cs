using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UDP.Logger;

namespace Server
{
    public struct Received
    {
        public IPEndPoint Sender;
        public string Message;

    }

    /// <summary>
    /// Its basic setup for building UDP client/server, not actually "Server" class
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var server = new UdpClient(new IPEndPoint(IPAddress.Any, 32123));

            //start listening for messages and copy the messages back to the client
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    // Receive
                    var result = await server.ReceiveAsync();
                    Received received = new Received()
                    {
                        Message = Encoding.ASCII.GetString(result.Buffer, 0, result.Buffer.Length),
                        Sender = result.RemoteEndPoint
                    };
                    Logger.Instance.Info("Sender: " + received.Sender);

                    // Send
                    var datagram = Encoding.ASCII.GetBytes(received.Message);
                    server.Send(datagram, datagram.Length, received.Sender);
                }
            });

            Console.ReadLine();
        }
        public static long IPToInt(string addr) => (uint)IPAddress.NetworkToHostOrder((int)IPAddress.Parse(addr).Address);
        public static string IPToStr(long address) => IPAddress.Parse(address.ToString()).ToString();
    }

}




