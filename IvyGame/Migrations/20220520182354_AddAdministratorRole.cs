using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IvyGame.Migrations
{
    public partial class AddAdministratorRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b399a57a-f03d-4b24-9485-474aafef0ca6", "1d543e81-3325-4535-b861-f65f63dab4fb", "Administrator", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b399a57a-f03d-4b24-9485-474aafef0ca6");
        }
    }
}
