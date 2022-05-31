namespace SensorManagement.Services;

using AutoMapper;
using BCrypt.Net;
using Microsoft.Extensions.Options;
using SensorManagement.Authorization;
using SensorManagement.Helpers;
using SensorManagement.Models.Users;

public class UserService : IUserService
{
    private DataContext _context;
    private readonly IMapper _mapper;
    private IJwtUtils _jwtUtils;
    private readonly AppSettings _appSettings;

    public UserService(
        DataContext context,
        IMapper mapper,
        IJwtUtils jwtUtils,
        IOptions<AppSettings> appSettings)
    {
        _context = context;
        _mapper = mapper;
        _jwtUtils = jwtUtils;
        _appSettings = appSettings.Value;
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }

    public User GetById(int id)
    {
        return GetUser(id);
    }

    public void Create(UserCreateRequest model)
    {
        if (_context.Users.Any(x => x.Username == model.Username))
            throw new AppException($"User with the name '{model.Username}' already exists");

        var user = _mapper.Map<User>(model);

        user.PasswordHash = BCrypt.HashPassword(model.Password);

        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(int id, UserUpdateRequest model)
    {
        var user = GetUser(id);

        // validate
        if (model.Username != user.Username && _context.Users.Any(x => x.Username == model.Username))
            throw new AppException($"User with the username '{model.Username}' already exists");

        if (!string.IsNullOrEmpty(model.Password))
            user.PasswordHash = BCrypt.HashPassword(model.Password);

        _mapper.Map(model, user);
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = GetUser(id);
        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    public UserAuthenticateResponse Authenticate(UserAuthenticateRequest model)
    {
        var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);

        if (user == null || !BCrypt.Verify(model.Password, user.PasswordHash))
        {
            throw new AppException("Username or password is incorrect");
        }

        var jwtToken = _jwtUtils.GenerateJwtToken(user);

        return new UserAuthenticateResponse(user, jwtToken);
    }

    // helper methods

    private User GetUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            throw new KeyNotFoundException("User not found");
        }
            
        return user;
    }

}