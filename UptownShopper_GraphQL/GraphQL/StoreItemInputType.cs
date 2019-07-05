using GraphQL.Types;

namespace UptownShopper_GraphQL.GraphQL
{
  public class StoreItemInputType : InputObjectGraphType 
  {
    public StoreItemInputType()
    {
      Name = "StoreItemInput";
      Field<NonNullGraphType<IntGraphType>>("itemId");
      Field<NonNullGraphType<IntGraphType>>("storeId");
    }
  }
}