namespace ecommerceapp.models;

using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

/// The question submitted by the user
public class Question {
/// Question id
    [BsonId][BsonRepresentation(BsonType.ObjectId)][JsonPropertyName("id")]
    public string? Id { get; set; }
/// The user id for the user who submits the question
    [BsonRepresentation(BsonType.ObjectId)][JsonPropertyName("userId")]
    public string UserId { get; set; }
/// The title of the question
    [JsonPropertyName("title")]
    public string Title { get; set; }
/// The body of the question
    [JsonPropertyName("body")]
    public string Body { get; set; }
/// The date when the question is submitted
    [JsonPropertyName("date")]
    public string Date { get; set; }
/// The number of upvotes for the question
    [JsonPropertyName("upvotes")]
    public int Upvotes { get; set;}

    public Question(string Id, string UserId, string Title, string Body, string Date, int Upvotes) {
        this.Id = Id;
        this.UserId = UserId;
        this.Title = Title;
        this.Body = Body;
        this.Date = DateTime.Parse(Date).ToString();
        this.Upvotes = Upvotes;
    }
}
