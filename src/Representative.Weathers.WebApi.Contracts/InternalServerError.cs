namespace Representative.Weathers.WebApi.Contracts
{
    public class InternalServerError : Error
    {
        /// <summary>
        /// Error code
        /// </summary>
        /// <example>InternalServerError</example>
        public string Code { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        /// <example>Internal Server Error</example>
        public string Message { get; set; }

    }
}
