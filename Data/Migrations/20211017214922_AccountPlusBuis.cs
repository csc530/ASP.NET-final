using Microsoft.EntityFrameworkCore.Migrations;

namespace careerPortals.Data.Migrations
{
    public partial class AccountPlusBuis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Buisness",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Buisness",
                table: "Accounts");
        }
    }
}
