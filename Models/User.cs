namespace ecommerceapp.models;
public class User {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public IList<CartItem> Cart { get; set; }
    public ShippingInfo DefaultShippingInfo { get; set;}
    public User(string Id, string Name, string Email, string Password, IList<CartItem> Cart, ShippingInfo DefaultShippingInfo) {
        this.Id = Id;
        this.Name = Name;
        this.Email = Email;
        this.Password = Password;
        this.Cart = new List<CartItem>(Cart);
        this.DefaultShippingInfo = DefaultShippingInfo;
    }
}