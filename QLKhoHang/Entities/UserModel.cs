using Microsoft.AspNetCore.Identity;

namespace QLKhoHang.Entities
{
    public class UserModel : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public DateTime? DateOfBirth { get; set; }

        // Bạn có thể thêm quan hệ đến các bảng khác nếu cần
        public ICollection<InventoryTransactionModel> InventoryTransactions { get; set; }
        public ICollection<FinancialReportModel> FinancialReports { get; set; }
    }
}
