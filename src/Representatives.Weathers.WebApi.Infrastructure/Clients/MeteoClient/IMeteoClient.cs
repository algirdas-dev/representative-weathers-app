namespace Representatives.Weathers.WebApi.Infrastructure.Clients.MeteoClient
{
    public interface IMeteoClient
    {
        Task<List<MeteoStationDto>> Get();
        Task<MeteoObservationDto> GetObservations(string stationCode, DateTime date);
    }
}