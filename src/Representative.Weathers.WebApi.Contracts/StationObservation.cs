namespace Representative.Weathers.WebApi.Contracts
{
    public class StationObservation
    {
        /// <summary>
        /// Observation time utc
        /// </summary>
        /// <example>2023-05-17T00:00:00</example>
        public DateTime? ObservationTimeUtc { get; set; }

        /// <summary>
        /// Observation Air temperature
        /// </summary>
        /// <example>11.6</example>
        public double AirTemperature { get; set; }
    }
}
