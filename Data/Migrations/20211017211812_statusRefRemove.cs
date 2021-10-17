using Microsoft.EntityFrameworkCore.Migrations;

namespace careerPortals.Data.Migrations
{
    public partial class statusRefRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "JobPosts");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "JobPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "JobPosts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "JobPosts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
