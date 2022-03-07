using ecommerceapp.models;

namespace ecommerceapp.services;
public class UserService {
    static private ShippingInfo mockShippingInfo = new ShippingInfo(
        "(111) 222-3333",
        "75 Laurier Ave. E",
        "Ottawa",
        "ON",
        "Canada");
    private List<User> users = new List<User> () {
        new User("0", "Admin", "admin@email.com", "hash", new List<CartItem>(), mockShippingInfo),
        new User("1", "Test Costomer 1", "user1@email.com", "hash", new List<CartItem>(){new CartItem("1", "Gold 1", 50 ,"placeholder", 2)}, mockShippingInfo),
        new User("2", "Test Costomer 2", "user2@email.com", "hash", new List<CartItem>(){new CartItem("1", "Gold 1", 50 ,"placeholder", 2), new CartItem("2", "Silver 1", 15 ,"placeholder", 1)}, mockShippingInfo),
        new User("3", "Test Costomer 3", "user3@email.com", "hash", new List<CartItem>(), mockShippingInfo)
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
    public async Task<bool> UpdateShippingInfoAsync(string Id, ShippingInfo newInfo) {
        bool result = false;
        int index = users.FindIndex(x => x.Id == Id);
        if (index != -1) {
            users[index].DefaultShippingInfo = newInfo;
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