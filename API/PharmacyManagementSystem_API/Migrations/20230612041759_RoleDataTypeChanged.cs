using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PharmacyManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class RoleDataTypeChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: new Guid("59102313-de80-402b-b2c9-d86222e5af73"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: new Guid("d92db78d-816f-4219-aea1-4aaf1f1eb041"));

            migrationBuilder.DeleteData(
                table: "PickedUpOrders",
                keyColumn: "PickedUpOrderId",
                keyValue: new Guid("103ffe32-bb22-4c88-a689-2d4d1d12d412"));

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "DrugId",
                keyValue: new Guid("25778d4c-c364-4cf2-8ae7-38cb494eff2b"),
                column: "ExpiryDate",
                value: new DateTime(2024, 8, 12, 9, 47, 58, 562, DateTimeKind.Local).AddTicks(5805));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "DrugId",
                keyValue: new Guid("6119868f-6d63-4346-b637-7d4058a734bf"),
                column: "ExpiryDate",
                value: new DateTime(2024, 6, 12, 9, 47, 58, 562, DateTimeKind.Local).AddTicks(5776));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "DrugId",
                keyValue: new Guid("8a49f061-c88e-408c-947c-3fb24351d304"),
                column: "ExpiryDate",
                value: new DateTime(2025, 12, 12, 9, 47, 58, 562, DateTimeKind.Local).AddTicks(5814));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "DrugId",
                keyValue: new Guid("97981659-2052-4c72-b307-d7db41fed780"),
                column: "ExpiryDate",
                value: new DateTime(2025, 2, 12, 9, 47, 58, 562, DateTimeKind.Local).AddTicks(5808));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "DrugId",
                keyValue: new Guid("d48cf152-6cca-481a-b28e-970b5491f0f2"),
                column: "ExpiryDate",
                value: new DateTime(2024, 2, 12, 9, 47, 58, 562, DateTimeKind.Local).AddTicks(5812));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3d8cd2b2-1fa1-46da-9ced-0d1df92db769"),
                column: "OrderDate",
                value: new DateTime(2023, 6, 12, 9, 47, 58, 562, DateTimeKind.Local).AddTicks(5853));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("717e33d3-91aa-4417-b64b-bf104d059635"),
                column: "OrderDate",
                value: new DateTime(2023, 6, 12, 9, 47, 58, 562, DateTimeKind.Local).AddTicks(5861));

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "Method", "OrderId" },
                values: new object[,]
                {
                    { new Guid("0d67ce93-2c40-45ac-bd2e-cd98a832c63c"), 102m, 0, new Guid("3d8cd2b2-1fa1-46da-9ced-0d1df92db769") },
                    { new Guid("3e430ae7-e43c-493a-af28-3cc42133c931"), 190m, 2, new Guid("717e33d3-91aa-4417-b64b-bf104d059635") }
                });

            migrationBuilder.InsertData(
                table: "PickedUpOrders",
                columns: new[] { "PickedUpOrderId", "OrderId", "PickedUpDate" },
                values: new object[] { new Guid("b9bfbf74-4aac-44c2-8db8-c3ff258ed088"), new Guid("717e33d3-91aa-4417-b64b-bf104d059635"), new DateTime(2023, 6, 12, 9, 47, 58, 562, DateTimeKind.Local).AddTicks(5936) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("9613f220-2650-4f63-bbb6-13ff6de4f0f6"),
                column: "Role",
                value: "Doctor");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("ec596f12-b18e-4284-a9b6-16f6da9dbb42"),
                column: "Role",
                value: "Admin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: new Guid("0d67ce93-2c40-45ac-bd2e-cd98a832c63c"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: new Guid("3e430ae7-e43c-493a-af28-3cc42133c931"));

            migrationBuilder.DeleteData(
                table: "PickedUpOrders",
                keyColumn: "PickedUpOrderId",
                keyValue: new Guid("b9bfbf74-4aac-44c2-8db8-c3ff258ed088"));

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "DrugId",
                keyValue: new Guid("25778d4c-c364-4cf2-8ae7-38cb494eff2b"),
                column: "ExpiryDate",
                value: new DateTime(2024, 8, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(675));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "DrugId",
                keyValue: new Guid("6119868f-6d63-4346-b637-7d4058a734bf"),
                column: "ExpiryDate",
                value: new DateTime(2024, 6, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(649));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "DrugId",
                keyValue: new Guid("8a49f061-c88e-408c-947c-3fb24351d304"),
                column: "ExpiryDate",
                value: new DateTime(2025, 12, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(685));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "DrugId",
                keyValue: new Guid("97981659-2052-4c72-b307-d7db41fed780"),
                column: "ExpiryDate",
                value: new DateTime(2025, 2, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(679));

            migrationBuilder.UpdateData(
                table: "Drugs",
                keyColumn: "DrugId",
                keyValue: new Guid("d48cf152-6cca-481a-b28e-970b5491f0f2"),
                column: "ExpiryDate",
                value: new DateTime(2024, 2, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(682));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3d8cd2b2-1fa1-46da-9ced-0d1df92db769"),
                column: "OrderDate",
                value: new DateTime(2023, 6, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(713));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("717e33d3-91aa-4417-b64b-bf104d059635"),
                column: "OrderDate",
                value: new DateTime(2023, 6, 5, 17, 0, 4, 502, DateTimeKind.Local).AddTicks(720));

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("9613f220-2650-4f63-bbb6-13ff6de4f0f6"),
                column: "Role",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("ec596f12-b18e-4284-a9b6-16f6da9dbb42"),
                column: "Role",
                value: 0);
        }
    }
}
