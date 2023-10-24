using BasicJWTAuth.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BasicJWTAuth.Repository;
using Microsoft.AspNetCore.Authorization;

namespace BasicJWTAuth.Repository
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository ijwtManagerRepository;

        public UsersController(IJWTManagerRepository ijwtManagerRepository)
        {
            this.ijwtManagerRepository = ijwtManagerRepository;
        }
        [HttpGet]
        [Route("userlist")]
        public List<string> Get()
        {
            var users = new List<string>()
            {
                "Satinder singh",
                "Amit sarna",
                "David John"
            };
            return users;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Users userdata)
        {
            

            var Token = ijwtManagerRepository.Authenticate(userdata);
                
            if(Token == null)
            {
                return Unauthorized();
            }
            return Ok(Token);
                
        }
    }
}
