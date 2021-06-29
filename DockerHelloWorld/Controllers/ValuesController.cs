using System;
using Microsoft.AspNetCore.Mvc;

namespace DockerHelloWorld.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "Hello World!";
        }
    }
}
