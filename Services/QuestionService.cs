using ecommerceapp.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ecommerceapp.services;
public class QuestionService {
    private readonly IMongoCollection<Question> _questions;
    private readonly ResponseService _responseService;
    private List<Question> questions = new List<Question> () {
        new Question("1", "1", "Is shipping free", "Hi I wonder if shipping is free???", "2022-1-12", 1),
        new Question("2", "2", "Do you ship to Canada", "Does this ship to Canada?", "2022-1-12", 1)
    };

    public QuestionService(ResponseService responseService, IOptions<DatabaseSettings> databaseSettings) {
        _responseService = responseService;
        var settings = MongoClientSettings.FromConnectionString(databaseSettings.Value.ConnectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
        _questions = database.GetCollection<Question>("Questions");
    }

/// Create a question
    public async Task CreateAsync(Question newQuestion) {
        newQuestion.Id = null;
        await _questions.InsertOneAsync(newQuestion);
    }

/// Get all questions
    public async Task<List<Question>> GetAsync() {
        return await _questions.Find(_ => true).ToListAsync();
    }

/// Get a specific question by id
    public async Task<Question?> GetAsync(string Id) {
        return await _questions.Find<Question>(x => x.Id == Id).FirstOrDefaultAsync();
    }

/// Update a specific question by id
    public async Task<bool> UpdateAsync(string Id, Question updatedQuestion) {
        ReplaceOneResult r = await _questions.ReplaceOneAsync(x => x.Id == updatedQuestion.Id, updatedQuestion);
        return r.IsModifiedCountAvailable && r.ModifiedCount == 1;
    }

/// Delete a specific question by id
    public async Task<bool> DeleteAsync(string Id) {
        DeleteResult r = await _questions.DeleteOneAsync(x => x.Id == Id);
        await _responseService.DeleteByQuestionAsync(Id);
        return r.DeletedCount == 1;
    }
}