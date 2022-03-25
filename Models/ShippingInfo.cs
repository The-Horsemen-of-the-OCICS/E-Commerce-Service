namespace ecommerceapp.models;

using System.Text.Json.Serialization;

// The shipping information of the user class, including phone number and address
public class ShippingInfo {
/// The phone number for shipping
    [JsonPropertyName("phone")]
    public string Phone { get; set; }
/// The street for shipping
    [JsonPropertyName("street")]
    public string Street { get; set; }
/// The city for shipping
    [JsonPropertyName("city")]
    public string City { get; set; }
/// The state or province for shipping
    [JsonPropertyName("state")]
    public string State { get; set; }
/// The country for shipping
    [JsonPropertyName("country")]
    public string Country { get; set;}
    public ShippingInfo(string Phone, string Street, string City, string State, string Country) {
        this.Phone = Phone;
        this.Street = Street;
        this.City = City;
        this.State = State;
        this.Country = Country;
    }
}