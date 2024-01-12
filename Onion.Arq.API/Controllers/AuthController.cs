using Onion.Arq.Application.Interfaces.Services;
using Onion.Arq.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Onion.Arq.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISessionAsyncService _sessionAsync;

        public AuthController(ISessionAsyncService sessionAsync)
        {
            _sessionAsync = sessionAsync;
        }

        [HttpPost]
        public async Task<ActionResult<SessionDto>> Post(string email, string password)
        {
            try
            {
                SessionDto session = await _sessionAsync.GetSessionAsync(email, password);
                return session != null ? Ok(session) : NotFound();
            }
            catch (Exception e)
            {
                var ex = e.InnerException ?? new Exception(e.Message);
                return StatusCode(500, ex);
            }
        }
    }
}
