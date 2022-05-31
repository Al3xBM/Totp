using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TotpAPI.Migrations
{
    public partial class NewIdeea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Totp",
                table: "UserVaults",
                newName: "Secret");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Secret",
                table: "UserVaults",
                newName: "Totp");
        }
    }
}
