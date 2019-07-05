using System.Collections.Generic;
using GraphQL.Types;
using UptownShopper_GraphQL.Data;

namespace UptownShopper_GraphQL.Entities
{
  public class ItemType : ObjectGraphType<Item>
  {
    public ItemType()
    {
      Field(i => i.ItemId);
      Field(i => i.Name);
      Field(i => i.Category);
      Field(i => i.Active);
      Field(i => i.Notes);
    }
  }
}