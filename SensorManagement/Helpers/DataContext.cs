namespace SensorManagement.Helpers;

using Microsoft.EntityFrameworkCore;
using SensorManagement.Models.Temperature;
using SensorManagement.Models.Users;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<User> Users { get; set; }
    public DbSet<TemperatureLog> Temperatures { get; set; }
}