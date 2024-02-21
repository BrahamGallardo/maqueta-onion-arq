using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.Arq.Application.Interfaces.Services;
using Onion.Arq.Application.Models;

namespace Onion.Arq.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserCommandService _userCommandService;
        public UserController(IUserCommandService userCommandService)
        {
            _userCommandService = userCommandService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody]UserDto userDto)
        {
            try
            {
                UserDto result = await _userCommandService.CreateUserAsync(userDto);
                return Ok(result);
            }
            catch (Exception e)
            {
                Exception ex = e.InnerException ?? new Exception(e.Message);
                return StatusCode(500, ex);
            }
        }
    }
}
