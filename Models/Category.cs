namespace ecommerceapp.models;
public class Category {
    public string Id { get; set; }
    public string Name { get; set; }
    // The URI for icon
    public string Icon { get; set; }
    
    public Category(string Id, string Name, string Icon) {
        this.Id = Id;
        this.Name = Name;
        this.Icon = Icon;
    }
}