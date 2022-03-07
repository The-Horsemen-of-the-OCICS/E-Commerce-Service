namespace ecommerceapp.models;
public class Response {
    public string Id { get; set; }
    public string QuestionId { get; set; }
    public string UserId { get; set; }
    public string Body { get; set; }
    public DateTime Date { get; set; }
    public int Upvotes { get; set;}

    public Response(string Id, string QuestionId, string UserId, string Body, string Date, int Upvotes) {
        this.Id = Id;
        this.QuestionId = QuestionId;
        this.UserId = UserId;
        this.Body = Body;
        this.Date = DateTime.Parse(Date);
        this.Upvotes = Upvotes;
    }
}
