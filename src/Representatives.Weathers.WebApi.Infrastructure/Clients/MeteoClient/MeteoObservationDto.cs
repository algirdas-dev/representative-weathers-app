namespace Representatives.Weathers.WebApi.Infrastructure.Clients.MeteoClient
{
    public class MeteoObservationDto
    {
        public MeteoObservationStationDto Station { get; set; }
        public List<MeteoObservationObservationDto> Observations { get; set; }
    }
}
