using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JwtAuthApplication.Api.Controllers
{
    [ApiController]
    public class UserController : BaseController
    {
        [HttpGet("users")]
        public IActionResult ListUsers()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("create")]
        public void CreateUser() { }

        [HttpPut("update")]
        public void UpdateUser() { }

        [HttpPut("update-password")]
        public void UpdatePassword() { }

        [HttpDelete("delete")]
        public void DeleteUser() { }
    }
}
