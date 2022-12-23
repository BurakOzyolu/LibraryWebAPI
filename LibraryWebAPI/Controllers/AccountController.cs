using LibraryWebAPI.Models;
using LibraryWebAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        MyContext _context;

        public AccountController(MyContext context)
        {
            _context = context;
        }
         
        [HttpPost]
        [Route("register")]
        public IActionResult Register(User model)
        {
            RegisterResponseViewModel response = new RegisterResponseViewModel();
            var IsUserAlready = _context.Users.Any(x => x.UserName == model.UserName);
            if (IsUserAlready)
            {
                response.StatusCode = 100;
                response.StatusMessage = "Bu kullanıcı adı zaten var";
                return Ok(response);
            }

            if (ModelState.IsValid)
            {
                var User = new User()
                {
                    UserName = model.UserName,
                    Password = model.Password,
                    Email = model.Email,
                    Role = model.Role,
                    IsDeleted = false,
                    PhoneNo = model.PhoneNo
                };
                response.UserName = model.UserName;
                response.Password = model.Password;
                response.Email = model.Email;
                response.Role = model.Role;
                response.IsDeleted = false;
                response.PhoneNo = model.PhoneNo;
                response.StatusCode = 200;
                response.StatusMessage = "Registration succesfull";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Registration failed";
            }

            return Ok(response);
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(User model)
        {
            RegisterResponseViewModel response = new RegisterResponseViewModel();
            var Login = _context.Users.Any(x => x.UserName == model.UserName && x.Password ==model.Password);
            if (Login)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Login succesfull";
                response.Role = model.Role;
                response.Email = model.Email;
                response.UserName = model.UserName;
                return Ok(response);
            }
            else
            {
                return Ok("Login failed");
            }
        }
    }
}
/*

        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            return null;
        }

        [HttpGet]
        [Authorize]
        [Route("logout")]

        public async Task<IActionResult> Logout()
        {
            return null;
        } 
 
 
 */




/*

 */