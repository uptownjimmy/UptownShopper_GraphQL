using System.Collections.Generic;
using System.Linq;

namespace UptownShopper_GraphQL.Entities
{
  public class DataSource
  {
    private IList<Item> Items
    {
      get;
      set;
    }
    
    public DataSource()
    {
      Items = new List<Item>(){
        new Item { Name= "Bananas", Category = "Grocery", Active = true, Notes = ""},
        new Item { Name= "Bread", Category = "Grocery", Active = false, Notes = ""},
        new Item { Name= "Coffee", Category = "Grocery", Active = true, Notes = ""},
      };
    }

    public Item GetItemByName(string name)
    {
      return Items.First(i => i.Name.Equals(name));
    }
  }
  
  
}