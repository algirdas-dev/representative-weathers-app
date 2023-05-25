using Representative.Weathers.WebApi.Contracts;

namespace Representative.Weathers.WebApi.Domain.Exceptions
{
    public class ExceptionBase<T> : Exception where T : Error, new()
    {
        public T Error { get; set; }

        public ExceptionBase(string code, string message) : base(message)
        {
            Error = new T()
            {
                Code = code,
                Message = message
            };
        }
    }
}
