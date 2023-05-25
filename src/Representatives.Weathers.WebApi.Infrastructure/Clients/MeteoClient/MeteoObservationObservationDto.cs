using Representatives.Weathers.WebApi.Infrastructure.JsonConverters;
using System.Text.Json.Serialization;

namespace Representatives.Weathers.WebApi.Infrastructure.Clients.MeteoClient
{
    public class MeteoObservationObservationDto
    {
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime ObservationTimeUtc { get; set; }
        public double AirTemperature { get; set; }
    }
}
