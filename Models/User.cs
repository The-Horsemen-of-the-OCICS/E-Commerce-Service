namespace ecommerceapp.models;
public class User {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public IList<CartItem> Cart { get; set; }
    public string DefaultAddress { get; set;}
    public User(string Id, string Name, string Email, string Password, IList<CartItem> Cart, string DefaultAddress) {
        this.Id = Id;
        this.Name = Name;
        this.Email = Email;
        this.Password = Password;
        this.Cart = new List<CartItem>(Cart);
        this.DefaultAddress = DefaultAddress;
    }
}