using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UptownShopper_GraphQL.Entities
{
  [Table("Store", Schema = "dbo")]
  public class Store
  {
    public int StoreId { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Category { get; set; }

    public IEnumerable<StoreItem> StoreItems { get; set; }
  }
}