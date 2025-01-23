using Dal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
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

        //[Authorize(Roles = "Admin")]
        [HttpGet("destroy")]
        public IActionResult Destroy()
        {
            //if(!base.User.Identity!.IsAuthenticated)
            //    return Forbid();

            //if(!base.User.IsInRole("Admin"))
            //    return Unauthorized();

            this.context.Database.EnsureDeleted();
            this.logger.LogInformation("base de données détruite OU non présente");

            return Ok("deleted");
        }

        [MyFilter]
        [HttpGet("error")]
        public IActionResult Error()
        {
            throw new NotImplementedException();
        }
    }
}
