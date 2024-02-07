using expansetrackerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;    

namespace expansetrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ExpanseDbContext _context;

        public UserRegistrationController(IConfiguration configuration,ExpanseDbContext expanseDbContext)
        {
            _configuration = configuration;
            _context = expanseDbContext;
        }

        [HttpPost]
        [Route("registerUser")]
        public async Task<ActionResult<string>> registerUser(UserRegistraion userRegistraion)
        {
                var User = await _context.userRegistraions.AnyAsync(x=>x.UserName == userRegistraion.UserName);
                if (User is false)
                {
                    _context.userRegistraions.Add(userRegistraion);
                    await _context.SaveChangesAsync();
                    return Ok("User Registered Successfully");
                }
                else
                {
                    return Ok("UserName Already Exist");
                }
                
        }
    }
}
