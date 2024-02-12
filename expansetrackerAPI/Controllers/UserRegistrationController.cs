using expansetrackerAPI.BAL;
using expansetrackerAPI.Data.Repo;
using expansetrackerAPI.Interfaces;
using expansetrackerAPI.Models;
using Microsoft.AspNetCore.Authorization;
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
        private readonly JwtService _jwtService;
        private readonly IUserRepository _userRepository;
        private readonly ExpanseDbContext _context;
        Response response = new Response();

        public UserRegistrationController(JwtService jwtService, ExpanseDbContext expanseDbContext,IUserRepository userRepository)
        {
            _jwtService = jwtService;
            _context = expanseDbContext;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("registerUser")]
        public async Task<ActionResult<Response>> registerUser(UserRegisterApi userRegister)
        {
                if (await _userRepository.UserAlreadyExist(userRegister.UserName))
                {
                    response.Status = 509;
                    response.Message = "User Already exist! Try some another name";
                    return response;
                }
            
                _userRepository.Register(userRegister);
                await _context.SaveChangesAsync();
                response.Status = 201;
                response.Message = "User Registered Successfully";
                return response;

        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<Response>> Login(string UserName,string password)
        {
            var user = await _userRepository.Authenticate(UserName, password);
            if (user == null)
            {
                response.Status = 509;
                response.Message = "Unauthorised invalid passsword";
                return response;
            }
            else
            {
                var token = _jwtService.GenerateJwtToken(user.UserName);

                return Ok(new { token });

            }
            
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Response>> GetPersonalDetail()
        {
            response.Status = 200;
            response.Message = "Welcome";
            return response;
        }
    }
}
 