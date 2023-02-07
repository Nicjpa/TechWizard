using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechWizard.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttributeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumOfDifferntProducts = table.Column<int>(type: "int", nullable: false),
                    TotalNumOfProducts = table.Column<int>(type: "int", nullable: false),
                    TotalCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    OnPromotion = table.Column<bool>(type: "bit", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes_AttributeTypes",
                columns: table => new
                {
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    AttributeTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes_AttributeTypes", x => new { x.ProductTypeId, x.AttributeTypeId });
                    table.ForeignKey(
                        name: "FK_ProductTypes_AttributeTypes_AttributeTypes_AttributeTypeId",
                        column: x => x.AttributeTypeId,
                        principalTable: "AttributeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTypes_AttributeTypes_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AmountOfDiffernetItems = table.Column<int>(type: "int", nullable: false),
                    AmountOfAllItems = table.Column<int>(type: "int", nullable: false),
                    TotalCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products_AttributeTypes",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AttributeTypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_AttributeTypes", x => new { x.ProductId, x.AttributeTypeId });
                    table.ForeignKey(
                        name: "FK_Products_AttributeTypes_AttributeTypes_AttributeTypeId",
                        column: x => x.AttributeTypeId,
                        principalTable: "AttributeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_AttributeTypes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Units = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7a7be58a-9eca-403c-8c5d-2d8c2e3bb7ef", "9c4cb918-9be8-41fd-bb7a-40b75aebc037", "Admin", "ADMIN" },
                    { "dd231ff5-5cf5-41f5-ba39-ffbce9aa933f", "89891c77-9ac3-4e52-bf51-a15e012463f1", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "24ab6a6c-14f1-4b49-8964-ecfcbce372a3", 0, "Belgrade", "abccc67e-66f3-42ce-a209-58dfeeb0d1bc", "nicjpa89@gmail.com", false, "Nikola", "Panic", false, null, "NICJPA89@GMAIL.COM", "NICJPA89@GMAIL.COM", "AQAAAAEAACcQAAAAEPf+1qU7UIyj1ZNkVHZ04rndr0OJ6bqaCgOLB7BgSRbHkr/cq6Nt8Fyy90eMSvuDgg==", "+381605605093", false, "bafc6bbc-7be4-48ed-86e4-a0401179b14a", "HadziMelentijeva 53", false, "nicjpa89@gmail.com" });

            migrationBuilder.InsertData(
                table: "AttributeTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Socket" },
                    { 1, "CPU Manufacturer" },
                    { 20, "Size" },
                    { 19, "Color" },
                    { 18, "Power output" },
                    { 16, "Writing speed" },
                    { 15, "SSD format" },
                    { 14, "Buffer" },
                    { 13, "RPM" },
                    { 12, "Latency" },
                    { 17, "Reading speed" },
                    { 10, "GPU Manufacturer" },
                    { 9, "GPU model" },
                    { 8, "Frequency" },
                    { 7, "Amount of threads" },
                    { 6, "Amount of cores" },
                    { 5, "CPU model" },
                    { 4, "Memory type" },
                    { 11, "Capacity" },
                    { 3, "Chipset" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 17, "COOLER MASTER" },
                    { 18, "LC-POWER" },
                    { 19, "FSP" },
                    { 20, "CORSAIR" },
                    { 24, "THERMALTAKE" },
                    { 22, "GAINWARD" },
                    { 23, "ZOTAC" },
                    { 25, "REDRAGON" },
                    { 26, "AS ROCK" },
                    { 16, "CHIEFTEC" },
                    { 21, "G.SKILL" },
                    { 15, "SAMSUNG" },
                    { 8, "ARMAGGEDDON" },
                    { 13, "SEAGATE" },
                    { 1, "ASUS" },
                    { 14, "TOSHIBA" },
                    { 3, "MSI" },
                    { 4, "SAPPHIRE" },
                    { 5, "AMD" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "GIGABYTE" },
                    { 9, "KINGSTON" },
                    { 10, "GEIL" },
                    { 11, "CRUCIAL" },
                    { 12, "WESTERN DIGITAL" },
                    { 6, "INTEL" },
                    { 7, "MS" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "PC Case" },
                    { 1, "Motherboard" },
                    { 2, "Processor" },
                    { 3, "Graphics card" },
                    { 4, "RAM memory" },
                    { 5, "HDD" },
                    { 6, "SSD" },
                    { 7, "Power supply" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7a7be58a-9eca-403c-8c5d-2d8c2e3bb7ef", "24ab6a6c-14f1-4b49-8964-ecfcbce372a3" });

            migrationBuilder.InsertData(
                table: "ProductTypes_AttributeTypes",
                columns: new[] { "AttributeTypeId", "ProductTypeId" },
                values: new object[,]
                {
                    { 4, 3 },
                    { 11, 3 },
                    { 20, 8 },
                    { 11, 4 },
                    { 8, 4 },
                    { 12, 4 },
                    { 11, 5 },
                    { 13, 5 },
                    { 14, 5 },
                    { 15, 6 },
                    { 11, 6 },
                    { 17, 6 },
                    { 16, 6 },
                    { 18, 7 },
                    { 19, 8 },
                    { 9, 3 },
                    { 10, 3 },
                    { 4, 4 },
                    { 4, 1 },
                    { 8, 2 },
                    { 7, 2 },
                    { 6, 2 },
                    { 5, 2 },
                    { 2, 2 },
                    { 2, 1 },
                    { 1, 1 },
                    { 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "IsVisible", "Name", "OnPromotion", "Picture", "Price", "ProductCode", "Quantity", "TypeId" },
                values: new object[,]
                {
                    { 28, 15, true, "Samsung SSD 970 EVO PLUS 250G M.2 2280", false, "/images/samsung250gb.png", 79m, "EE32FDA4-1AC6-4A8F", 0, 6 },
                    { 29, 2, true, "Gigabyte AORUS NVMe Gen4 SSD 1TB", true, "/images/image5e01e2654eda2.png", 239m, "40069663-75A5-4A89", 77, 6 },
                    { 30, 11, true, "Crucial SSD 250GB PCIe M.2 280 P2", false, "/images/image5ef48b1fa2009.png", 54m, "1D47EAE9-74D5-4FEB", 1, 6 },
                    { 5, 3, true, "MSI Z590 PRO Wifi", false, "/images/image62458b01608fa.png", 219m, "F3623C46-CB95-46F4", 73, 1 },
                    { 4, 2, true, "Gigabyte Z590I AORUS ULTRA", false, "/images/GIGABYTE-Z590I-AORUS-ULTRA.png", 399m, "E1CC7C1F-F24B-4A0D", 36, 1 },
                    { 31, 7, true, "MS CORE M500 80 Plus Platinum Pro 500W", false, "/images/MS-Napajanje-CORE-M500-80-Plus-PLATINUM-PRO-39.png", 59m, "66352EAF-BF17-4DBC", 36, 7 },
                    { 34, 17, true, "CoolerMaster 500W ELITE", false, "/images/image5aa929bb5ba6c.png", 74m, "11CF1670-A053-4068", 36, 7 },
                    { 33, 8, true, "Armaggeddon VOLTRON BRONZE 235FX 242W", false, "/images/image5d9b4a2c06d5b.png", 29m, "0E9656FC-8D9A-4E73", 36, 7 },
                    { 35, 16, true, "Chieftec BBS-700S", false, "/images/image5d09f7085dbf2.png", 129m, "F09C7496-7F2D-4811", 36, 7 },
                    { 3, 1, true, "Asus TUF Gaming B660M-PLUS Wifi D4", false, "/images/image61fd2b7e9bba4.png", 249m, "7E17F2CA-7551-4FB6", 65, 1 },
                    { 36, 18, true, "LC-Power Gaming 992W Solar Flare", false, "/images/image5f9ffbf28c1e6.png", 74m, "B8FA88A9-EF9C-470A", 36, 8 },
                    { 37, 19, true, "FSP CMT340 PLUS", false, "/images/image6239999ddf98c.png", 119m, "AC1D0EF6-3959-49FC", 1, 8 },
                    { 38, 7, true, "MS Gaming ARMOR V500", true, "/images/MS-Kućište-ARMOR-V500-.png", 59m, "7E0E1595-CD05-467A", 2, 8 },
                    { 39, 17, true, "CoolerMaster MasterBox MB311L ARGB", false, "/images/COOLER-MASTER-Kućište-MASTERBOX-MB311L-ARGB-MCB-B311L-KGNN-S02-54.png", 112m, "BC9AA633-8D14-4241", 8, 8 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "IsVisible", "Name", "OnPromotion", "Picture", "Price", "ProductCode", "Quantity", "TypeId" },
                values: new object[,]
                {
                    { 40, 8, true, "Armaggeddon NIMITZ TR 1100", false, "/images/image62b1765247c79.png", 59m, "466C4DE4-1FA9-4D20", 14, 8 },
                    { 2, 3, true, "MSI B450 Gaming PLUS MAX", true, "/images/image5da5cafd9a2b9.png", 159m, "1359BD87-20CD-4B57", 23, 1 },
                    { 32, 17, true, "CoolerMaster XG750 Platinum Plus 750W", true, "/images/image6246d3ec405ae.png", 379m, "FF845915-1C77-4F81", 36, 7 },
                    { 27, 15, true, "Samsung 2TB SSD 970 EVO PLUS M.2 2280", false, "/images/samsung2TB.png", 359m, "CE7E8FC9-53FF-4D89", 47, 6 },
                    { 11, 1, true, "Asus TUF Gaming GeForce RTX 3060 12GB GDDR6 192-bit", false, "/images/ASUS-TUF-Gaming-GeForce-RTX-3060.png", 749m, "FDDE1F79-33D2-45FC", 26, 3 },
                    { 6, 6, true, "Intel Core i5-10600 3.3GHz (4.8GHz)", false, "/images/image5ec863b23325c.png", 319m, "E016E9AB-B8CE-4CC4", 57, 2 },
                    { 12, 3, true, "MSI GeForce RTX 2060 VENTUS 6GB GDDR6 192-bit", false, "/images/image614d8cbf61188.png", 599m, "9AD6F240-3EAF-4F43", 34, 3 },
                    { 13, 1, true, "Asus TUF Gaming GeForce RTX 3080Ti 12GB GDDR6X 384-bit", true, "/images/ASSUS TUF RTX 3080.png", 2499m, "301F218F-1838-42F3", 15, 3 },
                    { 14, 2, true, "Gigabyte AMD Radeon RX6700 XT EAGLE 12GB GDDR6 192-bit", false, "/images/gigabyterx6700xtEagle.png", 899m, "6676BC3B-217E-43D8", 22, 3 },
                    { 15, 4, true, "Sapphire PULSE AMD Radeon RX6500 XT 4GB GDDR6 64-bit", true, "/images/rx6500xt.png", 349m, "6030F440-B958-4B7D", 12, 3 },
                    { 16, 9, true, "Kingston Beast RGB 8GB DDR4 3733MHz CL19", false, "/images/ddr48gb3733.png", 69m, "C8A9A9B8-ED5B-4DEE", 76, 4 },
                    { 17, 9, true, "Kingston Renegade RGB 32GB DDR4 3600MHz CL18", true, "/images/32gb3600.png", 239m, "3EEBAC20-4EC3-45E6", 28, 4 },
                    { 18, 9, true, "Kingston Fury Beast 16GB DDR5 6000MHz CL40", false, "/images/ddr516gb.png", 209m, "AB3F5085-67B7-433D", 52, 4 },
                    { 19, 10, true, "Geil Orion RGB 32GB (2x16GB) DDR4 3200MHz CL16", false, "/images/geilDDR.png", 199m, "D2B2102E-472F-489D", 43, 4 },
                    { 26, 15, true, "Samsung SSD 970 EVO PLUS 500GB M.2 2280", false, "/images/image5c6fdb548f82f1.png", 109m, "09069E93-9244-40A4", 33, 6 },
                    { 20, 9, true, "Kingston Fury RGB 128GB (4x32GB) DDR4 3600MHz CL18", false, "/images/4x32kingston.png", 889m, "95E28014-A052-49F9", 60, 4 },
                    { 9, 5, true, "AMD Ryzen 7 3800X 3.9GHz (4.5GHz)", false, "/images/image5d66752a42531.png", 449m, "38AC8CE3-34D3-4DED", 46, 2 },
                    { 8, 6, true, "Intel Core i7-11700 2.5GHz (4.9GHz)", false, "/images/image62a9bde3e51e1.png", 479m, "B8B11D91-44D5-40A2", 74, 2 },
                    { 7, 6, true, "Intel Core i9-12900 3.2GHz (5.2GHz)", true, "/images/image61e1691968cfd.png", 899m, "76F9939B-6AA5-4D1F", 20, 2 },
                    { 21, 12, true, "WD 10TB 3.5 256MB 7200rpm NAS RedPlus", true, "/images/WD-10TB-3.5.png", 449m, "378E628D-EDAF-4B25", 19, 5 },
                    { 22, 12, true, "WD 2TB 3.5 128MB 5400rpm NAS RedPlus", false, "/images/image61ee87ed2e535.png", 119m, "64A8ACB9-B32F-404C", 93, 5 },
                    { 23, 14, true, "Toshiba 8TB 3.5 256MB 7200rpm X300", false, "/images/723844000288-min-86.png", 279m, "69CAEB14-8A39-42D6", 14, 5 },
                    { 24, 13, true, "Seagate 2TB 2.5 128MB 5400rpm Baracuda", false, "/images/image5bb5c5a17f576.png", 109m, "704403C2-0408-4E21", 66, 5 },
                    { 25, 13, true, "Seagate 2TB 3.5 SATA III 256MB 7200rpm", false, "/images/image58b5545e696ff.png", 79m, "A8477DD6-6975-469E", 35, 5 },
                    { 10, 5, true, "AMD Ryzen 7 5800X3D 3.4GHz (4.5GHz)", false, "/images/image62728b1684f03.png", 699m, "99AB880F-32F3-4B3D", 86, 2 },
                    { 1, 1, true, "Asus Prime B550-PLUS", false, "/images/ASUSPRIMEB550PLUS.png", 209m, "C769DC4E-E32E-49DF", 88, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products_AttributeTypes",
                columns: new[] { "AttributeTypeId", "ProductId", "Value" },
                values: new object[,]
                {
                    { 1, 1, "AMD" },
                    { 13, 25, "7200 RPM" },
                    { 11, 25, "2 TB" },
                    { 14, 24, "128 MB" },
                    { 13, 24, "5400 RPM" },
                    { 11, 24, "2 TB" },
                    { 14, 23, "256 MB" },
                    { 13, 23, "7200 RPM" },
                    { 11, 23, "8 TB" },
                    { 14, 22, "128 MB" },
                    { 13, 22, "5400 RPM" },
                    { 11, 22, "2 TB" },
                    { 14, 21, "256 MB" },
                    { 13, 21, "7200 RPM" },
                    { 11, 21, "10 TB" },
                    { 14, 25, "256 MB" },
                    { 12, 20, "CL18" },
                    { 4, 20, "DDR4" },
                    { 11, 20, "128 GB" },
                    { 12, 19, "CL16" },
                    { 8, 19, "3200 MHz" },
                    { 4, 19, "DDR4" },
                    { 11, 19, "32 GB" },
                    { 12, 18, "CL40" },
                    { 8, 18, "6000 MHz" },
                    { 4, 18, "DDR5" },
                    { 11, 18, "16 GB" },
                    { 12, 17, "CL18" },
                    { 8, 17, "3600 MHz" },
                    { 4, 17, "DDR4" },
                    { 11, 17, "32 GB" },
                    { 8, 20, "3600 MHz" },
                    { 12, 16, "CL19" },
                    { 15, 26, "M.2 2280" },
                    { 17, 26, "3500 MB/s" },
                    { 19, 39, "Black" },
                    { 20, 39, "Mini Tower" },
                    { 19, 38, "Black" },
                    { 20, 38, "Midi Tower" },
                    { 19, 37, "Black" },
                    { 20, 37, "Mini Tower" },
                    { 19, 36, "White" }
                });

            migrationBuilder.InsertData(
                table: "Products_AttributeTypes",
                columns: new[] { "AttributeTypeId", "ProductId", "Value" },
                values: new object[,]
                {
                    { 20, 36, "Midi Tower" },
                    { 18, 35, "700W" },
                    { 18, 34, "500W" },
                    { 18, 33, "242W" },
                    { 18, 32, "750W" },
                    { 18, 31, "500W" },
                    { 16, 30, "1150 MB/s" },
                    { 11, 26, "500 GB" },
                    { 17, 30, "2100 MB/s" },
                    { 15, 30, "M.2 2280" },
                    { 16, 29, "4400 MB/s" },
                    { 17, 29, "5000 MB/s" },
                    { 11, 29, "1 TB" },
                    { 15, 29, "M.2 2280" },
                    { 16, 28, "2300 MB/s" },
                    { 17, 28, "3500 MB/s" },
                    { 11, 28, "250 GB" },
                    { 15, 28, "M.2 2280" },
                    { 16, 27, "3300 MB/s" },
                    { 17, 27, "3500 MB/s" },
                    { 11, 27, "2 TB" },
                    { 15, 27, "M.2 2280" },
                    { 16, 26, "3200 MB/s" },
                    { 11, 30, "250 GB" },
                    { 20, 40, "Mini Tower" },
                    { 8, 16, "3733 MHz" },
                    { 11, 16, "8 GB" },
                    { 2, 8, "Intel 1200" },
                    { 7, 7, "24" },
                    { 6, 7, "16" },
                    { 8, 7, "3.2 GHz" },
                    { 5, 7, "Intel Core i9" },
                    { 2, 7, "Intel 1700" },
                    { 7, 6, "12" },
                    { 6, 6, "6" },
                    { 8, 6, "3.3 GHz" },
                    { 5, 6, "Intel Core i5" },
                    { 2, 6, "Intel 1200" },
                    { 4, 5, "DDR4" },
                    { 3, 5, "Intel Z590" },
                    { 2, 5, "Intel 1200" },
                    { 5, 8, "Intel Core i7" }
                });

            migrationBuilder.InsertData(
                table: "Products_AttributeTypes",
                columns: new[] { "AttributeTypeId", "ProductId", "Value" },
                values: new object[,]
                {
                    { 1, 5, "Intel" },
                    { 3, 4, "Intel Z590" },
                    { 2, 4, "Intel 1200" },
                    { 1, 4, "Intel" },
                    { 4, 3, "DDR4" },
                    { 3, 3, "Intel B660" },
                    { 2, 3, "Intel 1700" },
                    { 1, 3, "Intel" },
                    { 4, 2, "DDR4" },
                    { 3, 2, "AMD B450" },
                    { 2, 2, "AMD AM4" },
                    { 1, 2, "AMD" },
                    { 4, 1, "DDR4" },
                    { 3, 1, "AMD B550" },
                    { 2, 1, "AMD AM4" },
                    { 4, 4, "DDR4" },
                    { 4, 16, "DDR4" },
                    { 8, 8, "2.5 GHz" },
                    { 7, 8, "16" },
                    { 4, 15, "GDDR6" },
                    { 11, 15, "4 GB" },
                    { 9, 15, "Radeon RX 6500 XT" },
                    { 10, 15, "AMD" },
                    { 4, 14, "GDDR6" },
                    { 11, 14, "12 GB" },
                    { 9, 14, "Radeon RX 6700 XT" },
                    { 10, 14, "AMD" },
                    { 4, 13, "GDDR6X" },
                    { 11, 13, "12 GB" },
                    { 9, 13, "GeForce RTX 3080 Ti" },
                    { 10, 13, "Nvidia" },
                    { 4, 12, "GDDR6" },
                    { 11, 12, "6 GB" },
                    { 6, 8, "8" },
                    { 9, 12, "GeForce RTX 2060" },
                    { 4, 11, "GDDR6" },
                    { 11, 11, "12 GB" },
                    { 9, 11, "GeForce RTX 3060" },
                    { 10, 11, "Nvidia" },
                    { 7, 10, "16" },
                    { 6, 10, "8" },
                    { 8, 10, "3.4 GHz" }
                });

            migrationBuilder.InsertData(
                table: "Products_AttributeTypes",
                columns: new[] { "AttributeTypeId", "ProductId", "Value" },
                values: new object[,]
                {
                    { 5, 10, "AMD Ryzen 7" },
                    { 2, 10, "AMD AM4" },
                    { 7, 9, "16" },
                    { 6, 9, "8" },
                    { 8, 9, "3.9 GHz" },
                    { 5, 9, "AMD Ryzen 7" },
                    { 2, 9, "AMD AM4" },
                    { 10, 12, "Nvidia" },
                    { 19, 40, "Black" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeTypes_Name",
                table: "AttributeTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Name",
                table: "Brands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShoppingCartId",
                table: "Orders",
                column: "ShoppingCartId",
                unique: true,
                filter: "[ShoppingCartId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeId",
                table: "Products",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AttributeTypes_AttributeTypeId",
                table: "Products_AttributeTypes",
                column: "AttributeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_Name",
                table: "ProductTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_AttributeTypes_AttributeTypeId",
                table: "ProductTypes_AttributeTypes",
                column: "AttributeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_CustomerId",
                table: "ShoppingCarts",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Products_AttributeTypes");

            migrationBuilder.DropTable(
                name: "ProductTypes_AttributeTypes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AttributeTypes");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
