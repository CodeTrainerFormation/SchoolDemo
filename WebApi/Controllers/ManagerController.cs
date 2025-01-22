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
        private readonly ILogger<ManagerController> logger;

        public ManagerController(SchoolContext context, ILogger<ManagerController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Create()
        {
            this.logger.Log(LogLevel.Information, "verification si la base existe OU création de la base");
            this.context.Database.EnsureCreated();
            this.logger.LogInformation("base de données crée OU déjà présente");

            return Ok("oki");
        }

        [HttpGet("destroy")]
        public IActionResult Destroy()
        {
            this.context.Database.EnsureDeleted();
            this.logger.LogInformation("base de données détruite OU non présente");

            return Ok("deleted");
        }
    }
}
