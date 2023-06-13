using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rookie.AssetManagement.DataAccessor.Migrations
{
    public partial class addtableassetcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstalledDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryID = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    AssetState = table.Column<int>(type: "int", nullable: false),
                    LocationID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetCode);
                    table.ForeignKey(
                        name: "FK_Assets_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID");
                    table.ForeignKey(
                        name: "FK_Assets_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { "LA", "Laptop" },
                    { "MO", "Monitor" },
                    { "PC", "Personal Computer" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e332664f-7870-4e82-8410-f0b489870948");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "8cbcd895-b323-4af6-aad1-2c7cefcd17c3");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "195b913a-059f-4855-84ec-11379ec2f527", "AQAAAAEAACcQAAAAEEeGSbiQqRsZtYk/MbSC/ngf0bi8TxHaRZs5ryXUc9MDLa0gAPYDKKsld9LNv1QkPw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "37b6989f-df67-4a43-ac2c-e4fb94d435eb", "AQAAAAEAACcQAAAAEFLaHY+NHj00kmdW6xnSNkfgt7JSJIy7XqLbHx1mWbMfi90xld+kNEqZgNE3dRcwzw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cf3394a6-6e0a-4b88-bf8a-45d7c24e0f15", "AQAAAAEAACcQAAAAECbXOhIi3rIij2ahhKAaSoNX6oirQwaxFnQEzGe2ocHlcvwsUoX6hijzC2CZx78myA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c873c5ad-afc8-4818-b4c5-1a7b373791d3", "AQAAAAEAACcQAAAAEET+jHm2Uh7XBCgd+V/Y27K7uPTat8sYOarM6Ih2mxnWGkCoP2dqYXuVmnnhRidMkA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "20ef6db7-0400-4786-840f-c88730d2466d", "nhattm", "AQAAAAEAACcQAAAAEPXB6TA3dO0IyOXbdhRJGw9zU4yfR1OxbIivHt26l6mfcVc1GqRg94bVMDsNPq5uEQ==", "nhattm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "d8ad75e3-b08a-4ba7-9b66-b4b8a63b9144", "vannng", "AQAAAAEAACcQAAAAEMwcCuowgQR9gykwHj2bHLeezahteoMikJVUq7+ynOns4ue4Hoxwxnp+jQaY/F15+g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c1a6f3dd-3b87-4d8c-99dd-b68fe8d5be5e", "AQAAAAEAACcQAAAAEGaGTItPiwO6AZRTRRvoDvcIkoR9cCG8a1fMuodzpt/NATHNYQV7FSDd6sYltlHzVA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "26b2fe1f-6809-4b86-9cd4-5f34f5598346", "AQAAAAEAACcQAAAAEJzPO3i2VHUyZ5rLFnhBTgggv2OjHgjJwjS1IU2PZ1CGfbhkjgiwJTDVjaWLReyCmw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a2e7dc12-70b9-417d-a41d-d6afdd0e6249", "AQAAAAEAACcQAAAAEDvX8x78axkjbLBOhHAIQMYb2f8gUuXi431FrnijJ/xvgNDx7sep5nKkAxwgSKQtUA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0ae322c3-9114-494a-8715-11586bc4aeac", "AQAAAAEAACcQAAAAEHnFlCqgP9XE/y9ydhjLyk9x8Pw/kKzUx+lyOlnJejE7neO2z+ZChzK/Ee6me00W1g==" });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetCode", "AssetName", "AssetState", "CategoryID", "InstalledDay", "LocationID", "Specification" },
                values: new object[,]
                {
                    { "LA000001", "Laptop Apple MacBook Pro M1", 2, "LA", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Apple M1, RAM 8GB, SSD 256GB" },
                    { "LA000002", "Laptop Apple MacBook Pro M1", 2, "LA", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Apple M1, RAM 8GB, SSD 256GB" },
                    { "LA000003", "Laptop Apple MacBook Pro M1", 2, "LA", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Apple M1, RAM 8GB, SSD 256GB" },
                    { "LA000004", "Laptop Dell XPS 13 9310", 2, "LA", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Intel Core i7 Tiger Lake 1165G7, RAM 16GB LPDDR4X, SSD 1 TB M.2 PCIe" },
                    { "LA000005", "Laptop Dell XPS 13 9310", 1, "LA", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Intel Core i7 Tiger Lake 1165G7, RAM 16GB LPDDR4X, SSD 1 TB M.2 PCIe" },
                    { "LA000006", "Laptop Dell XPS 13 9310", 5, "LA", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Intel Core i7 Tiger Lake 1165G7, RAM 16GB LPDDR4X, SSD 1 TB M.2 PCIe" },
                    { "LA000007", "Laptop HP Pavilion 15", 1, "LA", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe" },
                    { "LA000008", "Laptop HP Pavilion 15", 1, "LA", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe" },
                    { "LA000009", "Laptop HP Pavilion 15", 2, "LA", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe" },
                    { "LA000010", "Laptop HP Pavilion 15", 1, "LA", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe" },
                    { "LA000011", "Laptop Apple MacBook Pro M1", 2, "LA", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Apple M1, RAM 8GB, SSD 256GB" },
                    { "LA000012", "Laptop Apple MacBook Pro M1", 2, "LA", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Apple M1, RAM 8GB, SSD 256GB" },
                    { "LA000013", "Laptop Apple MacBook Pro M1", 2, "LA", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Apple M1, RAM 8GB, SSD 256GB" },
                    { "LA000014", "Laptop Dell XPS 13 9310", 2, "LA", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Intel Core i7 Tiger Lake 1165G7, RAM 16GB LPDDR4X, SSD 1 TB M.2 PCIe" },
                    { "LA000015", "Laptop Dell XPS 13 9310", 1, "LA", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Intel Core i7 Tiger Lake 1165G7, RAM 16GB LPDDR4X, SSD 1 TB M.2 PCIe" },
                    { "LA000016", "Laptop Dell XPS 13 9310", 5, "LA", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Intel Core i7 Tiger Lake 1165G7, RAM 16GB LPDDR4X, SSD 1 TB M.2 PCIe" },
                    { "LA000017", "Laptop HP Pavilion 15", 1, "LA", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe" },
                    { "LA000018", "Laptop HP Pavilion 15", 1, "LA", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe" },
                    { "LA000019", "Laptop HP Pavilion 15", 2, "LA", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe" },
                    { "LA000020", "Laptop HP Pavilion 15", 1, "LA", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe" },
                    { "MO000001", "Monitor Dell UltraSharp", 2, "MO", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "4K, QHD & ultra-high-definition (UHD) monitors" },
                    { "MO000002", "Monitor Dell UltraSharp", 2, "MO", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "4K, QHD & ultra-high-definition (UHD) monitors" },
                    { "MO000003", "Monitor Dell UltraSharp", 1, "MO", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "4K, QHD & ultra-high-definition (UHD) monitors" },
                    { "MO000004", "Monitor Dell UltraSharp", 2, "MO", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "4K, QHD & ultra-high-definition (UHD) monitors" },
                    { "MO000005", "Monitor Dell UltraSharp", 2, "MO", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "4K, QHD & ultra-high-definition (UHD) monitors" },
                    { "MO000006", "Asus Designo Curve", 2, "MO", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Resolution: 3,840 x 1,600px. Brightness: 300 cd/m2" },
                    { "MO000007", "Asus Designo Curve", 1, "MO", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Resolution: 3,840 x 1,600px. Brightness: 300 cd/m3" },
                    { "MO000008", "Asus Designo Curve", 2, "MO", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Resolution: 3,840 x 1,600px. Brightness: 300 cd/m4" },
                    { "MO000009", "Asus Designo Curve", 1, "MO", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Resolution: 3,840 x 1,600px. Brightness: 300 cd/m5" },
                    { "MO000010", "Asus Designo Curve", 1, "MO", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Resolution: 3,840 x 1,600px. Brightness: 300 cd/m6" },
                    { "MO000011", "Monitor Dell UltraSharp", 3, "MO", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "4K, QHD & ultra-high-definition (UHD) monitors" },
                    { "MO000012", "Monitor Dell UltraSharp", 1, "MO", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "4K, QHD & ultra-high-definition (UHD) monitors" },
                    { "MO000013", "Monitor Dell UltraSharp", 1, "MO", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "4K, QHD & ultra-high-definition (UHD) monitors" },
                    { "MO000014", "Monitor Dell UltraSharp", 1, "MO", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "4K, QHD & ultra-high-definition (UHD) monitors" },
                    { "MO000015", "Monitor Dell UltraSharp", 1, "MO", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "4K, QHD & ultra-high-definition (UHD) monitors" },
                    { "MO000016", "Asus Designo Curve", 5, "MO", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Resolution: 3,840 x 1,600px. Brightness: 300 cd/m2" },
                    { "MO000017", "Asus Designo Curve", 1, "MO", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Resolution: 3,840 x 1,600px. Brightness: 300 cd/m3" },
                    { "MO000018", "Asus Designo Curve", 1, "MO", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Resolution: 3,840 x 1,600px. Brightness: 300 cd/m4" },
                    { "MO000019", "Asus Designo Curve", 1, "MO", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Resolution: 3,840 x 1,600px. Brightness: 300 cd/m5" },
                    { "MO000020", "Asus Designo Curve", 1, "MO", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Resolution: 3,840 x 1,600px. Brightness: 300 cd/m6" },
                    { "PC000001", "Dell OptiPlex 3050 Micro", 2, "PC", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD" },
                    { "PC000002", "Dell OptiPlex 3050 Micro", 2, "PC", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD" }
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetCode", "AssetName", "AssetState", "CategoryID", "InstalledDay", "LocationID", "Specification" },
                values: new object[,]
                {
                    { "PC000003", "Dell OptiPlex 3050 Micro", 2, "PC", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD" },
                    { "PC000004", "Dell OptiPlex 3050 Micro", 2, "PC", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD" },
                    { "PC000005", "Dell OptiPlex 3050 Micro", 2, "PC", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD" },
                    { "PC000006", "Apple iMac Pro", 2, "PC", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD" },
                    { "PC000007", "Apple iMac Pro", 2, "PC", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD" },
                    { "PC000008", "Apple iMac Pro", 2, "PC", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD" },
                    { "PC000009", "Apple iMac Pro", 2, "PC", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD" },
                    { "PC000010", "Apple iMac Pro", 2, "PC", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD" },
                    { "PC000011", "Dell OptiPlex 3050 Micro", 2, "PC", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD" },
                    { "PC000012", "Dell OptiPlex 3050 Micro", 1, "PC", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD" },
                    { "PC000013", "Dell OptiPlex 3050 Micro", 2, "PC", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD" },
                    { "PC000014", "Dell OptiPlex 3050 Micro", 2, "PC", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD" },
                    { "PC000015", "Dell OptiPlex 3050 Micro", 2, "PC", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD" },
                    { "PC000016", "Apple iMac Pro", 1, "PC", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD" },
                    { "PC000017", "Apple iMac Pro", 2, "PC", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD" },
                    { "PC000018", "Apple iMac Pro", 1, "PC", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD" },
                    { "PC000019", "Apple iMac Pro", 1, "PC", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD" },
                    { "PC000020", "Apple iMac Pro", 2, "PC", new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_CategoryID",
                table: "Assets",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_LocationID",
                table: "Assets",
                column: "LocationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "3836efe7-8bef-4bb4-a6ac-801ee8467e5a");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "07b98b1d-e7ef-4737-900b-95380cff0c07");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7d9056c7-5e0f-40ba-a4d2-740bf3f405cf", "AQAAAAEAACcQAAAAEOECRUlKULZAFXAg09g5orfm8RheLkzlnzlHYlLl99+xip1Pz1PG7AscXVohuXU2gg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ffb6a2f8-95c9-4d57-9394-4c45601781c5", "AQAAAAEAACcQAAAAEGgOdZHReacdFkTFpxyAJYEOSp3a96XbXT9aqSm9JLG7069WoxD2YlMvl9ll3BB2Qw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "18e27e58-f1ce-4476-b564-5816f3cd8269", "AQAAAAEAACcQAAAAEC5EeC6wRaiyDcMk53sYAbCmP+F2U0kx/DqQAxpj4hJS94EFYaJN0WZxxppk+rHirA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "883d8b57-9ebe-4547-9f19-98331e7c4121", "AQAAAAEAACcQAAAAEJY0wJhJ7a9kIV4PrLhmaQfFbYecdjZEuF5Ii3ltql+bYIBLzrNzgRjwfUuo0q4w1w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "c33d663e-351a-4998-aeeb-b2edd7da19d5", "nhuttm", "AQAAAAEAACcQAAAAEFj6kH5aRqN6gFPSQePH/tZoEQ/IcEb13tgRf+N/OCLwcRePnKfS8KrsdnShuB7CLA==", "nhuttm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "85fca277-0a8e-457c-bb46-bfec092a7fdd", "Vannng", "AQAAAAEAACcQAAAAEDvGQIG2mUWCUF953FT213fyPTMRpeDejRVORvrQ5CbuuA86od3jFP58Re3cvOt6SQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "16684ed7-0d44-4cd4-89b4-348c4a1633d2", "AQAAAAEAACcQAAAAEK/bZl/nWLKw4Mg1rFEHw3e9+h2JV56Zxs9Dj2rOuaMJt2ykq2pPpEkeUTRVrwIhIw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a199709d-2755-43eb-ab77-4590af6e646f", "AQAAAAEAACcQAAAAECgIw/jyDGbs3V8NFfMDZjcUPDYal6qLx5YK3beQp9KCMu/Bd10vVYWUmpu7BDQMCg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ce63fede-8af9-4620-851a-b56e9f00d4d9", "AQAAAAEAACcQAAAAEA4jw3t+I+9leC3AKHpiaPs9HF8zuI+zNoqDVWVw+M0EogphQzPHfxKaY3GqdfABFA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4a79ea82-888f-4077-a475-f7542183f743", "AQAAAAEAACcQAAAAEDv3AZMjNCDhWVIKNII+lJgDiDAD++mNW2q58TcF3HZx72GKBzCqU3LYMVNb/jsIHQ==" });
        }
    }
}
