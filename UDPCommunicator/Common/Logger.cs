namespace UPDCommunicator.Common
{
    public static class Logger
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static NLog.Logger Instance
        {
            get
            {
                return Logger.logger;
            }
        }
    }
}
