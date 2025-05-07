using System.ComponentModel.DataAnnotations;

namespace QLKhoHang.Entities
{
    public class InventoryModel
    {
        [Key]
        public int InventoryID { get; set; }

        public int ProductID { get; set; }
        public ProductModel Product { get; set; }

        public int WarehouseID { get; set; }
        public WarehouseModel Warehouse { get; set; }

        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
    }


}
