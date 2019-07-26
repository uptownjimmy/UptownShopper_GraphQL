using GraphQL.Types;

namespace UptownShopper_GraphQL.GraphQL
{
  public class ItemInputType : InputObjectGraphType
  {
    public ItemInputType()
    {
      Name = "ItemInput";
      Field<IdGraphType>("itemId"); // this is necessary for delete, but farts on create and update
      Field<NonNullGraphType<StringGraphType>>("name");
      Field<NonNullGraphType<StringGraphType>>("category");
      Field<NonNullGraphType<BooleanGraphType>>("active");
      Field<NonNullGraphType<StringGraphType>>("notes");
    }
  }
}