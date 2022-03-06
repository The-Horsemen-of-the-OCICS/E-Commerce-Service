namespace ecommerceapp.models;
public class Question {
    public string Id { get; set; }
    public string UserId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime Date { get; set; }
    public int Upvotes { get; set;}
    public Question(){}

    public Question(string Id, string UserId, string Title, string Body, string Date, int Upvotes) {
        this.Id = Id;
        this.UserId = UserId;
        this.Title = Title;
        this.Body = Body;
        this.Date = DateTime.Parse(Date);
        this.Upvotes = Upvotes;
    }
}
