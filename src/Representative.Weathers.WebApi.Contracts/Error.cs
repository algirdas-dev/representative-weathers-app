namespace Representative.Weathers.WebApi.Contracts
{
    public interface Error
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}