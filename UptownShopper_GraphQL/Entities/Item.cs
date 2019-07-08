using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UptownShopper_GraphQL.Entities
{
  [Table("Item", Schema = "dbo")]
  public class Item
  {
    public int ItemId { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public bool Active { get; set; }
    public string Notes { get; set; }
    
    public IEnumerable<StoreItem> StoreItems { get; set; }
  }
}