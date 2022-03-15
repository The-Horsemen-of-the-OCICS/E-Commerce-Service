using ecommerceapp.models;
using ecommerceapp.services;
using Microsoft.AspNetCore.Mvc;

namespace ecommerceapp.controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ItemController : ControllerBase{
    private readonly ItemService _itemService;
    public ItemController(ItemService itemService) {
        this._itemService = itemService;
    }

/// GET API return a list of items
    [HttpGet]
    public async Task<List<Item>> Get() {
        return await _itemService.GetAsync();
    }

/// GET API return a list of items with a specific category
    [HttpGet("category/{categoryId}")]
    public async Task<List<Item>> GetByCategoryId(string categoryId) {
        return await _itemService.GetByCategoryIdAsync(categoryId);
    }


/// GET API return a specific item
    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> Get(string Id) {
        var item = await _itemService.GetAsync(Id);
        if (item is null) {
            return NotFound();
        }
        return item;
    }

/// POST API add a item
    [HttpPost]
    public async Task<ActionResult> Post(Item newItem) {
        await _itemService.CreateAsync(newItem);
        return CreatedAtAction(nameof(Get), new {id = newItem.Id}, newItem);
    }

/// PUT API update a item
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(string Id, Item updatedItem) {
        bool updated = await _itemService.UpdateAsync(Id, updatedItem);
        if (!updated) {
            // this assumes that a failed update is always caused by the object 
            // not being found. This needs to be changed if the cause may be different
            return NotFound();
        } 
        return NoContent();
    }


/// DELETE API delete a item
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string Id) {
        var item = await _itemService.GetAsync(Id);
        if (item is null) {
            return NotFound();
        }
        await _itemService.DeleteAsync(item.Id);
        return NoContent();
    }
}