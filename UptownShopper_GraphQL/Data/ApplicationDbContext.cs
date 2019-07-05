using Microsoft.EntityFrameworkCore;
using UptownShopper_GraphQL.Entities;

namespace UptownShopper_GraphQL.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Item> Item { get; set; }
    public DbSet<Store> Store { get; set; }
    public DbSet<StoreItem> StoreItem { get; set; }
  }
}