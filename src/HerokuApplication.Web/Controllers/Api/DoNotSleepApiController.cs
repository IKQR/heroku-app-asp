using HerokuApplication.Web.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HerokuApplication.Web.Controllers.Api
{
    [SecretKeyAuth]
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
