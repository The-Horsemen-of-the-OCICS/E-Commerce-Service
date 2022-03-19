using ecommerceapp.models;

namespace ecommerceapp.services;
public class OrderService {
    private List<Order> orders = new List<Order> () {
        new Order("1", "1", new List<CartItem>(){new CartItem("1", "Three-Pack Off-White Jersey T-Shirts", 15 ,"placeholder", 2)}, 30, "2022-1-12", "75 Laurier Ave. E, Ottawa, ON, Canada"),
        new Order("2", "1", new List<CartItem>(){new CartItem("1", "Black Relaxed Sweater", 5 ,"placeholder", 2), new CartItem("2", "JW ANDERSON Glass Stand", 25 ,"https://i.postimg.cc/j5kCTjnV/16340030929e7b3bd5c75857d1c040c639acc70476-thumbnail-900x.jpg", 1)}, 35, "2022-1-13", "75 Laurier Ave. E, Ottawa, ON, Canada")
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