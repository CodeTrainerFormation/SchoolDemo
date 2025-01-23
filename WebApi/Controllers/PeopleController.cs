using Dal;
using DomainModel;
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
        [HttpGet("route/{myParam}")]
        public IActionResult MethodWithRouteParam([FromRoute] string myParam)
        {
            return Ok($"mon param de route: {myParam}");
        }

        // GET : api/people/add/{operandOne}/{operandTwo}
        [HttpGet("add/{operandOne}/{operandTwo}")]
        public IActionResult MethodWithRouteParamAdd(
            [FromRoute] int operandOne, [FromRoute] int operandTwo)
        {
            return Ok($"le resultat du calcul {operandOne} + {operandTwo} est {operandOne + operandTwo}");
        }

        // GET : api/people/query?myParam=hello
        [HttpGet("query")]
        public IActionResult Query([FromQuery] string myParam)
        {
            return Ok($"mon param de querystring: {myParam}");
        }

        // GET : api/people/body + body
        [HttpGet("body")]
        public IActionResult Body([FromBody] string message)
        {
            return Ok($"mon body : {message}");
        }

        [HttpPost]
        public IActionResult AddPerson(
            [FromServices] SchoolContext context,
            [FromBody] Person person)
        {
            context.Add(person);
            context.SaveChanges();

            return Ok(person);
        }
    }
}
