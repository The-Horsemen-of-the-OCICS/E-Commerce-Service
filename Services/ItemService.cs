using ecommerceapp.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ecommerceapp.services;
public class ItemService {
    private readonly IMongoCollection<Item> _items;
    
    public ItemService(IOptions<DatabaseSettings> databaseSettings) {
        var settings = MongoClientSettings.FromConnectionString(databaseSettings.Value.ConnectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
        _items = database.GetCollection<Item>("Items");
    }

/// Create a new item
    public async Task CreateAsync(Item newItem) {
        newItem.Id = null;
        await _items.InsertOneAsync(newItem);
    }

/// Get all items in database
    public async Task<List<Item>> GetAsync() {
        return await _items.Find(_ => true).SortByDescending(x => x.Date).ToListAsync();
    }

/// Get a list of items by category
    public async  Task<List<Item>> GetByCategoryIdAsync(string categoryId) {
        return await _items.Find<Item>(x => x.CategoryId == categoryId).SortByDescending(x => x.Date).ToListAsync();
    }

/// Get a specific item by id
    public async Task<Item?> GetAsync(string Id) {
        return await _items.Find<Item>(x => x.Id == Id).FirstOrDefaultAsync();
    }

/// Update a specific item by id
    public async Task<bool> UpdateAsync(string Id, Item updatedItem) {
        ReplaceOneResult r = await _items.ReplaceOneAsync(x => x.Id == updatedItem.Id, updatedItem);
        return r.IsModifiedCountAvailable && r.ModifiedCount == 1;
    }

/// Delete a specific item by id
    public async Task<bool> DeleteAsync(string Id) {
         DeleteResult r = await _items.DeleteOneAsync(x => x.Id == Id);
        return r.DeletedCount == 1;
    }
}
