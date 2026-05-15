namespace Api.Errors
{
    public class AppException : Exception
    {
        public int StatusCode { get; }
        public string ErrorSource { get; }

        public AppException(
            string message,
            int statusCode,
            string errorSource
        ) : base(message)
        {
            StatusCode = statusCode;
            ErrorSource = errorSource;
        }
    }
}
