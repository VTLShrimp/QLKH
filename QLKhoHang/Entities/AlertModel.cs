using System.ComponentModel.DataAnnotations;

namespace QLKhoHang.Entities
{
    public class AlertModel
    {
        [Key]
        public int AlertId { get; set; }    

        public int ProductID { get; set; }
        public ProductModel Product { get; set; }

        public string AlertType { get; set; }
        public DateTime AlertTime { get; set; }
        public bool Resolved { get; set; }
    }

}
