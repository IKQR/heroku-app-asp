using Microsoft.AspNetCore.Mvc;

namespace HerokuApplication.Web.Controllers.Api
{
    [ApiController]
    [Route("/")]
    public class DoNotSleepApiController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "OK";
        }
    }
}
