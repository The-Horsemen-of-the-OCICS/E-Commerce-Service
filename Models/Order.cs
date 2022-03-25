namespace ecommerceapp.models;

using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

/// The order placed by the user, containing user info and items sold
public class Order {
/// Order id
    [BsonId][BsonRepresentation(BsonType.ObjectId)][JsonPropertyName("id")]
    public string? Id { get; set; }
/// The user id for the user who placed the order
    [BsonRepresentation(BsonType.ObjectId)][JsonPropertyName("userId")]
    public string UserId { get; set; }
/// The name of the user who placed the order
    [JsonPropertyName("userName")]
    public string UserName { get; set; }
/// The email of the user who placed the order
    [JsonPropertyName("userEmail")]
    public string UserEmail { get; set; }
/// The list of items in the order
    [JsonPropertyName("cartList")]
    public IList<CartItem> CartList { get; set; }
/// The total price of the order
    [JsonPropertyName("overallPrice")]
    public double OverallPrice { get; set; }
/// The date when order is placed
    [JsonPropertyName("orderDate")]
    public string OrderDate { get; set; }
/// The shipping address of the user for this order
    [JsonPropertyName("shippingAddress")]
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