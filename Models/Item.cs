namespace ecommerceapp.models;

using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

/// The item on sale
public class Item {
/// Item id
    [BsonId][BsonRepresentation(BsonType.ObjectId)][JsonPropertyName("id")]
    public string? Id { get; set; }
/// The name of the item
    [JsonPropertyName("name")]
    public string Name { get; set; }
/// The description of the item
    [JsonPropertyName("description")]
    public string Description { get; set; }
/// The price of the item
    [JsonPropertyName("price")]
    public double Price { get; set; }
/// The URI for image of the item
    [JsonPropertyName("image")]
    public string Image { get; set; }
/// The date when the item is created
    [JsonPropertyName("date")]
    public string Date { get; set; }
/// The category which the item belongs to
    [BsonRepresentation(BsonType.ObjectId)][JsonPropertyName("categoryId")]
    public string CategoryId {get; set;}
 /// The item is deleted or not
    [JsonPropertyName("isDeleted")]
    public bool IsDeleted {get; set;}   

    public Item(string Id, string Name, string Description, double Price, string Image, string Date, string CategoryId) {
        this.Id = Id;
        this.Name = Name;
        this.Description = Description;
        this.Price = Price;
        this.Image = Image;
        this.Date = DateTime.Parse(Date).ToString();
        this.CategoryId = CategoryId;
        this.IsDeleted = false;
    }
}
