using Microsoft.AspNetCore.Mvc;
using QLKhoHang.Entities;

namespace QLKhoHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceController : ControllerBase
    {
        private readonly IFinanceService _financeService;

        public FinanceController(IFinanceService financeService)
        {
            _financeService = financeService;
        }

        [HttpGet("reports")]
        public async Task<IActionResult> GetFinancialReports()
        {
            var reports = await _financeService.GetReportsAsync();
            return Ok(reports);
        }

        [HttpPost("create-report")]
        public async Task<IActionResult> CreateFinancialReport([FromBody] FinancialReportModel report)
        {
            var createdReport = await _financeService.CreateReportAsync(report);
            return CreatedAtAction(nameof(GetFinancialReports), new { id = createdReport.Id }, createdReport);
        }

        [HttpPost("audit")]
        public async Task<IActionResult> AuditFinancialData([FromBody] AuditModel auditData)
        {
            var result = await _financeService.AuditDataAsync(auditData);
            return Ok(result);
        }
    }

}
