using Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly SchoolContext context;

        public ManagerController(SchoolContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            this.context.Database.EnsureCreated();
            return Ok("oki");
        }

        [HttpGet("destroy")]
        public IActionResult Destroy()
        {
            this.context.Database.EnsureDeleted();
            return Ok("deleted");
        }
    }
}
