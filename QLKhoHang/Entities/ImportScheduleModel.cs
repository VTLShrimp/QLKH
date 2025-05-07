using System.ComponentModel.DataAnnotations;

namespace QLKhoHang.Entities
{
    public class ImportScheduleModel
    {
        [Key]
        public int ScheduleID { get; set; }

        public int ProductID { get; set; }
        public ProductModel Product { get; set; }

        public int SupplierID { get; set; }
        public SupplierModel Supplier { get; set; }

        public DateTime ExpectedDate { get; set; }
        public int Quantity { get; set; }

        public string Status { get; set; }
    }

}
