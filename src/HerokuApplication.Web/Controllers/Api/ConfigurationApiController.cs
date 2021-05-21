using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerokuApplication.Web.Attributes;
using Microsoft.Extensions.Configuration;

namespace HerokuApplication.Web.Controllers.Api
{
    //[Route("api/configuration")]
    [SecretKeyAuth]
    [ApiController]
    public class ConfigurationApiController : ControllerBase
    {
        private readonly List<KeyValuePair<string, string>> _configList;

        public ConfigurationApiController(IConfiguration configuration)
        {
            _configList = configuration.AsEnumerable().ToList();
        }

        [HttpGet]
        [Route("/configuration")]
        public List<KeyValuePair<string, string>> GetAllConfigurations()
        {
            return _configList;
        }
    }
}
