using Microsoft.EntityFrameworkCore.Migrations;

namespace careerPortals.Data.Migrations
{
    public partial class NoFamilialReferences3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "JobPosts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FufilledByAccountID",
                table: "JobPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Fulfilled",
                table: "JobPosts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JobName",
                table: "JobPosts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "JobStatus",
                table: "JobPosts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PostedByAccountID",
                table: "JobPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_FufilledByAccountID",
                table: "JobPosts",
                column: "FufilledByAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_PostedByAccountID",
                table: "JobPosts",
                column: "PostedByAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Accounts_FufilledByAccountID",
                table: "JobPosts",
                column: "FufilledByAccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Accounts_PostedByAccountID",
                table: "JobPosts",
                column: "PostedByAccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Accounts_FufilledByAccountID",
                table: "JobPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Accounts_PostedByAccountID",
                table: "JobPosts");

            migrationBuilder.DropIndex(
                name: "IX_JobPosts_FufilledByAccountID",
                table: "JobPosts");

            migrationBuilder.DropIndex(
                name: "IX_JobPosts_PostedByAccountID",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "FufilledByAccountID",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "Fulfilled",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "JobName",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "JobStatus",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "PostedByAccountID",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Accounts");
        }
    }
}
