namespace ecommerceapp.models;
public class Order {
    public string Id { get; set; }
    public string UserId { get; set; }
    public IList<CartItem> ItemList { get; set; }
    public double OverallPrice { get; set; }
    public string Date { get; set; }
    public string shippingAddress { get; set; }

    public Order(string Id, string UserId, IList<CartItem> ItemList, double OverallPrice, string Date,  string shippingAddress) {
        this.Id = Id;
        this.UserId = UserId;
        this.ItemList = new List<CartItem>(ItemList);
        this.OverallPrice = OverallPrice;
        this.Date = DateTime.Parse(Date).ToString();
        this.shippingAddress = shippingAddress;
    }
}