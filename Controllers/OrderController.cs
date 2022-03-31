using ecommerceapp.models;
using ecommerceapp.services;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace ecommerceapp.controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class OrderController : ControllerBase{
    private readonly OrderService _orderService;
    public OrderController(OrderService orderService) {
        this._orderService = orderService;
    }

/// GET API return a list of orders
    [HttpGet]
    public async Task<List<Order>> Get() {
        return await _orderService.GetAsync();
    } 


/// GET API return a specific order
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> Get(string Id) {
        var order = await _orderService.GetAsync(Id);
        if (order is null) {
            return NotFound();
        }
        return order;
    }

/// GET API return orders by user ID
    [HttpGet("u/{userId}")]
    public async Task<List<Order>> GetByUserId(string userId) {
        return await _orderService.GetByUserIdAsync(userId);
    }

/// GET API return orders by user email
    [HttpGet("email/{userEmail}")]
    public async Task<List<Order>> GetByUserEmail(string userEmail) {
        return await _orderService.GetByUserEmailAsync(HttpUtility.UrlDecode(userEmail));
    }

/// POST API add a order
    [HttpPost]
    public async Task<ActionResult> Post(Order newOrder) {
        await _orderService.CreateAsync(newOrder);
        return CreatedAtAction(nameof(Get), new {id = newOrder.Id}, newOrder);
    }

/// PUT API update a order
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(string Id, Order updatedOrder) {
        bool updated = await _orderService.UpdateAsync(Id, updatedOrder);
        if (!updated) {
            // this assumes that a failed update is always caused by the object 
            // not being found. This needs to be changed if the cause may be different
            return NotFound();
        } 
        return NoContent();
    }


/// DELETE API delete a order
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string Id) {
        var order = await _orderService.GetAsync(Id);
        if (order is null) {
            return NotFound();
        }
        await _orderService.DeleteAsync(Id);
        return NoContent();
    }
}