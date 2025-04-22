using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    [Route("veryhiddenapikey")]
    public class KeyController : Controller
    {
        private readonly IConfiguration _configuration;
        public KeyController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult GetSecretValue()
        {
            var apiKey = _configuration["apikey-secretkey"];

            ViewBag.ApiKey = apiKey;

            return Content(apiKey, "text/html");
        }
    }
}
