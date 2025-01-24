using Dal;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var list = this.context.Schools
                                   .Include(s => s.People)
                                   .ToList();
            return Ok(list);
        }

        // GET : api/school/3
        [HttpGet("{id}")]
        public IActionResult GetSchool([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest();

            School? school = this.context.Schools.Find(id);

            if (school == null)
                return NotFound();

            return Ok(school);
        }

        // GET : api/school/name/hexagone
        [HttpGet("name/{schoolName}")]
        public IActionResult GetSchoolByName([FromRoute] string schoolName)
        {
            School? school = this.context.Schools.SingleOrDefault(s => s.Name == schoolName);

            if(school == null)
                return NotFound();

            return Ok(school);
        }

        /// <summary>
        /// Get a school by a name (startswith/endswith/contains)
        /// </summary>
        /// <param name="search">a word</param>
        /// <returns>a school</returns>
        // GET : api/school/search/name/hexa
        [HttpGet("search/name/{search}")]
        public IActionResult GetSchool([FromRoute] string search)
        {
            return Ok(this.context.Schools.Where(s => s.Name.Contains(search)));
        }

        // POST : api/school
        [HttpPost]
        public IActionResult AddSchool([FromBody] School school)
        {
            this.context.Schools.Add(school);
            this.context.SaveChanges();

            return Created($"school/{school.SchoolID}", school);
        }

        // PUT : api/school/3
        [HttpPut("{id}")]
        public IActionResult EditSchool([FromRoute] int id, [FromBody] School school)
        {
            if(id != school.SchoolID)
                return BadRequest();

            if(!this.context.Schools.Any(s => s.SchoolID == id))
                return NotFound();

            this.context.Schools.Update(school);
            this.context.SaveChanges();

            return NoContent();
        }

        // DELETE : api/school/3
        [HttpDelete("{id}")]
        public IActionResult RemoveSchool([FromRoute] int id)
        {
            if(id <= 0)
                return BadRequest();

            School? school = this.context.Schools.Find(id);

            if(school == null)
                return NotFound();

            this.context.Schools.Remove(school);
            this.context.SaveChanges();

            return Ok(school);
        }
    }
}
