using Representative.Weathers.WebApi.Contracts;

namespace Representative.Weathers.WebApi.Domain.Exceptions
{
    public class NotFoundException : ExceptionBase<NotFound>
    {
        public NotFoundException() : base("StationNotFound", "Station not found") 
        {

        }
    }
}
