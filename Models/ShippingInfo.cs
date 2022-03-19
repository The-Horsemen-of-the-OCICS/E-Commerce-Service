namespace ecommerceapp.models;

// The shipping information of the user class, including phone number and address
public class ShippingInfo {
/// The phone number for shipping
    public string Phone { get; set; }
/// The street for shipping
    public string Street { get; set; }
/// The city for shipping
    public string City { get; set; }
/// The state or province for shipping
    public string State { get; set; }
/// The country for shipping
    public string Country { get; set;}
    public ShippingInfo(string Phone, string Street, string City, string State, string Country) {
        this.Phone = Phone;
        this.Street = Street;
        this.City = City;
        this.State = State;
        this.Country = Country;
    }
}