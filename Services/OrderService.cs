using ecommerceapp.models;

namespace ecommerceapp.services;
public class OrderService {
    private List<Order> orders = new List<Order> () {
        new Order("1", "1", new List<CartItem>(){new CartItem("1", "Gold 1", 50 ,"placeholder", 2)}, 25, "2022-1-12", "Ottawa"),
        new Order("2", "1", new List<CartItem>(){new CartItem("1", "Silver 1", 50 ,"placeholder", 2)}, 15, "2022-1-13", "Toronto")
    };

    public OrderService() {
    }

/// Create a new order
    public async Task CreateAsync(Order newOrder) {
        orders.Add(newOrder);
    }

/// Get all orders
    public async Task<List<Order>> GetAsync() {
        return orders;
    }

/// Get a specific order by id
    public async Task<Order?> GetAsync(string Id) {
        return orders.Find(x => x.Id == Id);
    }

/// Get a list of orders of a user by user id  
    public async Task<List<Order>> GetByUserIdAsync(string UserId) {
        return orders.FindAll(x => x.UserId == UserId);
    }

/// Update a specific order by id
    public async Task<bool> UpdateAsync(string Id, Order updatedOrder) {
        bool result = false;
        int index = orders.FindIndex(x => x.Id == Id);
        if (index != -1) {
            updatedOrder.Id = Id;
            orders[index] = updatedOrder;
            result = true;
        }
        return result;
    }

/// Delete a specific order by id
    public async Task<bool> DeleteAsync(string Id) {
        bool deleted = false;
        int index = orders.FindIndex(x => x.Id == Id);
        if (index != -1) {
            orders.RemoveAt(index);
            deleted = true;
        }
        return deleted;
    }
}