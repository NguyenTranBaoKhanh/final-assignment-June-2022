using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rookie.AssetManagement.DataAccessor.Migrations
{
    public partial class addtableassignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Assets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetCode = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    AssignedToUserId = table.Column<int>(type: "int", nullable: true),
                    AssignedByUserId = table.Column<int>(type: "int", nullable: true),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignmentState = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Assets_AssetCode",
                        column: x => x.AssetCode,
                        principalTable: "Assets",
                        principalColumn: "AssetCode");
                    table.ForeignKey(
                        name: "FK_Assignments_Users_AssignedByUserId",
                        column: x => x.AssignedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assignments_Users_AssignedToUserId",
                        column: x => x.AssignedToUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "AssetCode", "AssignedByUserId", "AssignedDate", "AssignedToUserId", "AssignmentState", "IsDeleted", "Note" },
                values: new object[,]
                {
                    { 1, "LA000001", 1, new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3696), 2, 2, false, null },
                    { 2, "LA000002", 1, new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3709), 2, 1, false, null },
                    { 3, "LA000003", 1, new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3710), 2, 1, false, null },
                    { 4, "LA000004", 1, new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3712), 2, 2, false, null },
                    { 5, "LA000005", 1, new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3712), 3, 2, false, null },
                    { 6, "MO000001", 1, new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3713), 3, 2, false, null },
                    { 7, "MO000002", 1, new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3714), 3, 1, false, null },
                    { 8, "MO000003", 1, new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3715), 3, 2, false, null },
                    { 9, "MO000004", 1, new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3716), 3, 2, false, null },
                    { 10, "MO000005", 1, new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3716), 3, 2, false, null },
                    { 11, "PC000001", 4, new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3717), 2, 2, false, null },
                    { 12, "PC000002", 1, new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3718), 4, 2, false, null },
                    { 13, "PC000003", 1, new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3719), 4, 2, false, null },
                    { 14, "PC000004", 1, new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3720), 4, 2, false, null },
                    { 15, "PC000005", 1, new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3720), 4, 2, false, null },
                    { 16, "PC000006", 1, new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3721), 4, 2, false, null }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e20ec457-677e-4d0e-be75-90e5be567bbf");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "bfbd3bc4-c737-4944-9a99-18a05d1ece06");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d40b795a-8c36-43b1-b025-5e99ad3a8760", "AQAAAAEAACcQAAAAEFSf84fzwWriGTOkgZz7pjI3SsIiWJ7Ldqqub+1WLMmfrnePw2u0Sf8oenACyiH/zw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3c08396a-576a-46d5-a5b8-6595ac4e5408", "AQAAAAEAACcQAAAAEI8Cn5LC3Q2RCpWAigOwO705q1ztmn4o1qR7aa963ToLO2HXB23sfV/g+Y3ePjS2lA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c6e3172e-ecb9-4201-8c6d-ff122f66e806", "AQAAAAEAACcQAAAAEIKOo5D4boKpVRh1dCdelyQlHVKCRlaz9rFNUKVoS6iVHKmQc349Jnh+I3Hqd7KMvQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cc2a8ca2-fab7-4dfd-912c-f61abb39bd4d", "AQAAAAEAACcQAAAAELw148bV55ccKg26AzgVKtFyzRIs9C+XKDvW3MHlKVMgiY1zYorkXNemBiToeSRV8g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "84cff317-0743-4580-89a3-ca029cf8db91", "AQAAAAEAACcQAAAAEGLh+KfDXqxSJIYIqLY1Q6XPiMR6K2QdfZ1gyeuL2MV45XEM1/jPHhE3f1h/TXZhOA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "375ab57f-b3f3-44b2-8568-bbe877263081", "AQAAAAEAACcQAAAAEKC1K8bOrNDy267ZIx1indiTeGQZk4IUCiM3kDDDqOYFApJiHJHYxNB5AUF12pusHw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bbe0dcc3-0193-4793-9e1b-76bd1cb0dcd8", "AQAAAAEAACcQAAAAEAkTLZufcL97V5r+otIB3jqh8ePBAgbYV6J0woKwueiFsTQwqzHdvLtl/H4SmDujcQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0bfb1ae3-e2b2-426b-b0ef-3e06bf795258", "AQAAAAEAACcQAAAAEDU5ZYsMsBGWLtuXB6bCK6wQfgJFSNqKHn4aGiw8KN6SPb5IEJC3ZGIO0as9GbUUIQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "76e53a80-5545-44cc-a436-4e1813cc67ba", "AQAAAAEAACcQAAAAEDBk56iEqriFim+ZRG5MjbM96LPclsl7DDAQhe1BI+6n+eAInAnZSMsBD5DBesjEgg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bd9022c4-a72a-4871-9c2f-af37c098ad46", "AQAAAAEAACcQAAAAEEYRh2hIbQRoVNAkGV48c1swodctqWtjPfxoa4kyVULLhxWb5EnzRI0NzXbdpdPBMA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssetCode",
                table: "Assignments",
                column: "AssetCode");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssignedByUserId",
                table: "Assignments",
                column: "AssignedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssignedToUserId",
                table: "Assignments",
                column: "AssignedToUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Assets");

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "20ef6db7-0400-4786-840f-c88730d2466d", "AQAAAAEAACcQAAAAEPXB6TA3dO0IyOXbdhRJGw9zU4yfR1OxbIivHt26l6mfcVc1GqRg94bVMDsNPq5uEQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d8ad75e3-b08a-4ba7-9b66-b4b8a63b9144", "AQAAAAEAACcQAAAAEMwcCuowgQR9gykwHj2bHLeezahteoMikJVUq7+ynOns4ue4Hoxwxnp+jQaY/F15+g==" });

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
        }
    }
}
