using Dal;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly SchoolContext context;

        public SchoolController(SchoolContext context)
        {
            this.context = context;
        }

        // GET : api/school
        [HttpGet]
        public IActionResult GetAllSchools()
        {
            var list = this.context.Schools.ToList();
            return Ok(list);
        }

        // POST : api/school
        [HttpPost]
        public IActionResult AddSchool(School school)
        {
            this.context.Schools.Add(school);
            this.context.SaveChanges();

            return Created($"school/{school.SchoolID}", school);
        }
    }
}
