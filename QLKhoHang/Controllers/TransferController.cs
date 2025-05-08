using Microsoft.AspNetCore.Mvc;

namespace QLKhoHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTransfer([FromBody] TransferModel transfer)
        {
            if (transfer == null)
            {
                return BadRequest("Invalid transfer data.");
            }

            var createdTransfer = await _transferService.CreateTransferAsync(transfer);
            return CreatedAtAction(nameof(GetTransferHistory), new { id = createdTransfer.Id }, createdTransfer);
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetTransferHistory()
        {
            var history = await _transferService.GetTransferHistoryAsync();
            return Ok(history);
        }
    }

}
