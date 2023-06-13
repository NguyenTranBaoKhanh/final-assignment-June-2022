using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rookie.AssetManagement.DataAccessor.Migrations
{
    public partial class addtablerequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestState = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    RequestedUserId = table.Column<int>(type: "int", nullable: true),
                    AcceptedUserId = table.Column<int>(type: "int", nullable: true),
                    ReturnedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Users_AcceptedUserId",
                        column: x => x.AcceptedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_Users_RequestedUserId",
                        column: x => x.RequestedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 13, 11, 47, 8, 740, DateTimeKind.Local).AddTicks(4130));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 13, 11, 47, 8, 740, DateTimeKind.Local).AddTicks(4143));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 13, 11, 47, 8, 740, DateTimeKind.Local).AddTicks(4144));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 4,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 13, 11, 47, 8, 740, DateTimeKind.Local).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 5,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 13, 11, 47, 8, 740, DateTimeKind.Local).AddTicks(4146));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 6,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 13, 11, 47, 8, 740, DateTimeKind.Local).AddTicks(4148));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 7,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 13, 11, 47, 8, 740, DateTimeKind.Local).AddTicks(4149));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 8,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 13, 11, 47, 8, 740, DateTimeKind.Local).AddTicks(4150));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 9,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 13, 11, 47, 8, 740, DateTimeKind.Local).AddTicks(4151));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 10,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 13, 11, 47, 8, 740, DateTimeKind.Local).AddTicks(4152));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 11,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 13, 11, 47, 8, 740, DateTimeKind.Local).AddTicks(4154));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 12,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 13, 11, 47, 8, 740, DateTimeKind.Local).AddTicks(4155));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 13,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 13, 11, 47, 8, 740, DateTimeKind.Local).AddTicks(4156));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 14,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 13, 11, 47, 8, 740, DateTimeKind.Local).AddTicks(4157));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 15,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 13, 11, 47, 8, 740, DateTimeKind.Local).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 16,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 13, 11, 47, 8, 740, DateTimeKind.Local).AddTicks(4159));

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "AcceptedUserId", "AssignmentId", "IsDeleted", "RequestedUserId", "ReturnedDate" },
                values: new object[,]
                {
                    { 1, null, 1, false, 8, null },
                    { 2, null, 6, false, 9, null }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "bfc4949f-2890-432b-b235-132e3c32fd8c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7252b309-9081-4a11-b14d-b93c4e93450f");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5c3de992-405c-40f6-af04-2c0f8ef27d79", "AQAAAAEAACcQAAAAEBSDVpuuh/Foi3r5yOVJocqZNHcpvREdoXqMM7Zbw5O8SNPHgKmDDDx06jU81yMcaA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "05c0ffcf-4d22-4eab-95f9-7d046bce4034", "AQAAAAEAACcQAAAAEJm87xryvq3F2rgsaHMjqqIQdfM1k+djPAEZUj6+Nu3pbqRuy4Iddc4iB37h213CzA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e8dee783-0a0a-4537-b7d3-5524765bae55", "AQAAAAEAACcQAAAAEM7Co4/d/7em5nFItBeWTKIJ9fVKA+bgBcTFOlcKLBvMzMQiCqqXYR6KDaqqG8XQ+g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d5b61ab0-8a60-4b25-a151-c7c9a46918da", "AQAAAAEAACcQAAAAEImGUDG2F9loBgbQQ8rnDrjRto0jTKfBkslpIFnEgx34CRW4JHkwgQrjz2nSFzir4g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "682ddf66-36c3-48cc-867f-625036205953", "AQAAAAEAACcQAAAAELNS9hlDDBHIWdlnzp7H5WjaYkcuUHRV1vdiiWndqpJnI30ScHqGAUdrzVrUYzoSaQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e3146734-b5e3-4daa-8222-87b46f757061", "AQAAAAEAACcQAAAAECLa5RlAs+b1XGK32dgnfC3/E676l1y/RkJrK1V3rMAcTeTdRM4oMR1eBgwo8iMBsQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b0103c69-f3e4-4c13-bf37-e874ac21ae45", "AQAAAAEAACcQAAAAEAbGbN8UNdpl36Gn9GTKoAR0aiX6Hnp3a3yZMeM2FeLxenEQYmpORy+2VWdfCDL/3A==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5b7b4a2d-e4d1-44aa-9607-d394927168fa", "AQAAAAEAACcQAAAAEPZLAzwon2ZCWGM3f4Lmwk9dGu6kXFDLbfV9Hh76c2dG4ruGM0wdWy5DUp+KEVxm/Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "483c099d-dc67-4961-8444-769045c0c025", "AQAAAAEAACcQAAAAEGh9DAZ1tQ/Hg0HcWfWAE5dNpJRgtFDwfba1iZBSMp2tUpcgEoHAP7AsvdIaVzrISw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fb366933-a80e-4ca0-b5d0-3a97be52c5a9", "AQAAAAEAACcQAAAAECEpxFl2O4erJHAXaZyPa14gqDWoKlCAl8Nq5QPbvVCCYZTijla52BKzvsVTGLe8qg==" });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_AcceptedUserId",
                table: "Requests",
                column: "AcceptedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_AssignmentId",
                table: "Requests",
                column: "AssignmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestedUserId",
                table: "Requests",
                column: "RequestedUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3696));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3709));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3710));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 4,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3712));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 5,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3712));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 6,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3713));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 7,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3714));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 8,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3715));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 9,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3716));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 10,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3716));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 11,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3717));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 12,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3718));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 13,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3719));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 14,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 15,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 16,
                column: "AssignedDate",
                value: new DateTime(2022, 8, 5, 15, 9, 43, 356, DateTimeKind.Local).AddTicks(3721));

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
        }
    }
}
