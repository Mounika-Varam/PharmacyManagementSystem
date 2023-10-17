﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PharmacyManagementSystem.API.Models.Domain;

#nullable disable

namespace PharmacyManagementSystem.API.Migrations
{
    [DbContext(typeof(PharmacyManagementDbContext))]
    [Migration("20230605113004_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DrugSupplier", b =>
                {
                    b.Property<Guid>("DrugsDrugId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SuppliersSupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DrugsDrugId", "SuppliersSupplierId");

                    b.HasIndex("SuppliersSupplierId");

                    b.ToTable("DrugSupplier", (string)null);

                    b.HasData(
                        new
                        {
                            DrugsDrugId = new Guid("6119868f-6d63-4346-b637-7d4058a734bf"),
                            SuppliersSupplierId = new Guid("bf2a7b49-3b04-40b6-9d66-4b553cac184c")
                        },
                        new
                        {
                            DrugsDrugId = new Guid("6119868f-6d63-4346-b637-7d4058a734bf"),
                            SuppliersSupplierId = new Guid("f70ac1c8-2bd7-4c86-a111-68472643b0b6")
                        },
                        new
                        {
                            DrugsDrugId = new Guid("25778d4c-c364-4cf2-8ae7-38cb494eff2b"),
                            SuppliersSupplierId = new Guid("bf2a7b49-3b04-40b6-9d66-4b553cac184c")
                        },
                        new
                        {
                            DrugsDrugId = new Guid("25778d4c-c364-4cf2-8ae7-38cb494eff2b"),
                            SuppliersSupplierId = new Guid("c140372d-a6de-4738-b40a-e1160d81774a")
                        },
                        new
                        {
                            DrugsDrugId = new Guid("97981659-2052-4c72-b307-d7db41fed780"),
                            SuppliersSupplierId = new Guid("0495808a-aca5-4ca1-a431-6c4fcc150e01")
                        },
                        new
                        {
                            DrugsDrugId = new Guid("d48cf152-6cca-481a-b28e-970b5491f0f2"),
                            SuppliersSupplierId = new Guid("c140372d-a6de-4738-b40a-e1160d81774a")
                        },
                        new
                        {
                            DrugsDrugId = new Guid("d48cf152-6cca-481a-b28e-970b5491f0f2"),
                            SuppliersSupplierId = new Guid("0495808a-aca5-4ca1-a431-6c4fcc150e01")
                        },
                        new
                        {
                            DrugsDrugId = new Guid("8a49f061-c88e-408c-947c-3fb24351d304"),
                            SuppliersSupplierId = new Guid("bf2a7b49-3b04-40b6-9d66-4b553cac184c")
                        },
                        new
                        {
                            DrugsDrugId = new Guid("8a49f061-c88e-408c-947c-3fb24351d304"),
                            SuppliersSupplierId = new Guid("f70ac1c8-2bd7-4c86-a111-68472643b0b6")
                        },
                        new
                        {
                            DrugsDrugId = new Guid("8a49f061-c88e-408c-947c-3fb24351d304"),
                            SuppliersSupplierId = new Guid("c140372d-a6de-4738-b40a-e1160d81774a")
                        },
                        new
                        {
                            DrugsDrugId = new Guid("8a49f061-c88e-408c-947c-3fb24351d304"),
                            SuppliersSupplierId = new Guid("0495808a-aca5-4ca1-a431-6c4fcc150e01")
                        });
                });

            modelBuilder.Entity("PharmacyManagementSystem.API.Models.Domain.Drug", b =>
                {
                    b.Property<Guid>("DrugId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DrugName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("DrugId");

                    b.ToTable("Drugs");

                    b.HasData(
                        new
                        {
                            DrugId = new Guid("6119868f-6d63-4346-b637-7d4058a734bf"),
                            DrugName = "Azithromycin",
                            ExpiryDate = new DateTime(2024, 6, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(649),
                            ImageUrl = "",
                            Price = 10.2m,
                            Quantity = 200
                        },
                        new
                        {
                            DrugId = new Guid("25778d4c-c364-4cf2-8ae7-38cb494eff2b"),
                            DrugName = "Amoxicillin",
                            ExpiryDate = new DateTime(2024, 8, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(675),
                            ImageUrl = "",
                            Price = 8.5m,
                            Quantity = 100
                        },
                        new
                        {
                            DrugId = new Guid("97981659-2052-4c72-b307-d7db41fed780"),
                            DrugName = "Cetirizine",
                            ExpiryDate = new DateTime(2025, 2, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(679),
                            ImageUrl = "",
                            Price = 5.5m,
                            Quantity = 280
                        },
                        new
                        {
                            DrugId = new Guid("d48cf152-6cca-481a-b28e-970b5491f0f2"),
                            DrugName = "Detrol",
                            ExpiryDate = new DateTime(2024, 2, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(682),
                            ImageUrl = "",
                            Price = 12.5m,
                            Quantity = 50
                        },
                        new
                        {
                            DrugId = new Guid("8a49f061-c88e-408c-947c-3fb24351d304"),
                            DrugName = "Diclofenac",
                            ExpiryDate = new DateTime(2025, 12, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(685),
                            ImageUrl = "",
                            Price = 9.5m,
                            Quantity = 180
                        });
                });

            modelBuilder.Entity("PharmacyManagementSystem.API.Models.Domain.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DrugId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OrderId");

                    b.HasIndex("DrugId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = new Guid("3d8cd2b2-1fa1-46da-9ced-0d1df92db769"),
                            DrugId = new Guid("6119868f-6d63-4346-b637-7d4058a734bf"),
                            OrderDate = new DateTime(2023, 6, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(713),
                            Quantity = 10,
                            Status = 0,
                            UserId = new Guid("9613f220-2650-4f63-bbb6-13ff6de4f0f6")
                        },
                        new
                        {
                            OrderId = new Guid("717e33d3-91aa-4417-b64b-bf104d059635"),
                            DrugId = new Guid("8a49f061-c88e-408c-947c-3fb24351d304"),
                            OrderDate = new DateTime(2023, 6, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(720),
                            Quantity = 20,
                            Status = 2,
                            UserId = new Guid("9613f220-2650-4f63-bbb6-13ff6de4f0f6")
                        });
                });

            modelBuilder.Entity("PharmacyManagementSystem.API.Models.Domain.Payment", b =>
                {
                    b.Property<Guid>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Method")
                        .HasColumnType("int");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PaymentId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            PaymentId = new Guid("59102313-de80-402b-b2c9-d86222e5af73"),
                            Amount = 102m,
                            Method = 0,
                            OrderId = new Guid("3d8cd2b2-1fa1-46da-9ced-0d1df92db769")
                        },
                        new
                        {
                            PaymentId = new Guid("d92db78d-816f-4219-aea1-4aaf1f1eb041"),
                            Amount = 190m,
                            Method = 2,
                            OrderId = new Guid("717e33d3-91aa-4417-b64b-bf104d059635")
                        });
                });

            modelBuilder.Entity("PharmacyManagementSystem.API.Models.Domain.PickedUpOrder", b =>
                {
                    b.Property<Guid>("PickedUpOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PickedUpDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PickedUpOrderId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("PickedUpOrders");

                    b.HasData(
                        new
                        {
                            PickedUpOrderId = new Guid("103ffe32-bb22-4c88-a689-2d4d1d12d412"),
                            OrderId = new Guid("717e33d3-91aa-4417-b64b-bf104d059635"),
                            PickedUpDate = new DateTime(2023, 6, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(779)
                        });
                });

            modelBuilder.Entity("PharmacyManagementSystem.API.Models.Domain.Supplier", b =>
                {
                    b.Property<Guid>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            SupplierId = new Guid("bf2a7b49-3b04-40b6-9d66-4b553cac184c"),
                            ContactNumber = "9826287851",
                            Email = "dvpharma@gmail.com",
                            Name = "D Vijay Pharma Pvt. Ltd. "
                        },
                        new
                        {
                            SupplierId = new Guid("f70ac1c8-2bd7-4c86-a111-68472643b0b6"),
                            ContactNumber = "8582583454",
                            Email = "gajapharma@gmail.com",
                            Name = "Gaia Pharmaceutical Trade"
                        },
                        new
                        {
                            SupplierId = new Guid("c140372d-a6de-4738-b40a-e1160d81774a"),
                            ContactNumber = "9485658458",
                            Email = "mdpharma@gmail.com",
                            Name = "Meher Distributors Pvt. Ltd."
                        },
                        new
                        {
                            SupplierId = new Guid("0495808a-aca5-4ca1-a431-6c4fcc150e01"),
                            ContactNumber = "8765545765",
                            Email = "ehpharma@gmail.com",
                            Name = "Euphoria Healthcare Private Limited"
                        });
                });

            modelBuilder.Entity("PharmacyManagementSystem.API.Models.Domain.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("ec596f12-b18e-4284-a9b6-16f6da9dbb42"),
                            Email = "sreeram12@gmail.com",
                            FullName = "Sree Ram",
                            Gender = 0,
                            PhoneNumber = "7658734658",
                            Role = 0
                        },
                        new
                        {
                            UserId = new Guid("9613f220-2650-4f63-bbb6-13ff6de4f0f6"),
                            Email = "pavanisri24@gmail.com",
                            FullName = "Pavani Sri",
                            Gender = 1,
                            PhoneNumber = "8756847568",
                            Role = 1
                        });
                });

            modelBuilder.Entity("DrugSupplier", b =>
                {
                    b.HasOne("PharmacyManagementSystem.API.Models.Domain.Drug", null)
                        .WithMany()
                        .HasForeignKey("DrugsDrugId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyManagementSystem.API.Models.Domain.Supplier", null)
                        .WithMany()
                        .HasForeignKey("SuppliersSupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PharmacyManagementSystem.API.Models.Domain.Order", b =>
                {
                    b.HasOne("PharmacyManagementSystem.API.Models.Domain.Drug", "Drug")
                        .WithMany("Orders")
                        .HasForeignKey("DrugId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyManagementSystem.API.Models.Domain.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drug");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PharmacyManagementSystem.API.Models.Domain.Payment", b =>
                {
                    b.HasOne("PharmacyManagementSystem.API.Models.Domain.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("PharmacyManagementSystem.API.Models.Domain.Payment", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("PharmacyManagementSystem.API.Models.Domain.PickedUpOrder", b =>
                {
                    b.HasOne("PharmacyManagementSystem.API.Models.Domain.Order", "Order")
                        .WithOne("PickedUpOrder")
                        .HasForeignKey("PharmacyManagementSystem.API.Models.Domain.PickedUpOrder", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("PharmacyManagementSystem.API.Models.Domain.Drug", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PharmacyManagementSystem.API.Models.Domain.Order", b =>
                {
                    b.Navigation("Payment")
                        .IsRequired();

                    b.Navigation("PickedUpOrder")
                        .IsRequired();
                });

            modelBuilder.Entity("PharmacyManagementSystem.API.Models.Domain.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
