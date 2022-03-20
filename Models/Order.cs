namespace ecommerceapp.models;

/// The order placed by the user, containing user info and items sold
public class Order {
/// Order id
    public string Id { get; set; }
/// The user id for the user who placed the order
    public string UserId { get; set; }
/// The name of the user who placed the order
    public string UserName { get; set; }
/// The email of the user who placed the order
    public string UserEmail { get; set; }
/// The list of items in the order
    public IList<CartItem> CartList { get; set; }
/// The total price of the order  
    public double OverallPrice { get; set; }
/// The date when order is placed
    public string OrderDate { get; set; }
/// The shipping address of the user for this order
    public string shippingAddress { get; set; }

    public Order(string Id, string UserId, string UserName, string UserEmail, IList<CartItem> CartList, double OverallPrice, string OrderDate,  string shippingAddress) {
        this.Id = Id;
        this.UserId = UserId;
        this.UserName = UserName;
        this.UserEmail = UserEmail;
        this.CartList = new List<CartItem>(CartList);
        this.OverallPrice = OverallPrice;
        this.OrderDate = DateTime.Parse(OrderDate).ToString();
        this.shippingAddress = shippingAddress;
    }
}