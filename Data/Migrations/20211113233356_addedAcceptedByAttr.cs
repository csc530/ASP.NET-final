using Microsoft.EntityFrameworkCore.Migrations;

namespace careerPortals.Data.Migrations
{
    public partial class addedAcceptedByAttr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcceptedById",
                table: "JobPosts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_AcceptedById",
                table: "JobPosts",
                column: "AcceptedById");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Accounts_AcceptedById",
                table: "JobPosts",
                column: "AcceptedById",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Accounts_AcceptedById",
                table: "JobPosts");

            migrationBuilder.DropIndex(
                name: "IX_JobPosts_AcceptedById",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "AcceptedById",
                table: "JobPosts");
        }
    }
}
