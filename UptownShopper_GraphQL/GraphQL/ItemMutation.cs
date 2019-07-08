using GraphQL.Types;
using UptownShopper_GraphQL.Data;
using UptownShopper_GraphQL.Entities;

namespace UptownShopper_GraphQL.GraphQL
{
  public class ItemMutation : ObjectGraphType
  {
    public ItemMutation(IDataStore dataStore)
    {         
      Field<ItemType, Item>()
        .Name("createItem")
        .Argument<NonNullGraphType<ItemInputType>>("item", "item input")
        .ResolveAsync(ctx =>
        {
          var item = ctx.GetArgument<Item>("item");
          return dataStore.CreateItemAsync(item);
        });
      
      Field<ItemType, Item>()
        .Name("updateItem")
        .Argument<NonNullGraphType<IntGraphType>>("itemId", "itemId input")
        .Argument<NonNullGraphType<ItemInputType>>("item", "item input")
        .Resolve(ctx =>
        {
          var itemId = ctx.GetArgument<int>("itemId");
          var item = ctx.GetArgument<Item>("item");
          return dataStore.UpdateItem(itemId, item);
        });
      
      Field<StoreType, Store>()
        .Name("createStore")
        .Argument<NonNullGraphType<StoreInputType>>("store", "store input")
        .ResolveAsync(ctx =>
        {
          var store = ctx.GetArgument<Store>("store");
          return dataStore.CreateStoreAsync(store);
        });
      
      Field<StoreItemType, StoreItem>()  
        .Name("addStoreItem")
        .Argument<NonNullGraphType<StoreItemInputType>>("storeItem", "storeItem input")
        .ResolveAsync(ctx =>
        {
          var storeItem = ctx.GetArgument<StoreItem>("storeItem");
          return dataStore.AddStoreItemAsync(storeItem);
        });
    }
  }
}