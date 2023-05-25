using Microsoft.AspNetCore.Mvc;
using Representative.Weathers.WebApi.Contracts;
using Representatives.Weathers.WebApi.Infrastructure.Services;
using System.Net;

namespace Representative.Weathers.WebApi.Host.Controllers
{
    [ApiVersion("1")]
    public class StationsController : ApiControllerBase
    {
        private readonly IStationService _stationService;
        public StationsController(IStationService stationService)
        {
            _stationService = stationService;
        }

        /// <summary>
        /// Returns all stations
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<Station>), (int)HttpStatusCode.OK)]
        public async Task<List<Station>> Get()
        {
            return await _stationService.Get();
        }

        /// <summary>
        /// Returns last 7 days station observations of station by code
        /// </summary>
        [HttpGet("{code}/observations")]
        [ProducesResponseType(typeof(List<NotFound>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(List<StationObservation>), (int)HttpStatusCode.OK)]
        public async Task<List<StationObservation>> GetObservations(string code)
        {
            return await _stationService.GetObservations(code);
        }
    }
}