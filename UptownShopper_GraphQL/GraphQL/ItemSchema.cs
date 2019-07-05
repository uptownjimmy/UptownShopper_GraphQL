using GraphQL;
using GraphQL.Types;

namespace UptownShopper_GraphQL.GraphQL
{
  public class ItemSchema : Schema
  {
    public ItemSchema(IDependencyResolver resolver) : base(resolver)
    {
      Query = resolver.Resolve <ItemQuery> ();
      Mutation = resolver.Resolve <ItemMutation> ();
    }
  }
}