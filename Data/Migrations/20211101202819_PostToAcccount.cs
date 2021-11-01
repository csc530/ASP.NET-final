using Microsoft.EntityFrameworkCore.Migrations;

namespace careerPortals.Data.Migrations
{
    public partial class PostToAcccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostedById",
                table: "JobPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_PostedById",
                table: "JobPosts",
                column: "PostedById");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Accounts_PostedById",
                table: "JobPosts",
                column: "PostedById",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Accounts_PostedById",
                table: "JobPosts");

            migrationBuilder.DropIndex(
                name: "IX_JobPosts_PostedById",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "PostedById",
                table: "JobPosts");
        }
    }
}
