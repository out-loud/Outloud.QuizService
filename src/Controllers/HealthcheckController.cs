using Microsoft.AspNetCore.Mvc;

namespace Outloud.QuizService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthcheckController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}
