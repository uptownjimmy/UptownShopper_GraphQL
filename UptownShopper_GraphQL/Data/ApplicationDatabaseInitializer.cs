using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UptownShopper_GraphQL.Entities;

namespace UptownShopper_GraphQL.Data
{
  public class ApplicationDatabaseInitializer
  {
    public async Task SeedAsync(IApplicationBuilder app)
    {
      using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
      {
        var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await applicationDbContext.Database.EnsureDeletedAsync();
        await applicationDbContext.Database.MigrateAsync();
        await applicationDbContext.Database.EnsureCreatedAsync();

        var items = new List<Item>
        {
          new Item { Name= "Bananas", Category = "Grocery", Active = true, Notes = ""},
          new Item { Name= "Coffee", Category = "Grocery", Active = true, Notes = ""},
          new Item { Name= "Grapes", Category = "Grocery", Active = true, Notes = ""},
        };
        
        var stores = new List<Store>
        {
          new Store { Name = "Kroger", Location = "", Category = "Grocery"},
          new Store { Name = "Publix", Location = "", Category = "Grocery"},
          new Store { Name = "Lowes", Location = "", Category = "Hardware"},
        };
        
        var storeItems = new List<StoreItem>
        {
          new StoreItem { StoreId = 1, ItemId = 1},
        };


        await applicationDbContext.Item.AddRangeAsync(items);
        await applicationDbContext.Store.AddRangeAsync(stores);
        await applicationDbContext.StoreItem.AddRangeAsync(storeItems);

        await applicationDbContext.SaveChangesAsync();
      }
    }
  }
}