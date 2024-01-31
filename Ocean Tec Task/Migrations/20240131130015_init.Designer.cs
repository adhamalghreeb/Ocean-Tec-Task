﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ocean_Tec_Task;

#nullable disable

namespace Ocean_Tec_Task.Migrations
{
    [DbContext(typeof(dbContextClass))]
    [Migration("20240131130015_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ocean_Tec_Task.Models.Bill", b =>
                {
                    b.Property<Guid>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BillingDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BillId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("Ocean_Tec_Task.Models.Characteristics", b =>
                {
                    b.Property<Guid>("CharacteristicsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("LastPurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MaximumLimit")
                        .HasColumnType("int");

                    b.Property<int>("MinimumLimit")
                        .HasColumnType("int");

                    b.Property<int>("OrderLimit")
                        .HasColumnType("int");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CharacteristicsId");

                    b.ToTable("Characteristics");
                });

            modelBuilder.Entity("Ocean_Tec_Task.Models.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Ocean_Tec_Task.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductId");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MainUnitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MediumUnitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameArabic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEnglish")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SmallUnitId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MainUnitId");

                    b.HasIndex("MediumUnitId");

                    b.HasIndex("SmallUnitId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Ocean_Tec_Task.Models.Unit", b =>
                {
                    b.Property<Guid>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CharacteristicsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ConsumerPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("HalfWholesalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UnitSelection")
                        .HasColumnType("int");

                    b.Property<decimal>("WholesalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("UnitId");

                    b.HasIndex("CharacteristicsId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Ocean_Tec_Task.Models.Bill", b =>
                {
                    b.HasOne("Ocean_Tec_Task.Models.Order", "Order")
                        .WithOne("Bill")
                        .HasForeignKey("Ocean_Tec_Task.Models.Bill", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Ocean_Tec_Task.Models.Order", b =>
                {
                    b.HasOne("Ocean_Tec_Task.Models.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ocean_Tec_Task.Models.Product", b =>
                {
                    b.HasOne("Ocean_Tec_Task.Models.Unit", "MainUnit")
                        .WithMany()
                        .HasForeignKey("MainUnitId");

                    b.HasOne("Ocean_Tec_Task.Models.Unit", "MediumUnit")
                        .WithMany()
                        .HasForeignKey("MediumUnitId");

                    b.HasOne("Ocean_Tec_Task.Models.Unit", "SmallUnit")
                        .WithMany()
                        .HasForeignKey("SmallUnitId");

                    b.Navigation("MainUnit");

                    b.Navigation("MediumUnit");

                    b.Navigation("SmallUnit");
                });

            modelBuilder.Entity("Ocean_Tec_Task.Models.Unit", b =>
                {
                    b.HasOne("Ocean_Tec_Task.Models.Characteristics", "Characteristics")
                        .WithMany()
                        .HasForeignKey("CharacteristicsId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Characteristics");
                });

            modelBuilder.Entity("Ocean_Tec_Task.Models.Order", b =>
                {
                    b.Navigation("Bill")
                        .IsRequired();
                });

            modelBuilder.Entity("Ocean_Tec_Task.Models.Product", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}