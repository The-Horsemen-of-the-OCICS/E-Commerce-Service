namespace ecommerceapp.models;
public class Order {
    public string Id { get; set; }
    public List Cart { get; set; }
    public string UserId { get; set; }
    public double OverallPrice { get; set; }
    public DateTime Date { get; set; }
    public Order(){}

    public Order(string Id, string ItemId, string UserId, double OverallPrice, string Date) {
        this.Id = Id;
        this.ItemId = ItemId;
        this.UserId = UserId;
        this.OverallPrice = OverallPrice;
        this.Date = DateTime.Parse(Date);
    }
}