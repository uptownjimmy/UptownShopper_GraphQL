using System.Collections.Generic;

namespace UptownShopper_GraphQL.Entities
{
  public class Item
  {
    public long ItemId { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public bool Active { get; set; }
    public string Notes { get; set; }
    public IEnumerable<Store> Stores { get; set; }
  }
}