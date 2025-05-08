using Microsoft.AspNetCore.Mvc;

namespace QLKhoHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseChainController : ControllerBase
    {
        private readonly IWarehouseChainService _warehouseChainService;

        public WarehouseChainController(IWarehouseChainService warehouseChainService)
        {
            _warehouseChainService = warehouseChainService;
        }

        [HttpPost("optimize")]
        public async Task<IActionResult> OptimizeWarehouseChain([FromBody] WarehouseChainOptimizationModel optimization)
        {
            var result = await _warehouseChainService.OptimizeChainAsync(optimization);
            return Ok(result);
        }

        [HttpPost("sync")]
        public async Task<IActionResult> SyncWarehouses([FromBody] SyncWarehouseModel syncData)
        {
            var result = await _warehouseChainService.SyncWarehousesAsync(syncData);
            return Ok(result);
        }
    }

}
