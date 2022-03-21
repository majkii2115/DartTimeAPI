using DartTimeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DartTimeAPI.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}