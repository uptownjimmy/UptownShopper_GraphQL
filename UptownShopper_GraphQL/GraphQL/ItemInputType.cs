using GraphQL.Types;

namespace UptownShopper_GraphQL.GraphQL
{
  public class ItemInputType : InputObjectGraphType
  {
    public ItemInputType()
    {
      Name = "ItemInput";
      Field<NonNullGraphType<StringGraphType>>("name");
      Field<NonNullGraphType<StringGraphType>>("category");
      Field<NonNullGraphType<BooleanGraphType>>("active");
      Field<NonNullGraphType<StringGraphType>>("notes");
    }
  }
}