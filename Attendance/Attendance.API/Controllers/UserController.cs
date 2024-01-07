using Attendance.Application.DTOs;
using Attendance.Application.Interfaces;
using Attendance.Domain.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Attendance.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly IAuthenticateAsync _authenticateService;
    private readonly IUserService _userService;

    public AuthController(IAuthenticateAsync authenticateService, IUserService userService)
    {
        _authenticateService = authenticateService;
        _userService = userService;
    }

    [HttpPost("register")]

    public async Task<ActionResult<UserToken>> Register(UserCreateDto userDto)
    {
        if (userDto == null)
            return BadRequest("Invalid data");

        var emailExists = await _authenticateService.UserExists(userDto.Email);

        if (emailExists)
            return BadRequest("Email already exists");

        var user = await _userService.CreateUserAsync(userDto);

        if (user == null)
            return BadRequest("Failed to register");

        var token = _authenticateService.GenerateToken(user.Id, user.Email);

        return new UserToken
        {
            Token = token,
        };
    }

    [HttpPost("login")]

    public async Task<ActionResult<UserToken>> Login(UserLoginDto loginDto)
    {
        if (loginDto == null)
            return BadRequest("Invalid login data");

        var isAuthenticated = await _authenticateService.AuthenticateAsync(loginDto.Email, loginDto.Password);

        if (!isAuthenticated)
            return Unauthorized("Invalid credentials");

        var user = await _userService.GetUserByEmailAsync(loginDto.Email);

        if (user == null)
            return NotFound("User not found");

        var token = _authenticateService.GenerateToken(user.Id, user.Email);

        return new UserToken
        {
            Token = token,
        };
    }
}
