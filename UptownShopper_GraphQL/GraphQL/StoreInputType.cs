using GraphQL.Types;

namespace UptownShopper_GraphQL.GraphQL
{
  public class StoreInputType : InputObjectGraphType
  {
    public StoreInputType()
    {
      Name = "StoreInput";
      Field<NonNullGraphType<StringGraphType>>("name");
      Field<NonNullGraphType<StringGraphType>>("location");
      Field<NonNullGraphType<StringGraphType>>("category");
    }
  }
}