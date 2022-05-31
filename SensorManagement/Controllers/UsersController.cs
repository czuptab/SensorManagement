namespace SensorManagement.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SensorManagement.Authorization;
using SensorManagement.Models.Users;
using SensorManagement.Services;

[Authorize]
[ApiController]
[Route("[controller]/users")]
public class UsersController : ControllerBase
{
    private IUserService _userService;
    private IMapper _mapper;

    public UsersController(
        IUserService userService,
        IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [Authorize(Role.Admin)]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

    [AllowAnonymous]
    [HttpPost("[action]")]
    public IActionResult Authenticate(UserAuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);
        return Ok(response);
    }


    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var currentUser = (User)HttpContext.Items["User"];

        if (id != currentUser.Id && currentUser.Role != Role.Admin)
        {
            return Unauthorized(new { message = "Unauthorized" });
        }

        var user = _userService.GetById(id);
        return Ok(user);
    }

    [Authorize(Role.Admin)]
    [HttpPost]
    public IActionResult Create(UserCreateRequest model)
    {
        _userService.Create(model);
        return Ok(new { message = "User created" });
    }

    [Authorize(Role.Admin)]
    [HttpPut("{id}")]
    public IActionResult Update(int id, UserUpdateRequest model)
    {
        _userService.Update(id, model);
        return Ok(new { message = "User updated" });
    }

    [Authorize(Role.Admin)]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _userService.Delete(id);
        return Ok(new { message = "User deleted" });
    }
}