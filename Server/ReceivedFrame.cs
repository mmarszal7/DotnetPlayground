namespace UPDCommunicator
{
    using System.Net;

    public struct ReceivedFrame
    {
        public IPEndPoint Sender { get; set; }
        public string Message { get; set; }
    }
}
