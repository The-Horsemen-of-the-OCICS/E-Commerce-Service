using ecommerceapp.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ecommerceapp.services;
public class OrderService {
    private readonly IMongoCollection<Order> _orders;
    
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
        return await _orders.Find(_ => true).SortByDescending(x => x.OrderDate).ToListAsync();
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