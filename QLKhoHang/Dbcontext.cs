using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QLKhoHang.Entities;

namespace QLKhoHang.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<ProductModel> Products { get; set; }
        public DbSet<UserModel> Users { get; set; }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<WarehouseModel> Warehouses { get; set; }
        public DbSet<InventoryModel> Inventories { get; set; }
        public DbSet<InventoryTransactionModel> InventoryTransactions { get; set; }
        public DbSet<FinancialReportModel> FinancialReports { get; set; }
        public DbSet<AlertModel> Alerts { get; set; }
        public DbSet<SupplierModel> Suppliers { get; set; }
        public DbSet<ImportScheduleModel> ImportSchedules { get; set; }
    }
}