using GraphQL.Types;

namespace UptownShopper_GraphQL.GraphQL
{
  public class HelloWorldSchema : Schema
  {
    public HelloWorldSchema(HelloWorldQuery query)
    {
      Query = query;
    }
  }
}