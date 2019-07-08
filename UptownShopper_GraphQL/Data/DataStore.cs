using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UptownShopper_GraphQL.Entities;

namespace UptownShopper_GraphQL.Data
{
  public interface IDataStore
  {
    Task<Item> GetItemByIdAsync(int itemId);
    Task<IDictionary<int, Item>> GetItemsByIdAsync(IEnumerable<int> itemIds, CancellationToken token);
    Task<IEnumerable<Item>> GetItemsAsync();
    Task<Item> CreateItemAsync(Item item);
    Item UpdateItem(int itemId, Item item);
    
    Task<StoreItem> GetStoreItemByIdAsync(int storeItemId);
    Task<Store> GetStoreByIdAsync(int storeId);
    Task<IEnumerable<Store>> GetStoresAsync();
//    Task<IEnumerable<Store>> GetStoresByItemIdAsync(int itemId);
    Task<Store> CreateStoreAsync(Store store);
    Task<StoreItem> AddStoreItemAsync(StoreItem storeItem);
    Task<IEnumerable<StoreItem>> GetStoreItemsAsync();
  }

  public class DataStore : IDataStore
  {
    private readonly ApplicationDbContext _applicationDbContext;

    public DataStore(ApplicationDbContext applicationDbContext)
    {
      _applicationDbContext = applicationDbContext;
    }
    
    public async Task<Item> GetItemByIdAsync(int itemId)
    {
      return await _applicationDbContext.Item.FindAsync(itemId);
    }

    public async Task<IDictionary<int, Item>> GetItemsByIdAsync(IEnumerable<int> itemIds, CancellationToken token)  
    {
      return await _applicationDbContext.Item.Where(i => itemIds.Contains(i.ItemId)).ToDictionaryAsync(x => x.ItemId, token);
    }
    
    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
      return await _applicationDbContext.Item.AsNoTracking().ToListAsync();
    }

    public async Task<Item> CreateItemAsync(Item item)  
    {
      var addedItem = await _applicationDbContext.Item.AddAsync(item);
      await _applicationDbContext.SaveChangesAsync();
      return addedItem.Entity;
    }

    public Item UpdateItem(int itemId, Item item)
    {
      var updatedItem = _applicationDbContext.Item.SingleOrDefault(i => i.ItemId == itemId);
      
      if (updatedItem != null)
      {
        updatedItem.Name = item.Name;
        updatedItem.Category = item.Category;
        updatedItem.Active = item.Active;
        updatedItem.Notes = item.Notes;
        _applicationDbContext.SaveChanges();
      }

      return updatedItem;
    }
    
    
    
    
    
    
    
    public async Task<Store> GetStoreByIdAsync(int storeId)
    {
      return await _applicationDbContext.Store.FindAsync(storeId);
    }
    
    public async Task<StoreItem> GetStoreItemByIdAsync(int storeItemId)
    {
      return await _applicationDbContext.StoreItem.FindAsync(storeItemId);
    }
    
    public async Task<StoreItem> AddStoreItemAsync(StoreItem storeItem)  
    {         
      var addedStoreItem = await _applicationDbContext.StoreItem.AddAsync(storeItem);
      await _applicationDbContext.SaveChangesAsync();
      return addedStoreItem.Entity;
    }
    
    public async Task<IEnumerable<StoreItem>> GetStoreItemsAsync()  
    {         
      return await _applicationDbContext.StoreItem.AsNoTracking().ToListAsync();
    }
    
    public async Task <IEnumerable<Store>> GetStoresAsync() {  
      return await _applicationDbContext.Store.AsNoTracking().ToListAsync();
    }
    
//    public async Task<IEnumerable<Store>> GetStoresByItemIdAsync(int itemId)
//    {
//      return await _applicationDbContext.Stores.Where(s => s.ItemId == itemId).ToListAsync();
//    }
    
    public async Task<Store> CreateStoreAsync(Store store)  
    {
      var addedStore = await _applicationDbContext.Store.AddAsync(store);
      await _applicationDbContext.SaveChangesAsync();
      return addedStore.Entity;
    }
  }
}