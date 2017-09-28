using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfClient
{
    public struct Received
    {
        public IPEndPoint Sender;
        public string Message;
    }

    public partial class MainWindow : Window
    {
        private static Random rand = new Random();
        private readonly int port;
        private readonly string address = "127.0.0.1";
        private UdpClient client;

        public MainWindow()
        {
            InitializeComponent();
            port = rand.Next(32100, 32200);
            client = new UdpClient(new IPEndPoint(IPAddress.Parse(address), port));
            MyAddress.Text = String.Format("My address: {0}:{1}", address, port);

            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    try
                    {
                        var result = await client.ReceiveAsync();
                        Received received = new Received()
                        {
                            Message = Encoding.ASCII.GetString(result.Buffer, 0, result.Buffer.Length),
                            Sender = result.RemoteEndPoint
                        };

                        Logger.Instance.Info("Sender: " + received.Sender);
                        MessageWindow.Dispatcher.Invoke(() => MessageWindow.Text += received.Message + "\n");
                        Scroll.Dispatcher.Invoke(() => Scroll.ScrollToBottom());
                    }
                    catch (Exception e)
                    {
                        Logger.Instance.Error("Wrong response - " + e);
                    }
                }
            });
        }

        private void txtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= txtBox_GotFocus;
        }

        private void Send(object sender, RoutedEventArgs e)
        {
            try
            {
                var datagram = Encoding.ASCII.GetBytes(String.Format("{0}: {1}", UserNameBox.Text, MessageBox.Text));
                client.Send(datagram, datagram.Length, new IPEndPoint(IPAddress.Parse(Address.Text), Int32.Parse(Port.Text)));
                MessageWindow.Text += String.Format("{0}: {1}", UserNameBox.Text, MessageBox.Text) + "\n";
                Scroll.ScrollToBottom();
            }
            catch
            {
                MessageWindow.Text += "Wrong address!\n";
                Scroll.ScrollToBottom();
            }
        }
    }
}
