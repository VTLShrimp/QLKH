using System.ComponentModel.DataAnnotations;

namespace QLKhoHang.Entities
{
    public class ProductModel
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Barcode { get; set; }
        public string Unit { get; set; }
        public int MinQuantity { get; set; }
        public int MaxQuantity { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }

        public ICollection<InventoryModel> Inventories { get; set; }
        public ICollection<InventoryTransactionModel> InventoryTransactions { get; set; }
        public ICollection<AlertModel> Alerts { get; set; }
        public ICollection<ImportScheduleModel> ImportSchedules { get; set; }
    }

}
