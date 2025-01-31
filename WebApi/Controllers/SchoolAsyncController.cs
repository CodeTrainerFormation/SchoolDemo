using Dal;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolAsyncController : ControllerBase
    {
        private readonly SchoolContext context;

        public SchoolAsyncController(SchoolContext context)
        {
            this.context = context;
        }

        // GET : api/schoolasync
        [HttpGet]
        public async Task<IActionResult> GetAllSchools()
        {
            List<School> list = await this.context.Schools
                                                  .Include(s => s.People)
                                                  .AsNoTracking()
                                                  .ToListAsync();

            return Ok(list);
        }

        // GET : api/schoolasync/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchool([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest();

            School? school = await this.context.Schools.FindAsync(id);

            if (school == null)
                return NotFound();

            return Ok(school);
        }

        // GET : api/schoolasync/name/hexagone
        [HttpGet("name/{schoolName}")]
        public async Task<IActionResult> GetSchoolByName([FromRoute] string schoolName)
        {
            School? school = await this.context.Schools
                                               .AsNoTracking()
                                               .SingleOrDefaultAsync(s => s.Name == schoolName);

            if(school == null)
                return NotFound();

            return Ok(school);
        }

        /// <summary>
        /// Get a school by a name (startswith/endswith/contains)
        /// </summary>
        /// <param name="search">a word</param>
        /// <returns>a school</returns>
        // GET : api/schoolasync/search/name/hexa
        [HttpGet("search/name/{search}")]
        public async Task<IActionResult> GetSchool([FromRoute] string search)
        {
            return Ok(await this.context.Schools.Where(s => s.Name.Contains(search))
                                                .AsNoTracking()
                                                .ToListAsync());
        }

        // POST : api/schoolasync
        [HttpPost]
        public async Task<IActionResult> AddSchool([FromBody] School school)
        {
            this.context.Schools.Add(school);
            await this.context.SaveChangesAsync();

            return Created($"school/{school.SchoolID}", school);
        }

        // PUT : api/schoolasync/3
        [HttpPut("{id}")]
        public async Task<IActionResult> EditSchool([FromRoute] int id, [FromBody] School school)
        {
            if(id != school.SchoolID)
                return BadRequest();

            if(!this.context.Schools.Any(s => s.SchoolID == id))
                return NotFound();

            this.context.Schools.Update(school);
            await this.context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE : api/schoolasync/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSchool([FromRoute] int id)
        {
            if(id <= 0)
                return BadRequest();

            School? school = this.context.Schools.Find(id);

            if(school == null)
                return NotFound();

            this.context.Schools.Remove(school);
            await this.context.SaveChangesAsync();

            return Ok(school);
        }
    }
}
