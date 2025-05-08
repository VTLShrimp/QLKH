using Microsoft.AspNetCore.Mvc;
using QLKhoHang.Entities;

namespace QLKhoHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllInventoryItems()
        {
            var items = await _inventoryService.GetAllItemsAsync();
            return Ok(items);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateInventoryItem([FromBody] InventoryModel inventory)
        {
            if (inventory == null)
            {
                return BadRequest("Invalid inventory data.");
            }

            var createdItem = await _inventoryService.AddItemAsync(inventory);
            return CreatedAtAction(nameof(GetAllInventoryItems), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateInventoryItem(int id, [FromBody] InventoryModel inventory)
        {
            var updatedItem = await _inventoryService.UpdateItemAsync(id, inventory);
            if (updatedItem == null)
            {
                return NotFound("Inventory item not found.");
            }
            return Ok(updatedItem);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteInventoryItem(int id)
        {
            var isDeleted = await _inventoryService.DeleteItemAsync(id);
            if (!isDeleted)
            {
                return NotFound("Inventory item not found.");
            }
            return NoContent();
        }

        [HttpGet("check-stock")]
        public async Task<IActionResult> CheckStock()
        {
            var stockStatus = await _inventoryService.CheckStockAsync();
            return Ok(stockStatus);
        }
    }

}
