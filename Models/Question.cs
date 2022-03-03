namespace ecommerceapp.models;
public class Question {
    public string Id { get; set; }
    public string UserId { get; set; }
    public string Body { get; set; }
    public DateTime Date { get; set; }

    public Question(string Id, string UserId, string Body, string Date) {
        this.Id = Id;
        this.UserId = UserId;
        this.Body = Body;
        this.Date = DateTime.Parse(Date);
    }
}
