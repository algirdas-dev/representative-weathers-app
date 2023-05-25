using Representative.Weathers.WebApi.Contracts;

namespace Representatives.Weathers.WebApi.Infrastructure.Services
{
    public interface IStationService
    {
        Task<List<Station>> Get();
        Task<List<StationObservation>> GetObservations(string stationCode);
    }
}