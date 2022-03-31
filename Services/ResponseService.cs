using ecommerceapp.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ecommerceapp.services;
public class ResponseService {
    private readonly IMongoCollection<Response> _responses;

    public ResponseService(IOptions<DatabaseSettings> databaseSettings) {
        var settings = MongoClientSettings.FromConnectionString(databaseSettings.Value.ConnectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
        _responses = database.GetCollection<Response>("Responses");
    }

/// Create a response
    public async Task CreateAsync(Response newResponse) {
        newResponse.Id = null;
        await _responses.InsertOneAsync(newResponse);
    }

/// Get all responses in database
    public async Task<List<Response>> GetAsync() {
        return await _responses.Find(_ => true).SortByDescending(x => x.Date).ToListAsync();
    }

/// Get all responses for a question by question id
    public async Task<List<Response>> GetByQuestionAsync(string questionId) {
        return await _responses.Find<Response>(x => x.QuestionId == questionId).SortByDescending(x => x.Date).ToListAsync();
    }

/// Get a specific response by id
    public async Task<Response?> GetAsync(string Id) {
        return await _responses.Find<Response>(x => x.Id == Id).FirstOrDefaultAsync();
    }

/// Get the number of responses for a question by question id
    public async Task<long> GetResponseCountByQuestionIdAsync(string questionId) {
        return await _responses.Find<Response>(x => x.QuestionId == questionId).CountDocumentsAsync();
    }

/// Update a specific response by id
    public async Task<bool> UpdateAsync(string Id, Response updatedResponse) {
        ReplaceOneResult r = await _responses.ReplaceOneAsync(x => x.Id == updatedResponse.Id, updatedResponse);
        return r.IsModifiedCountAvailable && r.ModifiedCount == 1;
    }

/// Delete a specific response by id
    public async Task<bool> DeleteAsync(string Id) {
        DeleteResult r = await _responses.DeleteOneAsync(x => x.Id == Id);
        return r.DeletedCount == 1;
    }

/// Delete responses by question id
    public async Task<bool> DeleteByQuestionAsync(string questionId) {
        DeleteResult r = await _responses.DeleteManyAsync(x => x.QuestionId == questionId);
        return r.DeletedCount >= 1;
    }
}