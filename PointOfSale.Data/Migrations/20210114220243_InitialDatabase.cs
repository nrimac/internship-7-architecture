using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Data.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DailyRates = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OneOffBills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Profit = table.Column<int>(type: "int", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneOffBills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceOfArticle = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceBills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Profit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceBills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourlyRates = table.Column<int>(type: "int", nullable: false),
                    NumberOfWorkersNeeded = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionBills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerOib = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionBills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    PriceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Prices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oib = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DailyWorkHours = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workers_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullProfit = table.Column<int>(type: "int", nullable: false),
                    OneOffBillId = table.Column<int>(type: "int", nullable: true),
                    SubscriptionBillId = table.Column<int>(type: "int", nullable: true),
                    ServiceBillId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_OneOffBills_OneOffBillId",
                        column: x => x.OneOffBillId,
                        principalTable: "OneOffBills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_ServiceBills_ServiceBillId",
                        column: x => x.ServiceBillId,
                        principalTable: "ServiceBills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_SubscriptionBills_SubscriptionBillId",
                        column: x => x.SubscriptionBillId,
                        principalTable: "SubscriptionBills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountSold = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    LeaseId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_Leases_LeaseId",
                        column: x => x.LeaseId,
                        principalTable: "Leases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryOffers_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryOffers_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Elektrotehnika" });

            migrationBuilder.InsertData(
                table: "Leases",
                columns: new[] { "Id", "DailyRates", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, 100, false, "Kombi-BMW" },
                    { 2, 50, false, "PC" },
                    { 3, 30, false, "PlayStation 4" },
                    { 4, 70, false, "Motor-Piaggio" }
                });

            migrationBuilder.InsertData(
                table: "OneOffBills",
                columns: new[] { "Id", "DateOfIssue", "Profit" },
                values: new object[] { 1, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 400 });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "PriceOfArticle" },
                values: new object[,]
                {
                    { 4, 30 },
                    { 3, 200 },
                    { 5, 1500 },
                    { 1, 400 },
                    { 2, 700 }
                });

            migrationBuilder.InsertData(
                table: "ServiceBills",
                columns: new[] { "Id", "Profit" },
                values: new object[] { 1, 40 });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "HourlyRates", "Name", "NumberOfWorkersNeeded" },
                values: new object[,]
                {
                    { 1, 20, "Instalacija interneta", 1 },
                    { 2, 30, "Instalacija klime", 2 },
                    { 3, 40, "Bojanje zida", 1 }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionBills",
                columns: new[] { "Id", "BuyerFirstName", "BuyerLastName", "BuyerOib", "Profit" },
                values: new object[] { 1, "Niko", "Nikić", "31232543", 200 });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "DailyWorkHours", "FirstName", "IsAvailable", "LastName", "Oib", "ServiceId" },
                values: new object[,]
                {
                    { 4, 8, "Toni", true, "Toničević", "65436345", null },
                    { 1, 8, "Mate", true, "Matić", "3123131231", null },
                    { 2, 8, "Šime", true, "Šimić", "4324232", null },
                    { 3, 8, "Ivan", true, "Ivanović", "543645454", null },
                    { 5, 8, "Mate", true, "Matić", "3123131231", null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Count", "Name", "PriceId" },
                values: new object[,]
                {
                    { 5, 54, "Karte", 4 },
                    { 1, 2, "Pila", 1 },
                    { 2, 5, "Vrata", 2 },
                    { 3, 12, "Kutija", 3 },
                    { 4, 43, "Lampa", 3 },
                    { 7, 7, "Monitor-LG 27000", 5 },
                    { 6, 30, "Kamera-Nikon D350 DSLR", 5 }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "ArticleId", "CountSold", "LeaseId", "OrderId", "ServiceId" },
                values: new object[,]
                {
                    { 10, null, 0, null, null, 3 },
                    { 9, null, 0, null, null, 2 },
                    { 8, null, 1, null, null, 1 },
                    { 11, null, 0, 1, null, null },
                    { 14, null, 0, 4, null, null },
                    { 13, null, 0, 3, null, null },
                    { 12, null, 0, 2, null, null }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "FullProfit", "OneOffBillId", "ServiceBillId", "SubscriptionBillId" },
                values: new object[,]
                {
                    { 1, 440, 1, 1, null },
                    { 2, 200, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "DailyWorkHours", "FirstName", "IsAvailable", "LastName", "Oib", "ServiceId" },
                values: new object[] { 6, 8, "Ana", false, "Anić", "4564635465", 1 });

            migrationBuilder.InsertData(
                table: "CategoryOffers",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[,]
                {
                    { 6, 1, 12 },
                    { 7, 1, 13 },
                    { 4, 1, 8 },
                    { 5, 1, 9 }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "ArticleId", "CountSold", "LeaseId", "OrderId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1, 1, null, null, null },
                    { 2, 2, 0, null, null, null },
                    { 3, 3, 0, null, null, null },
                    { 4, 4, 0, null, null, null },
                    { 5, 5, 0, null, null, null },
                    { 6, 6, 0, null, null, null },
                    { 7, 7, 0, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "CategoryOffers",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 1, 1, 4 });

            migrationBuilder.InsertData(
                table: "CategoryOffers",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 2, 1, 6 });

            migrationBuilder.InsertData(
                table: "CategoryOffers",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[] { 3, 1, 7 });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_PriceId",
                table: "Articles",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryOffers_CategoryId",
                table: "CategoryOffers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryOffers_OfferId",
                table: "CategoryOffers",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ArticleId",
                table: "Offers",
                column: "ArticleId",
                unique: true,
                filter: "[ArticleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_LeaseId",
                table: "Offers",
                column: "LeaseId",
                unique: true,
                filter: "[LeaseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_OrderId",
                table: "Offers",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ServiceId",
                table: "Offers",
                column: "ServiceId",
                unique: true,
                filter: "[ServiceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OneOffBillId",
                table: "Orders",
                column: "OneOffBillId",
                unique: true,
                filter: "[OneOffBillId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServiceBillId",
                table: "Orders",
                column: "ServiceBillId",
                unique: true,
                filter: "[ServiceBillId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SubscriptionBillId",
                table: "Orders",
                column: "SubscriptionBillId",
                unique: true,
                filter: "[SubscriptionBillId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_ServiceId",
                table: "Workers",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryOffers");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Leases");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "OneOffBills");

            migrationBuilder.DropTable(
                name: "ServiceBills");

            migrationBuilder.DropTable(
                name: "SubscriptionBills");
        }
    }
}
