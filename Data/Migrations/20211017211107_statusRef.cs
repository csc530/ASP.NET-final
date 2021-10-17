using Microsoft.EntityFrameworkCore.Migrations;

namespace careerPortals.Data.Migrations
{
    public partial class statusRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "JobPosts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "JobPosts");
        }
    }
}
