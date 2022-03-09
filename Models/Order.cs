namespace ecommerceapp.models;
public class Order {
    public string Id { get; set; }
    public string UserId { get; set; }
    public IList<CartItem> CartList { get; set; }
    public double OverallPrice { get; set; }
    public string OrderDate { get; set; }
    public string shippingAddress { get; set; }

    public Order(string Id, string UserId, IList<CartItem> CartList, double OverallPrice, string OrderDate,  string shippingAddress) {
        this.Id = Id;
        this.UserId = UserId;
        this.CartList = new List<CartItem>(CartList);
        this.OverallPrice = OverallPrice;
        this.OrderDate = DateTime.Parse(OrderDate).ToString();
        this.shippingAddress = shippingAddress;
    }
}