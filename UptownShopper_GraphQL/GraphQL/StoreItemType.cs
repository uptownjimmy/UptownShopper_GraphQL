using System.Numerics;
using GraphQL.Types;
using UptownShopper_GraphQL.Data;
using UptownShopper_GraphQL.Entities;

namespace UptownShopper_GraphQL.GraphQL
{
  public class StoreItemType : ObjectGraphType<StoreItem> 
  {
    public StoreItemType(IDataStore dataStore)
    {
      Field(i => i.ItemId);      

      Field<ItemType, Item>().Name("Item").ResolveAsync(ctx => dataStore.GetItemByIdAsync(ctx.Source.ItemId));         

      Field(s => s.StoreId);

      Field<StoreType, Store>().Name("Store").ResolveAsync(ctx => dataStore.GetStoreByIdAsync(ctx.Source.StoreId));
    }
  }
}