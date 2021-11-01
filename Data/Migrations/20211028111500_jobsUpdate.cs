using Microsoft.EntityFrameworkCore.Migrations;

namespace careerPortals.Data.Migrations
{
    public partial class jobsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Accounts_AccountId",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "Fulfilled",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "JobName",
                table: "JobPosts");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "JobPosts",
                newName: "AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_JobPosts_AccountId",
                table: "JobPosts",
                newName: "IX_JobPosts_AccountID");

            migrationBuilder.AlterColumn<int>(
                name: "AccountID",
                table: "JobPosts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Accounts_AccountID",
                table: "JobPosts",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Accounts_AccountID",
                table: "JobPosts");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "JobPosts",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_JobPosts_AccountID",
                table: "JobPosts",
                newName: "IX_JobPosts_AccountId");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "JobPosts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "JobPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Accounts_AccountId",
                table: "JobPosts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
