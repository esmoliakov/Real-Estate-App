using Microsoft.EntityFrameworkCore;
using RealEstateApp.Shared.Models;

namespace Server.Data;

public class RealEstateDbContext : DbContext
{
    public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options)
        : base(options) { }

    public DbSet<Listing> Listings { get; set; }
    public DbSet<User> Users { get; set; }
}
