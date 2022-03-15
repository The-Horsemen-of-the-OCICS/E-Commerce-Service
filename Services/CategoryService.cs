using ecommerceapp.models;

namespace ecommerceapp.services;
public class CategoryService {
    private List<Category> categories = new List<Category> () {
        new Category("1", "Men", "https://i.postimg.cc/NfRGJDDv/7534386-cardigan-knitwear-women-fashion-clothing-icon.png"),
        new Category("2", "Women", "https://i.postimg.cc/cLsWDS6f/7534390-women-shirt-tops-fashion-clothing-icon.png"),
        new Category("3", "Kids", "https://i.postimg.cc/zvbZgzt1/7534391-women-shirt-tops-fashion-clothing-icon.png"),
        new Category("4", "Home", "https://i.postimg.cc/NjpcSzrS/7534405-makeup-beauty-women-fashion-female-icon.png"),
    };

    public CategoryService() {
    }

    public async Task CreateAsync(Category newCategory) {
        categories.Add(newCategory);
    }

    public async Task<List<Category>> GetAsync() {
        return categories;
    }

    public async Task<Category?> GetAsync(string Id) {
        return categories.Find(x => x.Id == Id);
    }

    public async Task<bool> UpdateAsync(string Id, Category updatedCategory) {
        bool result = false;
        int index = categories.FindIndex(x => x.Id == Id);
        if (index != -1) {
            updatedCategory.Id = Id;
            categories[index] = updatedCategory;
            result = true;
        }
        return result;
    }

    public async Task<bool> DeleteAsync(string Id) {
        bool deleted = false;
        int index = categories.FindIndex(x => x.Id == Id);
        if (index != -1) {
            categories.RemoveAt(index);
            deleted = true;
        }
        return deleted;
    }
}