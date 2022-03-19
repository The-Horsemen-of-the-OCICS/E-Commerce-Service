namespace ecommerceapp.models;

// The item in a cart or a order, including the information and the quantity selected of a item
public class CartItem {
    public string Id { get; set; }
    public string Name { get; set; }
    public double ItemPrice { get; set; }
    // The URI for image
    public string Image { get; set; }
    public int Quantity { get; set; }

    public CartItem(string Id, string Name, double ItemPrice, string Image, int Quantity) {
        this.Id = Id;
        this.Name = Name;
        this.ItemPrice = ItemPrice;
        this.Image = Image;
        this.Quantity = Quantity;
    }
}