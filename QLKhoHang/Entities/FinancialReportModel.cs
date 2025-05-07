using System.ComponentModel.DataAnnotations;

namespace QLKhoHang.Entities
{
    public class FinancialReportModel
    {
        [Key]   
        public int ReportID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Revenue { get; set; }
        public decimal CostOfGoods { get; set; }
        public decimal InventoryValue { get; set; }
        public decimal Profit { get; set; }

        public int? CreatedBy { get; set; }
        public UserModel Creator { get; set; }
    }

}
