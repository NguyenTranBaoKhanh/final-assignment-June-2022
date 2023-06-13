using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rookie.AssetManagement.DataAccessor.Migrations
{
    public partial class addLocationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins");

            migrationBuilder.DropIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserTokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserTokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLogged",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationID",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "StaffCode",
                table: "Users",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "UserLogins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserLogins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationID", "LocationName" },
                values: new object[,]
                {
                    { "HCM", "Ho Chi Minh" },
                    { "HN", "Ha Noi" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "ff202140-f854-4557-a78f-0c20557fbf53", "Admin", "ADMIN" },
                    { 2, "4945c745-edc7-4378-ab30-6cab5ddd611d", "Staff", "STAFF" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "EmailConfirmed", "FirstName", "Gender", "IsLogged", "JoinedDate", "LastName", "LocationID", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StaffCode", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "cefb8c99-02e8-4672-83c1-b5d6c8e577d7", new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1989, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Thong", "F", true, new DateTime(2015, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyen Hoang", "HCM", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "thongnh", "AQAAAAEAACcQAAAAEMackweE8G3D+uQ2vFVe+pSH3WCrBVEs3/+W+yb4/JnVvPBc4D8I93J2F/sW9wgKiw==", null, false, "NQLC7WE4A7DTOM5DETPA35OHKTOZMMYP", "SD1001", false, "thongnh" },
                    { 2, 0, "8f0c4739-c6ea-4918-811d-5c4681999a53", new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1983, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Canh", "M", false, new DateTime(2018, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ho Minh", "HCM", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "canhhm", "AQAAAAEAACcQAAAAEDy1mfCNQEKcmd/XM5mbkaOw1YF+BBcjF6D/P7V9VAQso3GxX45XDrOci40/e2QAnw==", null, false, "NQLC7NG4A7RTOM5DETPA35OHKTOZMMYP", "SD1002", false, "canhhm" },
                    { 3, 0, "2c54b822-4e38-4846-86b5-641ccb378afa", new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1987, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Khanh", "F", false, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyen Tran Bao", "HN", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "khanhntb", "AQAAAAEAACcQAAAAEIUyb0SEdlALMOafpKlSzmFeulU+W96Il6JREfYRq8YBsBTjR4HGFbu+nre2C818Aw==", null, false, "NQLC7NG4A7DTYM5DETPA35OHKTOZMMYP", "SD1003", false, "khanhntb" },
                    { 4, 0, "d5718306-e6fa-4b48-a20e-90a67e31293c", new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1983, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Sang", "F", false, new DateTime(2018, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyen Vinh", "HN", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sangnv", "AQAAAAEAACcQAAAAEKE094RhbLEd5spnvtfkGOdoZWKbRclmnV/9TbWmb7LtF9cBEgYHlJ8ENskRZzlPTQ==", null, false, "NQLC7NG4A7DTOJ5DETPA35OHKTOZMMYP", "SD1005", false, "sangnv" },
                    { 5, 0, "f2a4cd1b-ed2f-4f05-87da-e91edccd11a0", new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1980, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Nhut", "M", true, new DateTime(2020, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tran Minh", "HN", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nhuttm", "AQAAAAEAACcQAAAAEF9wrKJYdhNx03+xyk/2oC4Xl/hcsDQxG+pxVDk1SyJGwWBJR5FdPPXXjr1xuTO32g==", null, false, "NQLC7NG4R7DTOM5DETPA35OHKTOZMMYP", "SD1006", false, "nhuttm" },
                    { 6, 0, "e8050098-6b96-4091-9591-98f05f43e83a", new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1987, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Van", "F", true, new DateTime(2016, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyen Ngoc Gia", "HN", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vannng", "AQAAAAEAACcQAAAAEKFkSaDWZhHVER63rBSAMrTSPNsloZhOVe1fQ1V6Cy3DO6SzxhBXBt9SlBpPDqVf0A==", null, false, "NQLC7NG4A7DTOM5DHTPA35OHKTOZMMYP", "SD1007", false, "Vannng" },
                    { 7, 0, "d9cd1d18-0839-483d-97c9-1f71ae68f8b7", new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1987, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Thang", "F", false, new DateTime(2016, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyen Viet", "HN", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "thangnv", "AQAAAAEAACcQAAAAELNSny3nbmnQgAf5cRK5TnxS/+Buxlarpc8aaxtUFha1V3GU8xLlr5D1GMUHiZBshQ==", null, false, "NQLC7NG4A7DTOM5DETPA35OMKTOZMMYP", "SD1008", false, "thangnv" },
                    { 8, 0, "433ffd96-ad1c-4d82-a471-32e34f0f13b2", new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1984, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Toan", "M", false, new DateTime(2017, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le Hang", "HCM", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "toanlh", "AQAAAAEAACcQAAAAEFQlpA1qAXoBpAVJlofTkB345ylbEJw7sKUDM8ENXOjWL7XVD5a4yIDs+MQ/kV7APA==", null, false, "NQLC7NG4A7DTOM5DETPA35OHKTOZBMYP", "SD1009", false, "toanlh" },
                    { 9, 0, "230faf04-b80e-45a1-9d2e-221119848277", new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1981, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Quy", "M", false, new DateTime(2017, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bui Duy", "HCM", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "quybd", "AQAAAAEAACcQAAAAECbTr0Rjm97NdeuuwkcqZ1W9MpXVdk47Xlht5Kj56NiBI9UOqmzaocIVovs7WJkW+w==", null, false, "NQLC7NG4A7DTOM5DETPA35OHKTOZMMYP", "SD1010", false, "quybd" },
                    { 10, 0, "1d1610c3-83f0-4def-92e8-852f954e0865", new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1986, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Phuong", "F", false, new DateTime(2018, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vo Hoang", "HCM", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "phuongvh", "AQAAAAEAACcQAAAAEPjg/09ROVu0GWWAZXRntxWDfaRlGEx8nNE6ROOXM+28UPT5PuiwbTfne1QOtWTsmQ==", null, false, "NQLC7NG4A7DTOM5DETPA35OHKTOWMMYP", "SD1011", false, "phuongvh" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_LocationID",
                table: "Users",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Locations_LocationID",
                table: "Users",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Locations_LocationID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens");

            migrationBuilder.DropIndex(
                name: "IX_Users_LocationID",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsLogged",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "JoinedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StaffCode",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserTokens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserTokens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "UserLogins",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserLogins",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");
        }
    }
}
