using System.Text;

namespace DOWNNOTIFIER.WebApp.Helpers
{
    public class ErrorLogger : IDisposable
    {
        private readonly string _applicationPath;

        private static StringBuilder _stringBuilder;
        public static StringBuilder stringBuilder
        {
            get
            {
                if (_stringBuilder == null)
                    _stringBuilder = new StringBuilder();
                return _stringBuilder;
            }
        }

        public ErrorLogger(string applicationPath)
        {
            _applicationPath = applicationPath;
        }

        public void WriteErrorLog(Exception ex)
        {
            var currentDate = DateTime.Now;

            var directoryName = currentDate.ToString("dd_MM_yyyy");
            var directoryPath = $"{_applicationPath}\\ErrorLogs\\{directoryName}";

            var fileName = currentDate.ToString("dd_MM_yyyy_HH_mm_ss");
            var filePath = $"{directoryPath}\\{fileName}.txt";

            var exceptionDate = currentDate.ToString("dd.MM.yyyy HH:mm:ss");
            var exceptionName = ex.GetType().Name;
            var exceptionMessage = ex.Message;
            var hasInnerException = ex.InnerException != null;
            var innerExceptionMessage = ex.InnerException != null
                ? ex.InnerException.Message
                : string.Empty;
            var stackTrace = ex.StackTrace;
            var source = ex.Source;

            stringBuilder.Append($"Exception Date: {exceptionDate}|");
            stringBuilder.Append($"Exception Name: {exceptionName}|");
            stringBuilder.Append($"Exception Message: {exceptionMessage}|");
            stringBuilder.Append($"Has InnerException: {hasInnerException.ToString()}|");
            stringBuilder.Append($"InnerException Message: {innerExceptionMessage}|");
            stringBuilder.Append($"StackTrace: {stackTrace}|");
            stringBuilder.Append($"Source: {source}");

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            if (!File.Exists(filePath))
                File.WriteAllText(filePath, stringBuilder.ToString(), Encoding.UTF8);

            stringBuilder.Clear();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
