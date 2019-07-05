using GraphQL.DataLoader;
using GraphQL.Types;
using UptownShopper_GraphQL.Data;

namespace UptownShopper_GraphQL.Entities
{
  public class StoreType : ObjectGraphType<Store>
  {
    public StoreType(IDataStore dataStore, IDataLoaderContextAccessor accessor) {
      Field(s => s.Name);
      Field(s => s.Location);
      Field(s => s.Category);
//      Field<ItemType, Item>()
//        .Name("Item")
//        .ResolveAsync(context =>
//        {
//          // Get or add a batch loader with the key "GetUsersById"
//          // The loader will call GetUsersByIdAsync for each batch of keys
//          var loader = accessor.Context.GetOrAddBatchLoader<int, Item>("GetItemsById", dataStore.GetItemsByIdAsync);
//
//          // Add this UserId to the pending keys to fetch
//          // The task will complete once the GetUsersByIdAsync() returns with the batched results
//          return loader.LoadAsync(context.Source.ItemId);
//        });
    }
  }
}