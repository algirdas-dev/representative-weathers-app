using Microsoft.Extensions.Caching.Memory;
using Representatives.Weathers.WebApi.Infrastructure.Clients.MeteoClient;
using Representatives.Weathers.WebApi.Infrastructure.Constants;
using Representatives.Weathers.WebApi.Infrastructure.Settings;

namespace Representatives.Weathers.WebApi.Infrastructure.Caches
{
    public class StationCache : IStationCache
    {
        private readonly IMeteoClient _meteoClient;
        private readonly IMemoryCache _memoryCache;
        private readonly CacheSetting _cacheSetting;

        public StationCache(IMeteoClient meteoClient, IMemoryCache memoryCache, CacheSetting cacheSetting)
        {
            _meteoClient = meteoClient;
            _memoryCache = memoryCache;
            _cacheSetting = cacheSetting;
        }

        public async Task<MeteoObservationDto> GetObservations(string stationCode, DateTime date)
        {
            if (!_memoryCache.TryGetValue(CacheConst.Observations(stationCode, date), out MeteoObservationDto meteoObservation))
            {
                meteoObservation = await _meteoClient.GetObservations(stationCode, date);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(_cacheSetting.ObservationsInDays * 24 * 60 * 60));

                _memoryCache.Set(CacheConst.Observations(stationCode, date), meteoObservation, cacheEntryOptions);
            }

            return meteoObservation;
        }

        public async Task<List<MeteoStationDto>> Get()
        {
            if (!_memoryCache.TryGetValue(CacheConst.Stations, out List<MeteoStationDto> meteoStations))
            {
                meteoStations = await _meteoClient.Get();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(_cacheSetting.StationsInDays * 24 * 60 * 60));

                _memoryCache.Set(CacheConst.Stations, meteoStations, cacheEntryOptions);
            }

            return meteoStations;
        }
    }
}
