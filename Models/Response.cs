namespace ecommerceapp.models;

using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

// The reponse submitted by the user
public class Response {
/// Response id
    [BsonId][BsonRepresentation(BsonType.ObjectId)][JsonPropertyName("id")]
    public string? Id { get; set; }
/// The question id for the question which the response submitted to
    [BsonRepresentation(BsonType.ObjectId)][JsonPropertyName("questionId")]
    public string QuestionId { get; set; }
/// The user id for the user who submit the response
    [BsonRepresentation(BsonType.ObjectId)][JsonPropertyName("userId")]
    public string UserId { get; set; }
/// The body of the response
    [JsonPropertyName("body")]
    public string Body { get; set; }
/// The date when the response is submitted
    [JsonPropertyName("date")]
    public string Date { get; set; }
/// The number of upvotes for the response
    [JsonPropertyName("upvotes")]
    public int Upvotes { get; set;}

    public Response(string Id, string QuestionId, string UserId, string Body, string Date, int Upvotes) {
        this.Id = Id;
        this.QuestionId = QuestionId;
        this.UserId = UserId;
        this.Body = Body;
        this.Date = DateTime.Parse(Date).ToString();
        this.Upvotes = Upvotes;
    }
}
