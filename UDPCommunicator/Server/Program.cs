namespace UPDCommunicator.Server
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using UPDCommunicator.Common;

    public static class Program
    {
        private static UdpClient server = new UdpClient(new IPEndPoint(IPAddress.Any, 32123));

        private static void Main(string[] args)
        {
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    // Receive
                    var result = await server.ReceiveAsync();
                    ReceivedFrame received = new ReceivedFrame()
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
    }
}