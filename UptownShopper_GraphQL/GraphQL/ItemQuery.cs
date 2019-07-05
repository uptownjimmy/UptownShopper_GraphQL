using System.Collections.Generic;
using GraphQL.Types;
using UptownShopper_GraphQL.Data;
using UptownShopper_GraphQL.Entities;

namespace UptownShopper_GraphQL.GraphQL
{
  public class ItemQuery : ObjectGraphType
  {
    public ItemQuery(IDataStore dataStore)
    {
      Field<ItemType, Item>()
        .Name("Item")
        .Argument<NonNullGraphType<IntGraphType>>("id", "item id")
        .ResolveAsync(ctx =>
        {
          var id = ctx.GetArgument<int>("id");
          return dataStore.GetItemByIdAsync(id);
        });
      
      Field<ListGraphType<ItemType>, IEnumerable<Item>>()
        .Name("Items")
        .ResolveAsync(ctx => dataStore.GetItemsAsync());

      Field<StoreType, Store>()
        .Name("Store")
        .Argument<NonNullGraphType<IntGraphType>>("id", "store id")
        .ResolveAsync(ctx =>
        {
          var id = ctx.GetArgument<int>("id");
          return dataStore.GetStoreByIdAsync(id);
        });
      
      Field<ListGraphType<StoreType>, IEnumerable<Store>>()  
        .Name("Stores")
        .ResolveAsync(ctx => dataStore.GetStoresAsync());
      
      Field<StoreItemType, StoreItem>()
        .Name("StoreItem")
        .Argument<NonNullGraphType<IntGraphType>>("id", "storeItem id")
        .ResolveAsync(ctx =>
        {
          var id = ctx.GetArgument<int>("id");
          return dataStore.GetStoreItemByIdAsync(id);
        });
      
      Field<ListGraphType<StoreItemType>, IEnumerable<StoreItem>>()  
        .Name("StoreItems")
        .ResolveAsync(ctx => dataStore.GetStoreItemsAsync());
    }
  }
}