using Microsoft.EntityFrameworkCore;
using Ocean_Tec_Task.Configurations;
using Ocean_Tec_Task.Models;

namespace Ocean_Tec_Task
{
    public class dbContextClass : DbContext
    {
        public dbContextClass(DbContextOptions<dbContextClass> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Characteristics> Characteristics { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<Bill> Bills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
            .HasOne(p => p.MainUnit)
            .WithMany()
            .HasForeignKey(p => p.MainUnitId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.MediumUnit)
                .WithMany()
                .HasForeignKey(p => p.MediumUnitId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.SmallUnit)
                .WithMany()
                .HasForeignKey(p => p.SmallUnitId);

            modelBuilder.Entity<Unit>()
            .HasOne(u => u.Characteristics)
            .WithMany()
            .HasForeignKey(u => u.CharacteristicsId)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Order>()
            .HasOne(o => o.Product)
            .WithMany(p => p.Orders)
            .HasForeignKey(o => o.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bill>()
                .HasOne(b => b.Order)
                .WithOne(o => o.Bill)
                .HasForeignKey<Bill>(b => b.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        
    }
}
