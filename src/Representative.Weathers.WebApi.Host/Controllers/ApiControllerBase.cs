using Microsoft.AspNetCore.Mvc;

namespace Representative.Weathers.WebApi.Host.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
    }
}
