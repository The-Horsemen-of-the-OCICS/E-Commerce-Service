namespace ecommerceapp.models;
public class CartItem {
    public string ItemId { get; set; }
    public string Name { get; set; }
    public double TotalPrice { get; set; }
    public string Image { get; set; }
    public int Quantity { get; set; }

    public CartItem(string ItemId, string Name, double TotalPrice, string Image, int Quantity) {
        this.ItemId = ItemId;
        this.Name = Name;
        this.TotalPrice = TotalPrice;
        this.Image = Image;
        this.Quantity = Quantity;
    }
}