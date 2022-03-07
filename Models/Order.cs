namespace ecommerceapp.models;
public class Order {
    public string Id { get; set; }
    public List Cart { get; set; }
    public string UserId { get; set; }
<<<<<<< HEAD
    public double Price { get; set; }
    public string Date { get; set; }

    public Order(string Id, string ItemId, string UserId, double Price, string Date) {
        this.Id = Id;
        this.ItemId = ItemId;
        this.UserId = UserId;
        this.Price = Price;
        this.Date = DateTime.Parse(Date).ToString();
=======
    public double OverallPrice { get; set; }
    public DateTime Date { get; set; }
    public string shippingAddress { get; set; }
    public Order(){}

    public Order(string Id, string ItemId, string UserId, double OverallPrice, string Date,  string shippingAddress) {
        this.Id = Id;
        this.ItemId = ItemId;
        this.UserId = UserId;
        this.OverallPrice = OverallPrice;
        this.Date = DateTime.Parse(Date);
        this.shippingAddress = shippingAddress;
>>>>>>> 60084c0394afbb188cf8ef052e7dbfb75c2bc537
    }
}