namespace UptownShopper_GraphQL.Entities
{
  public class Store
  {
    public long StoreId { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Category { get; set; }

    public Item Item { get; set; }
    public long ItemId { get; set; }
  }
}