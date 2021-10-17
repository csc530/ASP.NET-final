using Microsoft.EntityFrameworkCore.Migrations;

namespace careerPortals.Data.Migrations
{
    public partial class statusRefAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Accounts_PostedByAccountID",
                table: "JobPosts");

            migrationBuilder.RenameColumn(
                name: "PostedByAccountID",
                table: "JobPosts",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_JobPosts_PostedByAccountID",
                table: "JobPosts",
                newName: "IX_JobPosts_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Accounts_AccountId",
                table: "JobPosts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountID",
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
                newName: "PostedByAccountID");

            migrationBuilder.RenameIndex(
                name: "IX_JobPosts_AccountId",
                table: "JobPosts",
                newName: "IX_JobPosts_PostedByAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Accounts_PostedByAccountID",
                table: "JobPosts",
                column: "PostedByAccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
