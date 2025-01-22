using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        // GET : api/people
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("bravo");
        }

        // GET : api/people/method
        [HttpGet("method")]
        public IActionResult MyMethod()
        {
            return Ok("my method");
        }

        // GET : api/people/route/{myparam}
        [HttpGet("route/{myparam}")]
        public IActionResult MethodWithRouteParam([FromRoute] string myparam)
        {
            return Ok($"mon param de route: {myparam}");
        }

        // GET : api/people/add/{operandOne}/{operandTwo}
        [HttpGet("add/{operandOne}/{operandTwo}")]
        public IActionResult MethodWithRouteParamAdd(
            [FromRoute] int operandOne, [FromRoute] int operandTwo)
        {
            return Ok($"le resultat du calcul {operandOne} + {operandTwo} est {operandOne + operandTwo}");
        }

        // POST : api/people
        [HttpPost]
        public IActionResult AddInformation()
        {
            return Ok("info added");
        }
    }
}
