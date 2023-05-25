using Representative.Weathers.WebApi.Domain.Exceptions;
using System.Net.Http.Json;

namespace Representatives.Weathers.WebApi.Infrastructure.Clients.MeteoClient
{
    public class MeteoClient : IMeteoClient
    {
        private readonly HttpClient _httpClient;

        public MeteoClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MeteoObservationDto> GetObservations(string stationCode, DateTime date)
        {
            var response = await _httpClient.GetAsync($"/v1/stations/{stationCode}/observations/{date.ToString("yyyy-MM-dd")}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<MeteoObservationDto>();
                return content;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new NotFoundException();
            }

            throw new InternalServerErrorException();
        }

        public async Task<List<MeteoStationDto>> Get()
        {
            var response = await _httpClient.GetAsync($"/v1/stations");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<List<MeteoStationDto>>();
                return content;
            }

            throw new InternalServerErrorException();
        }
    }
}
