using NLog;
using Prism.Logging;

namespace WpfApp.Infrastructure.Logging
{
    public class NLogger : ILoggerFacade
    {
        public Logger logger = LogManager.GetCurrentClassLogger();

        public void Log(string message, Category category, Priority priority)
        {
            switch (category)
            {
                case Category.Debug:
                    logger.Debug(message);
                    break;

                case Category.Exception:
                    logger.Error(message);
                    break;

                case Category.Info:
                    logger.Info(message);
                    break;

                case Category.Warn:
                    logger.Warn(message);
                    break;

                default:
                    logger.Info(message);
                    break;
            }
        }
    }
}