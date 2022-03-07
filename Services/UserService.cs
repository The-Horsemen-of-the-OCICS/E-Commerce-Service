using ecommerceapp.models;

namespace ecommerceapp.services;
public class UserService {
    static private ShippingInfo mockShippingInfo = new ShippingInfo(
        "1111111111",
        "75 Laurier Ave. E",
        "Ottawa",
        "ON",
        "Canada");
    private List<User> users = new List<User> () {
        new User("0", "Admin", "Admin@email.com", "hash", new List<CartItem>(), mockShippingInfo),
        new User("1", "User1", "User1@email.com", "hash", new List<CartItem>(){new CartItem("1", "Gold 1", 50 ,"placeholder", 2)}, mockShippingInfo),
        new User("2", "User2", "User2@email.com", "hash", new List<CartItem>(){new CartItem("1", "Gold 1", 50 ,"placeholder", 2), new CartItem("2", "Silver 1", 15 ,"placeholder", 1)}, mockShippingInfo),
        new User("3", "User3", "User3@email.com", "hash", new List<CartItem>(), mockShippingInfo)
    };

    public UserService() {
    }

    public async Task CreateAsync(User newUser) {
        users.Add(newUser);
    }

    public async Task<List<User>> GetAsync() {
        return users;
    }

    public async Task<User?> GetAsync(string Id) {
        return users.Find(x => x.Id == Id);
    }

    public async Task<bool> UpdateAsync(string Id, User updatedUser) {
        bool result = false;
        int index = users.FindIndex(x => x.Id == Id);
        if (index != -1) {
            updatedUser.Id = Id;
            users[index] = updatedUser;
            result = true;
        }
        return result;
    }

    public async Task<bool> DeleteAsync(string Id) {
        bool deleted = false;
        int index = users.FindIndex(x => x.Id == Id);
        if (index != -1) {
            users.RemoveAt(index);
            deleted = true;
        }
        return deleted;
    }
}