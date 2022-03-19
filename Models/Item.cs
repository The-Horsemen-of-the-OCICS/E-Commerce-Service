namespace ecommerceapp.models;

/// The item on sale
public class Item {
/// Item id
    public string Id { get; set; }
/// The name of the item
    public string Name { get; set; }
/// The description of the item
    public string Description { get; set; }
/// The price of the item
    public double Price { get; set; }
/// The URI for image of the item
    public string Image { get; set; }
/// The date when the item is created
    public string Date { get; set; }
/// The category which the item belongs to
    public string CategoryId {get; set;}

    public Item(string Id, string Name, string Description, double Price, string Image, string Date, string CategoryId) {
        this.Id = Id;
        this.Name = Name;
        this.Description = Description;
        this.Price = Price;
        this.Image = Image;
        this.Date = DateTime.Parse(Date).ToString();
        this.CategoryId = CategoryId;
    }
}
