using System;
using System.Threading.Tasks;
using Kwikemart_API.Models;
using Kwikemart_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kwikemart_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginDTO login)
        {
            try
            {
                var result = await _userService.AuthenticateAsync(login.UserName, login.Password);

                if (result == null)
                    return BadRequest("Incorrect username or password");

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}