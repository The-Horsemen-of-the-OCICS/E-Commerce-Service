using ecommerceapp.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ecommerceapp.services;
public class CategoryService {
    private readonly IMongoCollection<Category> _categories;

    public CategoryService(IOptions<DatabaseSettings> databaseSettings) {
        var settings = MongoClientSettings.FromConnectionString(databaseSettings.Value.ConnectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
        _categories = database.GetCollection<Category>("Categories");
    }

/// Create a new category
    public async Task CreateAsync(Category newCategory) {
        newCategory.Id = null;
        await _categories.InsertOneAsync(newCategory);
    }

/// Get all categories in database
    public async Task<List<Category>> GetAsync() {
        return await _categories.Find(_ => true).ToListAsync();
    }

/// Get a specific category by id
    public async Task<Category?> GetAsync(string Id) {
        return await _categories.Find<Category>(x => x.Id == Id).FirstOrDefaultAsync();
    }

/// Update a specific category by id
    public async Task<bool> UpdateAsync(string Id, Category updatedCategory) {
        ReplaceOneResult r = await _categories.ReplaceOneAsync(x => x.Id == updatedCategory.Id, updatedCategory);
        return r.IsModifiedCountAvailable && r.ModifiedCount == 1;
    }

/// Delete a specific category by id
    public async Task<bool> DeleteAsync(string Id) {
        DeleteResult r = await _categories.DeleteOneAsync(x => x.Id == Id);
        return r.DeletedCount == 1;
    }
}