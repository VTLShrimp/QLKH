using System.ComponentModel.DataAnnotations;

namespace QLKhoHang.Entities
{
    public class SupplierModel
    {
        [Key]
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ContactInfo { get; set; }

        public ICollection<ImportScheduleModel> ImportSchedules { get; set; }
    }

}
