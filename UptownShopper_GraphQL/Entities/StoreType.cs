using GraphQL.Types;
using UptownShopper_GraphQL.Data;

namespace UptownShopper_GraphQL.Entities
{
  public class StoreType : ObjectGraphType<Store>
  {
    public StoreType(IDataStore dataStore) {
      Field(s => s.Name);
      Field(s => s.Location);
      Field <ItemType, Item> ()
        .Name("Item")
        .ResolveAsync(ctx => dataStore.GetItemByIdAsync(ctx.Source.ItemId));
    }
  }
}