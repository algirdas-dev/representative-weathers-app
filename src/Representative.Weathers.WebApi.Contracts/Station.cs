namespace Representative.Weathers.WebApi.Contracts
{
    public class Station
    {
        /// <summary>
        /// Station code
        /// </summary>
        /// <example>vilniaus-ams</example>
        public string Code { get; set; }

        /// <summary>
        /// Station name
        /// </summary>
        /// <example>vilniaus meteorologinė stotis</example>
        public string Name { get; set; }
    }
}
