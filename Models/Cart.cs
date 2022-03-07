namespace ecommerceapp.models;
public class Cart {
    public Item Item { get; set; }
    public int numOfItem { get; set; }
    
    public Cart(){}
    public Cart(Item Item, int numOfItem) {
        this.Item = Item;
        this.numOfItem = numOfItem;
    }
}