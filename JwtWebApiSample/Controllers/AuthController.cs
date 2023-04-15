using JwtWebApiSample.Models;

using Microsoft.AspNetCore.Mvc;

namespace JwtWebApiSample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    public static User user = new();

    [HttpPost("register")]
    public ActionResult<User> Register(UserDto request)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        user.Username = request.Username;
        user.PasswordHash = passwordHash;

        return Ok(user);
    }
}
