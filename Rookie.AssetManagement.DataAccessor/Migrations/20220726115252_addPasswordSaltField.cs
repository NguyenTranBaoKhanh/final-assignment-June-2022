using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rookie.AssetManagement.DataAccessor.Migrations
{
    public partial class addPasswordSaltField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c33d663e-351a-4998-aeeb-b2edd7da19d5", "AQAAAAEAACcQAAAAEFj6kH5aRqN6gFPSQePH/tZoEQ/IcEb13tgRf+N/OCLwcRePnKfS8KrsdnShuB7CLA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "85fca277-0a8e-457c-bb46-bfec092a7fdd", "AQAAAAEAACcQAAAAEDvGQIG2mUWCUF953FT213fyPTMRpeDejRVORvrQ5CbuuA86od3jFP58Re3cvOt6SQ==" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ff202140-f854-4557-a78f-0c20557fbf53");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4945c745-edc7-4378-ab30-6cab5ddd611d");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cefb8c99-02e8-4672-83c1-b5d6c8e577d7", "AQAAAAEAACcQAAAAEMackweE8G3D+uQ2vFVe+pSH3WCrBVEs3/+W+yb4/JnVvPBc4D8I93J2F/sW9wgKiw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8f0c4739-c6ea-4918-811d-5c4681999a53", "AQAAAAEAACcQAAAAEDy1mfCNQEKcmd/XM5mbkaOw1YF+BBcjF6D/P7V9VAQso3GxX45XDrOci40/e2QAnw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2c54b822-4e38-4846-86b5-641ccb378afa", "AQAAAAEAACcQAAAAEIUyb0SEdlALMOafpKlSzmFeulU+W96Il6JREfYRq8YBsBTjR4HGFbu+nre2C818Aw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d5718306-e6fa-4b48-a20e-90a67e31293c", "AQAAAAEAACcQAAAAEKE094RhbLEd5spnvtfkGOdoZWKbRclmnV/9TbWmb7LtF9cBEgYHlJ8ENskRZzlPTQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f2a4cd1b-ed2f-4f05-87da-e91edccd11a0", "AQAAAAEAACcQAAAAEF9wrKJYdhNx03+xyk/2oC4Xl/hcsDQxG+pxVDk1SyJGwWBJR5FdPPXXjr1xuTO32g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e8050098-6b96-4091-9591-98f05f43e83a", "AQAAAAEAACcQAAAAEKFkSaDWZhHVER63rBSAMrTSPNsloZhOVe1fQ1V6Cy3DO6SzxhBXBt9SlBpPDqVf0A==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d9cd1d18-0839-483d-97c9-1f71ae68f8b7", "AQAAAAEAACcQAAAAELNSny3nbmnQgAf5cRK5TnxS/+Buxlarpc8aaxtUFha1V3GU8xLlr5D1GMUHiZBshQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "433ffd96-ad1c-4d82-a471-32e34f0f13b2", "AQAAAAEAACcQAAAAEFQlpA1qAXoBpAVJlofTkB345ylbEJw7sKUDM8ENXOjWL7XVD5a4yIDs+MQ/kV7APA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "230faf04-b80e-45a1-9d2e-221119848277", "AQAAAAEAACcQAAAAECbTr0Rjm97NdeuuwkcqZ1W9MpXVdk47Xlht5Kj56NiBI9UOqmzaocIVovs7WJkW+w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1d1610c3-83f0-4def-92e8-852f954e0865", "AQAAAAEAACcQAAAAEPjg/09ROVu0GWWAZXRntxWDfaRlGEx8nNE6ROOXM+28UPT5PuiwbTfne1QOtWTsmQ==" });
        }
    }
}
