using System.ComponentModel.DataAnnotations;

namespace QLKhoHang.Entities
{
    public class WarehouseModel
    {
        [Key]
        public int WarehouseID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<InventoryModel> Inventories { get; set; }
        public ICollection<InventoryTransactionModel> InventoryTransactions { get; set; }
    }


}
