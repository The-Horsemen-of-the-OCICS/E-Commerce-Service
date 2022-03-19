namespace ecommerceapp.models;

// The shipping information of the user, including phone number and address
public class ShippingInfo {
    public string Phone { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set;}
    public ShippingInfo(string Phone, string Street, string City, string State, string Country) {
        this.Phone = Phone;
        this.Street = Street;
        this.City = City;
        this.State = State;
        this.Country = Country;
    }
}