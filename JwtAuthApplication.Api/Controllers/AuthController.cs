using Microsoft.AspNetCore.Mvc;

namespace JwtAuthApplication.Api.Controllers
{
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost]
        public void GetToken() { }
    }
}
