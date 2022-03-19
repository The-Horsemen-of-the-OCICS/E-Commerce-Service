using ecommerceapp.models;

namespace ecommerceapp.services;
public class ItemService {
    private List<Item> items = new List<Item> () {
        new Item("1", "JW ANDERSON", "JW ANDERSON Glass Stand", 25 ,"https://i.postimg.cc/j5kCTjnV/16340030929e7b3bd5c75857d1c040c639acc70476-thumbnail-900x.jpg", "2022-1-12", "4"),
        new Item("2", "ESSENTIALS", "Three-Pack Off-White Jersey T-Shirts", 15, "https://i.postimg.cc/Pr0ZZSxG/1641969100f69da7264d8688d9c11e7ce8cd3597b0-thumbnail-900x.jpg", "2022-1-12", "1"),
        new Item("3", "ESSENTIALS", "Black Relaxed Sweater", 5, "https://i.postimg.cc/2yMqQ5Cd/1624937261e1565ed7bb7611d917ff2e6a9ffe580a-thumbnail-900x.jpg", "2022-1-12", "2"),
        new Item("4", "DEPARTO", "Blue Large Kitchen Set", 5, "https://i.postimg.cc/d10DgC1m/16172552205a1794e7dc17db68856850f0c26eeb53-thumbnail-900x.jpg", "2022-1-12", "4"),
        new Item("5", "JW ANDERSON", "JW ANDERSON Glass Stand", 25 ,"https://i.postimg.cc/j5kCTjnV/16340030929e7b3bd5c75857d1c040c639acc70476-thumbnail-900x.jpg", "2022-1-12", "4"),
        new Item("6", "ESSENTIALS", "Three-Pack Off-White Jersey T-Shirts", 15, "https://i.postimg.cc/Pr0ZZSxG/1641969100f69da7264d8688d9c11e7ce8cd3597b0-thumbnail-900x.jpg", "2022-1-12", "1"),
        new Item("7", "ESSENTIALS", "Black Relaxed Sweater", 5, "https://i.postimg.cc/2yMqQ5Cd/1624937261e1565ed7bb7611d917ff2e6a9ffe580a-thumbnail-900x.jpg", "2022-1-12", "2"),
        new Item("8", "DEPARTO", "Blue Large Kitchen Set", 5, "https://i.postimg.cc/d10DgC1m/16172552205a1794e7dc17db68856850f0c26eeb53-thumbnail-900x.jpg", "2022-1-12", "4"),
        new Item("9", "JW ANDERSON", "JW ANDERSON Glass Stand", 25 ,"https://i.postimg.cc/j5kCTjnV/16340030929e7b3bd5c75857d1c040c639acc70476-thumbnail-900x.jpg", "2022-1-12", "4"),
        new Item("10", "ESSENTIALS", "Three-Pack Off-White Jersey T-Shirts", 15, "https://i.postimg.cc/Pr0ZZSxG/1641969100f69da7264d8688d9c11e7ce8cd3597b0-thumbnail-900x.jpg", "2022-1-12", "1"),
        new Item("11", "ESSENTIALS", "Black Relaxed Sweater", 5, "https://i.postimg.cc/2yMqQ5Cd/1624937261e1565ed7bb7611d917ff2e6a9ffe580a-thumbnail-900x.jpg", "2022-1-12", "2"),
        new Item("12", "DEPARTO", "Blue Large Kitchen Set", 5, "https://i.postimg.cc/d10DgC1m/16172552205a1794e7dc17db68856850f0c26eeb53-thumbnail-900x.jpg", "2022-1-12", "4"),
    };

    public ItemService() {
    }

/// Create a new item
    public async Task CreateAsync(Item newItem) {
        items.Add(newItem);
    }

/// Get all items in database
    public async Task<List<Item>> GetAsync() {
        return items;
    }

/// Get a list of items by category
    public async  Task<List<Item>> GetByCategoryIdAsync(string categoryId) {
        return items.FindAll(x => x.CategoryId == categoryId) ?? new List<Item>();
    }

/// Get a specific item by id
    public async Task<Item?> GetAsync(string Id) {
        return items.Find(x => x.Id == Id);
    }

/// Update a specific item by id
    public async Task<bool> UpdateAsync(string Id, Item updatedItem) {
        bool result = false;
        int index = items.FindIndex(x => x.Id == Id);
        if (index != -1) {
            updatedItem.Id = Id;
            items[index] = updatedItem;
            result = true;
        }
        return result;
    }

/// Delete a specific item by id
    public async Task<bool> DeleteAsync(string Id) {
        bool deleted = false;
        int index = items.FindIndex(x => x.Id == Id);
        if (index != -1) {
            items.RemoveAt(index);
            deleted = true;
        }
        return deleted;
    }
}
