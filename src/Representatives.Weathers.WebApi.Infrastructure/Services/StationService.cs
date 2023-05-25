using Representative.Weathers.WebApi.Contracts;
using Representatives.Weathers.WebApi.Infrastructure.Caches;
using Representatives.Weathers.WebApi.Infrastructure.Extensions;

namespace Representatives.Weathers.WebApi.Infrastructure.Services
{
    public class StationService : IStationService
    {
        private readonly IStationCache _stationCache;

        public StationService(IStationCache stationCache)
        {
            _stationCache = stationCache;
        }

        public async Task<List<StationObservation>> GetObservations(string stationCode)
        {
            var currentDate = DateTime.UtcNow;
            List<StationObservation> observations = new List<StationObservation>();
            for (DateTime dateFrom = DateTime.UtcNow.AddDays(-7); dateFrom < currentDate; dateFrom = dateFrom.AddDays(1))
            {
                var mappedObservations = (await _stationCache.GetObservations(stationCode, dateFrom)).MapObservations();
                if (mappedObservations != null)
                {
                    observations.AddRange(mappedObservations);
                }
            }

            return observations;
        }

        public async Task<List<Station>> Get()
        {
            return (await _stationCache.Get()).Select(StationMapperExtension.Map)?.ToList();
        }
    }
}
