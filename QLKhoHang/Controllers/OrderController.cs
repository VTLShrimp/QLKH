using Microsoft.AspNetCore.Mvc;

namespace QLKhoHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpPost("update-status/{orderId}")]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] OrderStatusUpdateModel statusUpdate)
        {
            var updatedOrder = await _orderService.UpdateOrderStatusAsync(orderId, statusUpdate);
            if (updatedOrder == null)
            {
                return NotFound("Order not found.");
            }
            return Ok(updatedOrder);
        }

        [HttpGet("verify/{orderId}")]
        public async Task<IActionResult> VerifyOrder(int orderId)
        {
            var verifiedOrder = await _orderService.VerifyOrderAsync(orderId);
            if (verifiedOrder == null)
            {
                return NotFound("Order verification failed.");
            }
            return Ok(verifiedOrder);
        }
    }

}
