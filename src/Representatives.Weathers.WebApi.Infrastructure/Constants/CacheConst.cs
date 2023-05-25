using Representatives.Weathers.WebApi.Infrastructure.Clients.MeteoClient;

namespace Representatives.Weathers.WebApi.Infrastructure.Constants
{
    public class CacheConst
    {
        public static string Observations(string stationCode, DateTime date)
        {
            return $"Observations_{stationCode}_Date_{date.ToString("yyyyMMdd")}";
        }

        public static string Stations = "Stations";
    }
}
