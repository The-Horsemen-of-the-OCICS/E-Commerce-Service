namespace ecommerceapp.models;

using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

// User contains profile information and login credentials
public class User {
/// User id
    [BsonId][BsonRepresentation(BsonType.ObjectId)][JsonPropertyName("id")]
    public string? Id { get; set; }
/// The name of the user
    [JsonPropertyName("name")]
    public string Name { get; set; }
/// The email of the user
    [JsonPropertyName("email")]
    public string Email { get; set; }
/// The password of the user
    [JsonPropertyName("password")]
    public string Password { get; set; }
/// The list of items in the cart of the user
    [JsonPropertyName("cart")]
    public IList<CartItem> Cart { get; set; }
/// The shipping info saved as default for the user
    [JsonPropertyName("defaultShippingInfo")]
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