using ecommerceapp.models;

namespace ecommerceapp.services;
public class ResponseService {
    private List<Response> responses = new List<Response> () {
        new Response("1", "1", "0", "Yes it is free", "2022-1-13", 1),
        new Response("2", "1", "0", "Yes it is free!!!", "2022-1-13", 3),
        new Response("3", "2", "0", "Yes it does", "2022-1-13", 2),
        new Response("4", "2", "0", "I don't know", "2022-1-13", 1)
    };

    public ResponseService() {
    }

    public async Task CreateAsync(Response newResponse) {
        responses.Add(newResponse);
    }

    public async Task<List<Response>> GetAsync() {
        return responses;
    }

    public async Task<List<Response>> GetByQuestionAsync(string QuestionId) {
        List<Response> list = new List<Response>();
        foreach (Response r in responses) {
            if (r.QuestionId == QuestionId)
                list.Add(r);
        }
        return list;
    }

    public async Task<Response> GetAsync(string Id) {
        return responses.Find(x => x.Id == Id);
    }

    public async Task<int> GetResponseCountByQuestionIdAsync(string QuestionId) {
        return responses.Count(x => x.QuestionId == QuestionId);
    }

    public async Task<bool> UpdateAsync(string Id, Response updatedResponse) {
        bool result = false;
        int index = responses.FindIndex(x => x.Id == Id);
        if (index != -1) {
            updatedResponse.Id = Id;
            responses[index] = updatedResponse;
            result = true;
        }
        return result;
    }

    public async Task<bool> DeleteAsync(string Id) {
        bool deleted = false;
        int index = responses.FindIndex(x => x.Id == Id);
        if (index != -1) {
            responses.RemoveAt(index);
            deleted = true;
        }
        return deleted;
    }

    public async Task<bool> DeleteByQuestionAsync(string QuestionId) {
        bool deleted = false;

        int index = responses.FindIndex(x => x.QuestionId == QuestionId);
        if (index != -1) {
            responses.RemoveAll(x => x.QuestionId == QuestionId);
            deleted = true;
        }
        return deleted;
    }
}