using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PharmacyManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    DrugId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrugName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.DrugId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "DrugSupplier",
                columns: table => new
                {
                    DrugsDrugId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SuppliersSupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugSupplier", x => new { x.DrugsDrugId, x.SuppliersSupplierId });
                    table.ForeignKey(
                        name: "FK_DrugSupplier_Drugs_DrugsDrugId",
                        column: x => x.DrugsDrugId,
                        principalTable: "Drugs",
                        principalColumn: "DrugId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugSupplier_Suppliers_SuppliersSupplierId",
                        column: x => x.SuppliersSupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrugId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "DrugId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PickedUpOrders",
                columns: table => new
                {
                    PickedUpOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PickedUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickedUpOrders", x => x.PickedUpOrderId);
                    table.ForeignKey(
                        name: "FK_PickedUpOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "DrugId", "DrugName", "ExpiryDate", "ImageUrl", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("25778d4c-c364-4cf2-8ae7-38cb494eff2b"), "Amoxicillin", new DateTime(2024, 8, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(675), "", 8.5m, 100 },
                    { new Guid("6119868f-6d63-4346-b637-7d4058a734bf"), "Azithromycin", new DateTime(2024, 6, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(649), "", 10.2m, 200 },
                    { new Guid("8a49f061-c88e-408c-947c-3fb24351d304"), "Diclofenac", new DateTime(2025, 12, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(685), "", 9.5m, 180 },
                    { new Guid("97981659-2052-4c72-b307-d7db41fed780"), "Cetirizine", new DateTime(2025, 2, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(679), "", 5.5m, 280 },
                    { new Guid("d48cf152-6cca-481a-b28e-970b5491f0f2"), "Detrol", new DateTime(2024, 2, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(682), "", 12.5m, 50 }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "ContactNumber", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("0495808a-aca5-4ca1-a431-6c4fcc150e01"), "8765545765", "ehpharma@gmail.com", "Euphoria Healthcare Private Limited" },
                    { new Guid("bf2a7b49-3b04-40b6-9d66-4b553cac184c"), "9826287851", "dvpharma@gmail.com", "D Vijay Pharma Pvt. Ltd. " },
                    { new Guid("c140372d-a6de-4738-b40a-e1160d81774a"), "9485658458", "mdpharma@gmail.com", "Meher Distributors Pvt. Ltd." },
                    { new Guid("f70ac1c8-2bd7-4c86-a111-68472643b0b6"), "8582583454", "gajapharma@gmail.com", "Gaia Pharmaceutical Trade" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FullName", "Gender", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { new Guid("9613f220-2650-4f63-bbb6-13ff6de4f0f6"), "pavanisri24@gmail.com", "Pavani Sri", 1, "8756847568", 1 },
                    { new Guid("ec596f12-b18e-4284-a9b6-16f6da9dbb42"), "sreeram12@gmail.com", "Sree Ram", 0, "7658734658", 0 }
                });

            migrationBuilder.InsertData(
                table: "DrugSupplier",
                columns: new[] { "DrugsDrugId", "SuppliersSupplierId" },
                values: new object[,]
                {
                    { new Guid("25778d4c-c364-4cf2-8ae7-38cb494eff2b"), new Guid("bf2a7b49-3b04-40b6-9d66-4b553cac184c") },
                    { new Guid("25778d4c-c364-4cf2-8ae7-38cb494eff2b"), new Guid("c140372d-a6de-4738-b40a-e1160d81774a") },
                    { new Guid("6119868f-6d63-4346-b637-7d4058a734bf"), new Guid("bf2a7b49-3b04-40b6-9d66-4b553cac184c") },
                    { new Guid("6119868f-6d63-4346-b637-7d4058a734bf"), new Guid("f70ac1c8-2bd7-4c86-a111-68472643b0b6") },
                    { new Guid("8a49f061-c88e-408c-947c-3fb24351d304"), new Guid("0495808a-aca5-4ca1-a431-6c4fcc150e01") },
                    { new Guid("8a49f061-c88e-408c-947c-3fb24351d304"), new Guid("bf2a7b49-3b04-40b6-9d66-4b553cac184c") },
                    { new Guid("8a49f061-c88e-408c-947c-3fb24351d304"), new Guid("c140372d-a6de-4738-b40a-e1160d81774a") },
                    { new Guid("8a49f061-c88e-408c-947c-3fb24351d304"), new Guid("f70ac1c8-2bd7-4c86-a111-68472643b0b6") },
                    { new Guid("97981659-2052-4c72-b307-d7db41fed780"), new Guid("0495808a-aca5-4ca1-a431-6c4fcc150e01") },
                    { new Guid("d48cf152-6cca-481a-b28e-970b5491f0f2"), new Guid("0495808a-aca5-4ca1-a431-6c4fcc150e01") },
                    { new Guid("d48cf152-6cca-481a-b28e-970b5491f0f2"), new Guid("c140372d-a6de-4738-b40a-e1160d81774a") }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "DrugId", "OrderDate", "Quantity", "Status", "UserId" },
                values: new object[,]
                {
                    { new Guid("3d8cd2b2-1fa1-46da-9ced-0d1df92db769"), new Guid("6119868f-6d63-4346-b637-7d4058a734bf"), new DateTime(2023, 6, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(713), 10, 0, new Guid("9613f220-2650-4f63-bbb6-13ff6de4f0f6") },
                    { new Guid("717e33d3-91aa-4417-b64b-bf104d059635"), new Guid("8a49f061-c88e-408c-947c-3fb24351d304"), new DateTime(2023, 6, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(720), 20, 2, new Guid("9613f220-2650-4f63-bbb6-13ff6de4f0f6") }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "Method", "OrderId" },
                values: new object[,]
                {
                    { new Guid("59102313-de80-402b-b2c9-d86222e5af73"), 102m, 0, new Guid("3d8cd2b2-1fa1-46da-9ced-0d1df92db769") },
                    { new Guid("d92db78d-816f-4219-aea1-4aaf1f1eb041"), 190m, 2, new Guid("717e33d3-91aa-4417-b64b-bf104d059635") }
                });

            migrationBuilder.InsertData(
                table: "PickedUpOrders",
                columns: new[] { "PickedUpOrderId", "OrderId", "PickedUpDate" },
                values: new object[] { new Guid("103ffe32-bb22-4c88-a689-2d4d1d12d412"), new Guid("717e33d3-91aa-4417-b64b-bf104d059635"), new DateTime(2023, 6, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(779) });

            migrationBuilder.CreateIndex(
                name: "IX_DrugSupplier_SuppliersSupplierId",
                table: "DrugSupplier",
                column: "SuppliersSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DrugId",
                table: "Orders",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PickedUpOrders_OrderId",
                table: "PickedUpOrders",
                column: "OrderId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugSupplier");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PickedUpOrders");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
