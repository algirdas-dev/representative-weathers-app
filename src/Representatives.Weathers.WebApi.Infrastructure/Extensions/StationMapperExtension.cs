using Representative.Weathers.WebApi.Contracts;
using Representatives.Weathers.WebApi.Infrastructure.Clients.MeteoClient;

namespace Representatives.Weathers.WebApi.Infrastructure.Extensions
{
    public static class StationMapperExtension
    {
        public static IEnumerable<StationObservation> MapObservations(this MeteoObservationDto source) 
        {
            if(source?.Observations == null)
            {
                return null;
            }

            List<StationObservation> station = source.Observations.Select(observation => new StationObservation
            {
                AirTemperature = observation.AirTemperature,
                ObservationTimeUtc = observation.ObservationTimeUtc
            }).ToList();

            return station;
        }

        public static Station Map(this MeteoStationDto source)
        {
            if (source == null)
            {
                return null;
            }

            return new Station
            {
                Code = source.Code,
                Name = source.Name
            };
        }
    }
}
