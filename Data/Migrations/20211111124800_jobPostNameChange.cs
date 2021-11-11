using Microsoft.EntityFrameworkCore.Migrations;

namespace careerPortals.Data.Migrations
{
    public partial class jobPostNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Accounts_PostedById",
                table: "JobPosts");

            migrationBuilder.RenameColumn(
                name: "PostedById",
                table: "JobPosts",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_JobPosts_PostedById",
                table: "JobPosts",
                newName: "IX_JobPosts_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Accounts_AccountId",
                table: "JobPosts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Accounts_AccountId",
                table: "JobPosts");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "JobPosts",
                newName: "PostedById");

            migrationBuilder.RenameIndex(
                name: "IX_JobPosts_AccountId",
                table: "JobPosts",
                newName: "IX_JobPosts_PostedById");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Accounts_PostedById",
                table: "JobPosts",
                column: "PostedById",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
