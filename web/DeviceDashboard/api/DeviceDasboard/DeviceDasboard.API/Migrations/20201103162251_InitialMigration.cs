using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeviceDasboard.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Readings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    CO2Consumption = table.Column<int>(nullable: false),
                    O2Production = table.Column<int>(nullable: false),
                    DeviceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Readings_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Address" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Gaje Alage 8, Zagreb, Hrvatska" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Kobiljacka 50, Zagreb, Hrvatska" },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "Pete Poljanice 12, Zagreb, Hrvatska" },
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), "Maksimirska 23, Zagreb, Hrvatska" },
                    { new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), "Sesvete 45, Zagreb, Hrvatska" }
                });

            migrationBuilder.InsertData(
                table: "Readings",
                columns: new[] { "Id", "CO2Consumption", "CreatedAt", "DeviceId", "O2Production" },
                values: new object[,]
                {
                    { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), 12, 1603540800000L, new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), 10 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea77a"), 9, 1603454400000L, new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), 2 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea712"), 23, 1603368000000L, new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), 17 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea711"), 19, 1603540800000L, new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), 12 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea722"), 12, 1603371600000L, new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), 5 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea723"), 17, 1603540800000L, new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), 10 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea721"), 18, 1603454400000L, new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), 11 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea733"), 13, 1603368000000L, new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), 7 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea633"), 17, 1603540800000L, new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), 10 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea734"), 13, 1603371600000L, new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), 5 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea743"), 12, 1603540800000L, new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), 7 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea778"), 19, 1603540800000L, new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), 12 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea744"), 9, 1603454400000L, new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), 3 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea754"), 12, 1603540800000L, new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), 7 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7a5"), 11, 1603371600000L, new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), 6 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea655"), 14, 1603540800000L, new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), 8 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7b5"), 5, 1603454400000L, new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), 1 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea76b"), 16, 1603368000000L, new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), 9 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea766"), 14, 1603540800000L, new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), 8 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7b7"), 11, 1603371600000L, new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), 6 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7a6"), 12, 1603540800000L, new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), 10 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea737"), 10, 1603454400000L, new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), 4 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7d4"), 15, 1603368000000L, new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), 8 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea745"), 14, 1603368000000L, new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), 6 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea777"), 14, 1603371600000L, new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Readings_DeviceId",
                table: "Readings",
                column: "DeviceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Readings");

            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}
