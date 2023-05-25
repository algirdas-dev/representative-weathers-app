using Representative.Weathers.WebApi.Contracts;

namespace Representative.Weathers.WebApi.Domain.Exceptions
{
    public class InternalServerErrorException : ExceptionBase<InternalServerError>
    {
        public InternalServerErrorException() : base("InternalServerError", "Internal Server Error")
        {
            
        }
    }
}
