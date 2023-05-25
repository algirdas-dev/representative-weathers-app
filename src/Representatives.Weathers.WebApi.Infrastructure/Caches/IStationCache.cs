using Representatives.Weathers.WebApi.Infrastructure.Clients.MeteoClient;

namespace Representatives.Weathers.WebApi.Infrastructure.Caches
{
    public interface IStationCache
    {
        Task<List<MeteoStationDto>> Get();
        Task<MeteoObservationDto> GetObservations(string stationCode, DateTime date);
    }
}