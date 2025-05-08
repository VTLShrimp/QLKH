using Microsoft.AspNetCore.Mvc;

namespace QLKhoHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScanController : ControllerBase
    {
        private readonly IBarcodeService _barcodeService;

        public ScanController(IBarcodeService barcodeService)
        {
            _barcodeService = barcodeService;
        }

        [HttpPost("scan")]
        public async Task<IActionResult> ScanBarcode([FromBody] ScanBarcodeModel scanData)
        {
            var result = await _barcodeService.ProcessBarcodeScanAsync(scanData);
            if (result)
            {
                return Ok("Barcode scanned and inventory updated.");
            }
            return BadRequest("Failed to process barcode.");
        }

        [HttpPost("scan-rfid")]
        public async Task<IActionResult> ScanRFID([FromBody] ScanRFIDModel scanData)
        {
            var result = await _barcodeService.ProcessRFIDScanAsync(scanData);
            if (result)
            {
                return Ok("RFID scanned and inventory updated.");
            }
            return BadRequest("Failed to process RFID.");
        }
    }

}
