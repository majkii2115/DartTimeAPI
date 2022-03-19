using DartTime.Models;
using Microsoft.EntityFrameworkCore;

namespace DartTime.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}