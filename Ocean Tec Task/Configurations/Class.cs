using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Ocean_Tec_Task.Models;

namespace Ocean_Tec_Task.Configurations
{
    /* public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Seed initial data for products
            builder.HasData(
                new Product
                {
                    ProductId = -2,
                    NameArabic = "شامبو",
                    NameEnglish = "Shampoo",
                    GroupName = "Hair Care",
                    
                    Code = "SH001",
                    MainUnitId = 1, // Assuming you have units with IDs, update accordingly
                    MediumUnitId = 2,
                    SmallUnitId = 3,
                    CharacteristicsId = 1, // Assuming you have characteristics with IDs, update accordingly
                }
                // Add more products as needed
            );
        }
    }

    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.HasData(
                new Unit
                {
                    UnitId = 1,
                    UnitSelection = "Main Unit",
                    ConversionFactor = 1,
                    Barcode = "MAIN_UNIT_BARCODE",
                    WholesalePrice = 10.0m,
                    HalfWholesalePrice = 8.0m,
                    ConsumerPrice = 12.0m
                },
            new Unit
            {
                UnitId = 2,
                UnitSelection = "Medium Unit",
                ConversionFactor = 2,
                Barcode = "MEDIUM_UNIT_BARCODE",
                WholesalePrice = 15.0m,
                HalfWholesalePrice = 12.0m,
                ConsumerPrice = 18.0m
            },
            new Unit
            {
                UnitId = 3,
                UnitSelection = "Small Unit",
                ConversionFactor = 3,
                Barcode = "SMALL_UNIT_BARCODE",
                WholesalePrice = 20.0m,
                HalfWholesalePrice = 16.0m,
                ConsumerPrice = 24.0m
            }
                );
            
        }
    }

    public class CharacteristicsConfiguration : IEntityTypeConfiguration<Characteristics>
    {
        public void Configure(EntityTypeBuilder<Characteristics> builder)
        {
            builder.HasData(
                new Characteristics
                {
                    CharacteristicsId = 1,
                    ExpiryDate = DateTime.Parse("2024-12-31"),
                    OrderLimit = 50,
                    MaximumLimit = 200,
                    MinimumLimit = 20,
                    Tax = 0.1m,
                    LastPurchasePrice = 4.0m
                }
                );
        }

    }

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            
            builder.HasData(
                new Order
                {
                    OrderId = 1,
                    OrderDate = DateTime.Now,
                    ProductId = 1,
                    Quantity = 5,
                    Type = OrderType.BulkPurchase
                }
                
            );
        }
    }

    public class PricingConfiguration : IEntityTypeConfiguration<Pricing>
    {
        public void Configure(EntityTypeBuilder<Pricing> builder)
        {
            
            builder.HasData(
                new Pricing
                {
                    PricingId = 1,
                    ProductId = 1, 
                    OrderType = OrderType.BulkPurchase,
                    Price = 8.0m
                }
                
            );
        }
    }

    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            
            builder.HasData(
                new Bill
                {
                    BillId = 1,
                    OrderId = 1, 
                    BillingDate = DateTime.Now
                }
            
            );
        }
    }  */
}
