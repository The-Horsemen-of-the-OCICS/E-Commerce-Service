using ecommerceapp.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ecommerceapp.services;
public class OrderService {
    private readonly IMongoCollection<Order> _orders;
    private List<Order> orders = new List<Order> () {
        new Order("1", "1", "User1", "user1@gmail.com", new List<CartItem>(){new CartItem("1", "Three-Pack Off-White Jersey T-Shirts", 15 ,"placeholder", 2)}, 30, "2022-1-12", "75 Laurier Ave. E, Ottawa, ON, Canada"),
        new Order("2", "1", "User1", "user1@gmail.com", new List<CartItem>(){new CartItem("1", "Black Relaxed Sweater", 5 ,"placeholder", 2), new CartItem("2", "JW ANDERSON Glass Stand", 25 ,"https://i.postimg.cc/j5kCTjnV/16340030929e7b3bd5c75857d1c040c639acc70476-thumbnail-900x.jpg", 1)}, 35, "2022-1-20", "75 Laurier Ave. E, Ottawa, ON, Canada"),
        new Order("3", "2", "User2", "user2@gmail.com", new List<CartItem>(){new CartItem("2", "JW ANDERSON Glass Stand", 25 ,"https://i.postimg.cc/j5kCTjnV/16340030929e7b3bd5c75857d1c040c639acc70476-thumbnail-900x.jpg", 1)}, 25, "2022-1-25", "75 Laurier Ave. E, Ottawa, ON, Canada")

    };

    public OrderService(IOptions<DatabaseSettings> databaseSettings) {
        var settings = MongoClientSettings.FromConnectionString(databaseSettings.Value.ConnectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
        _orders = database.GetCollection<Order>("Orders");
    }

/// Create a new order
    public async Task CreateAsync(Order newOrder) {
        newOrder.Id = null;
        await _orders.InsertOneAsync(newOrder);
    }

/// Get all orders
    public async Task<List<Order>> GetAsync() {
        return orders;
        return await _orders.Find(_ => true).ToListAsync();
    }

/// Get a specific order by id
    public async Task<Order?> GetAsync(string Id) {
        return await _orders.Find<Order>(x => x.Id == Id).FirstOrDefaultAsync();
    }

/// Get a list of orders of a user by user id  
    public async Task<List<Order>> GetByUserIdAsync(string userId) {
        return await _orders.Find<Order>(x => x.UserId == userId).ToListAsync();
    }

/// Get a list of orders of a user by user email
    public async Task<List<Order>> GetByUserEmailAsync(string userEmail) {
        return await _orders.Find<Order>(x => x.UserEmail == userEmail).ToListAsync();
    }

/// Update a specific order by id
    public async Task<bool> UpdateAsync(string Id, Order updatedOrder) {
        ReplaceOneResult r = await _orders.ReplaceOneAsync(x => x.Id == updatedOrder.Id, updatedOrder);
        return r.IsModifiedCountAvailable && r.ModifiedCount == 1;
    }

/// Delete a specific order by id
    public async Task<bool> DeleteAsync(string Id) {
        DeleteResult r = await _orders.DeleteOneAsync(x => x.Id == Id);
        return r.DeletedCount == 1;
    }
}