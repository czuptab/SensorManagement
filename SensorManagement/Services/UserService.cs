namespace SensorManagement.Services;

using AutoMapper;
using BCrypt.Net;
using SensorManagement.Helpers;
using SensorManagement.Models.Users;

public class UserService : IUserService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public UserService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
        if (_context.Users.Any(x => x.Name == model.Name))
            throw new AppException($"User with the name '{model.Name}' already exists");

        var user = _mapper.Map<User>(model);

        user.PasswordHash = BCrypt.HashPassword(model.Password);

        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(int id, UserUpdateRequest model)
    {
        var user = GetUser(id);

        // validate
        if (model.Name != user.Name && _context.Users.Any(x => x.Name == model.Name))
            throw new AppException($"User with the name '{model.Name}' already exists");

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