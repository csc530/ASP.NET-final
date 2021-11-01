using Microsoft.EntityFrameworkCore.Migrations;

namespace careerPortals.Data.Migrations
{
    public partial class accountToJobpostsBuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobName",
                table: "JobPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PostedById",
                table: "JobPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PostedById1",
                table: "JobPosts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_PostedById1",
                table: "JobPosts",
                column: "PostedById1");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_AspNetUsers_PostedById1",
                table: "JobPosts",
                column: "PostedById1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_AspNetUsers_PostedById1",
                table: "JobPosts");

            migrationBuilder.DropIndex(
                name: "IX_JobPosts_PostedById1",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "JobName",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "PostedById",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "PostedById1",
                table: "JobPosts");
        }
    }
}
