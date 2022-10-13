using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.API.Migrations
{
    public partial class SeededDefaultUsersAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a15fff9b-0e00-4f7d-bee0-6b74a4e14339", "d3795ddd-df36-4c5a-8b0b-681b9f8c6abb", "User", "USER" },
                    { "be92ca08-6b57-4eee-bc95-1b51015e8e2c", "62f623aa-af76-403d-8a0c-4ba310dc9fc9", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "414dcdef-280d-45f8-a6c9-98d7ad09a2e4", 0, "3de7f009-c8b6-4b6a-9707-c458f67a7531", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEA5rDxZYz5qF9F2UDYFDqCzbTC4jyeJlaPhHz6N3sIPcRAwxCy/AL+8guzDRNVlapw==", null, false, "acefc7c5-6304-4e15-8785-a655792357a6", false, "admin@bookstore.com" },
                    { "ebc02af4-5bf0-4ade-9829-501c89a1a55a", 0, "28d5d7d7-5b14-4800-88ca-8cb1329a3b2e", "user@bookstore.com", false, "System", "user", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAEAACcQAAAAECITwi3OhM1FgWILRSZc7zYph6bFNFKOGPX6+s4bkD4RI7dt3edYahAvlIPYLJ4IWg==", null, false, "4ba60425-0b6d-4ad6-abb1-18aacfc5e32a", false, "user@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "be92ca08-6b57-4eee-bc95-1b51015e8e2c", "414dcdef-280d-45f8-a6c9-98d7ad09a2e4" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a15fff9b-0e00-4f7d-bee0-6b74a4e14339", "ebc02af4-5bf0-4ade-9829-501c89a1a55a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "be92ca08-6b57-4eee-bc95-1b51015e8e2c", "414dcdef-280d-45f8-a6c9-98d7ad09a2e4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a15fff9b-0e00-4f7d-bee0-6b74a4e14339", "ebc02af4-5bf0-4ade-9829-501c89a1a55a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a15fff9b-0e00-4f7d-bee0-6b74a4e14339");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be92ca08-6b57-4eee-bc95-1b51015e8e2c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "414dcdef-280d-45f8-a6c9-98d7ad09a2e4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebc02af4-5bf0-4ade-9829-501c89a1a55a");
        }
    }
}
