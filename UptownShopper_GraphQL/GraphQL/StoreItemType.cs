using System.Numerics;
using GraphQL.Types;

namespace UptownShopper_GraphQL.GraphQL
{
  public class StoreInputType : InputObjectGraphType
  {
    public StoreInputType()
    {
      Name = "StoreInput";
      Field<NonNullGraphType<StringGraphType>>("name");
      Field<NonNullGraphType<BooleanGraphType>>("location");
      Field<NonNullGraphType<StringGraphType>>("category");
      Field<NonNullGraphType<IntGraphType>>("itemId");
    }
  }
}