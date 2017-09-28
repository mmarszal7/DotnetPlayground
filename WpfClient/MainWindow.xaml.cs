using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Serialization;

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
        public UserData User { get; set; } = new UserData();
        private UdpClient client;

        public MainWindow()
        {
            InitializeComponent();
            GetUserData();
            client = new UdpClient(new IPEndPoint(IPAddress.Parse(User.Address), User.Port));
            txtMyAddress.Text = String.Format("My address: {0}:{1}", User.Address, User.Port);
            txtName.Text = User.Name;
            txtPort.Text = User.Port.ToString();
            txtAddress.Text = User.Address;

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

        private void txtGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= txtGotFocus;
        }

        private void Send(object sender, RoutedEventArgs e)
        {
            try
            {
                var datagram = Encoding.ASCII.GetBytes(String.Format("{0}: {1}", txtName.Text, txtMessage.Text));
                client.Send(datagram, datagram.Length, new IPEndPoint(IPAddress.Parse(txtAddress.Text), Int32.Parse(txtPort.Text)));
                MessageWindow.Text += String.Format("{0}: {1}", txtName.Text, txtMessage.Text) + "\n";
                Scroll.ScrollToBottom();
            }
            catch
            {
                MessageWindow.Text += "Wrong address!\n";
                Scroll.ScrollToBottom();
            }
        }

        private void GetUserData()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UserData));
                using (var reader = new StreamReader("user.xml"))
                {
                    User = (UserData)serializer.Deserialize(reader);
                }
            }
            catch(Exception e)
            {
                Logger.Instance.Error("XML deserialization error - " + e);
            }
        }
    }
}
