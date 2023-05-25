namespace Representative.Weathers.WebApi.Contracts
{
    public class NotFound : Error
    {
        /// <summary>
        /// Error code
        /// </summary>
        /// <example>NotFound</example>
        public string Code { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        /// <example>Not Found</example>
        public string Message { get; set; }
    }
}
