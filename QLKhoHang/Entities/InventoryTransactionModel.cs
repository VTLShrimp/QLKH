using System.ComponentModel.DataAnnotations;

namespace QLKhoHang.Entities
{
    public class InventoryTransactionModel
    {
        [Key]
        public int TransactionID { get; set; }

        public int ProductID { get; set; }
        public ProductModel Product { get; set; }

        public int WarehouseID { get; set; }
        public WarehouseModel Warehouse { get; set; }

        public int UserID { get; set; }
        public int Quantity { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Note { get; set; }
    }

}
