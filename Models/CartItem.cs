namespace ecommerceapp.models;

/// The item in a cart or a order, including the information and the quantity selected of a item
public class CartItem {
/// Item id
    public string Id { get; set; }
/// The name of the item
    public string Name { get; set; }
/// The price of the single item
    public double ItemPrice { get; set; }
/// The URI for image of the item
    public string Image { get; set; }
/// The quantity selected for the item
    public int Quantity { get; set; }

    public CartItem(string Id, string Name, double ItemPrice, string Image, int Quantity) {
        this.Id = Id;
        this.Name = Name;
        this.ItemPrice = ItemPrice;
        this.Image = Image;
        this.Quantity = Quantity;
    }
}