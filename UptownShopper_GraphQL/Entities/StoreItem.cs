using System.ComponentModel.DataAnnotations.Schema;

namespace UptownShopper_GraphQL.Entities
{
  [Table("StoreItem", Schema = "dbo")]
  public class StoreItem
  {
    public int Id { get; set; }

    public int ItemId { get; set; }
    public Item Item { get; set; }

    public int StoreId { get; set; }
    public Store Store { get; set; }
  }
}