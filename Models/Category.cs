namespace ecommerceapp.models;
public class Category {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    
    public Category(string Id, string Name, string Icon) {
        this.Id = Id;
        this.Name = Name;
        this.Icon = Icon;
    }
}