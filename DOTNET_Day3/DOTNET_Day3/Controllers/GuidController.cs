using DOTNET_Day3.DOTNET_Day3;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_Day3.Controllers
{
    [ApiController]
    [Route("guid")]
    public class GuidController : ControllerBase
    {
        private readonly IGetGuidSingleton _singletonGuid;
        private readonly IGetGuidScoped _scopedGuid;
        private readonly IGetGuidTransient _transientGuid;
        public GuidController(IGetGuidSingleton singletonGuid,IGetGuidScoped scopedGuid,IGetGuidTransient transientGuid)
        {
            _singletonGuid = singletonGuid;
            _scopedGuid = scopedGuid;
            _transientGuid = transientGuid;
        }

        [HttpGet]
        public IActionResult GetGuids()
        {
            Console.WriteLine(_singletonGuid.GetGuid());
            Console.WriteLine(_scopedGuid.GetGuid());
            Console.WriteLine(_transientGuid.GetGuid());
            return Ok();
        }
    }
}
