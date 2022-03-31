using ecommerceapp.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ecommerceapp.services;
public class UserService {
    private readonly IMongoCollection<User> _users;
    
    public UserService(IOptions<DatabaseSettings> databaseSettings) {
        var settings = MongoClientSettings.FromConnectionString(databaseSettings.Value.ConnectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
        _users = database.GetCollection<User>("Users");
    }

/// Create a user
    public async Task CreateAsync(User newUser) {
        newUser.Id = null;
        await _users.InsertOneAsync(newUser);
    }

/// Get all users in database
    public async Task<List<User>> GetAsync() {
        return await _users.Find(_ => true).ToListAsync();
    }

/// Get a specific user by id
    public async Task<User?> GetAsync(string Id) {
        return await _users.Find<User>(x => x.Id == Id).FirstOrDefaultAsync();
    }

/// Get a specific user by email
    public async Task<User?> GetByEmailAsync(string email) {
        return await _users.Find<User>(x => x.Email == email).FirstOrDefaultAsync();
    }

/// Update a specific user by id
    public async Task<bool> UpdateAsync(string Id, User updatedUser) {
        ReplaceOneResult r = await _users.ReplaceOneAsync(x => x.Id == updatedUser.Id, updatedUser);
        return r.IsModifiedCountAvailable && r.ModifiedCount == 1;
    }

/// Update only shipping info for a specific user by id
    public async Task<bool> UpdateShippingInfoAsync(string Id, ShippingInfo newInfo) {
        UpdateResult r = await _users.UpdateOneAsync(x => x.Id == Id, Builders<User>.Update
                            .Set(u => u.DefaultShippingInfo, newInfo));
        return r.IsModifiedCountAvailable && r.ModifiedCount == 1;
    }

/// Delete a specific user by id
    public async Task<bool> DeleteAsync(string Id) {
        DeleteResult r = await _users.DeleteOneAsync(x => x.Id == Id);
        return r.DeletedCount == 1;
    }
}