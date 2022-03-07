namespace ecommerceapp.models;
public class Order {
    public string Id { get; set; }
    public string ItemId { get; set; }
    public string UserId { get; set; }
    public double Price { get; set; }
    public string Date { get; set; }

    public Order(string Id, string ItemId, string UserId, double Price, string Date) {
        this.Id = Id;
        this.ItemId = ItemId;
        this.UserId = UserId;
        this.Price = Price;
        this.Date = DateTime.Parse(Date).ToString();
    }
}