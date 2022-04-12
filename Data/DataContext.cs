using DartTimeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DartTimeAPI.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Friendship> Friendships { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Friendship>().HasKey(x=> new {x.UserId, x.UserFriendId});
        builder.Entity<Friendship>().HasOne(x => x.User).WithMany(x => x.Friends).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Friendship>().HasOne(x => x.UserFriend).WithMany(x => x.FriendsOf).HasForeignKey(x => x.UserFriendId).OnDelete(DeleteBehavior.Restrict);
    }

}