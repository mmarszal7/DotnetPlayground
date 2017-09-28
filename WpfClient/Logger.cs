namespace WpfClient
{
    public sealed class Logger
    {
        #region Private members

        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        #endregion

        #region Construction

        public static NLog.Logger Instance
        {
            get
            {
                return Logger.logger;
            }
        }

        #endregion
    }
}
