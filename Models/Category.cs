namespace ecommerceapp.models;

using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

/// The category for items
public class Category {
/// Category id
    [BsonId][BsonRepresentation(BsonType.ObjectId)][JsonPropertyName("id")]
    public string? Id { get; set; }
/// The name of the category
    [JsonPropertyName("name")]
    public string Name { get; set; }
/// The URI for icon of the category
    [JsonPropertyName("icon")]
    public string Icon { get; set; }
    
    public Category(string Id, string Name, string Icon) {
        this.Id = Id;
        this.Name = Name;
        this.Icon = Icon;
    }
}