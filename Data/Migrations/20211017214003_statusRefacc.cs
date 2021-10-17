using Microsoft.EntityFrameworkCore.Migrations;

namespace careerPortals.Data.Migrations
{
    public partial class statusRefacc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "FufilledByAccountID",
                table: "JobPosts");

            migrationBuilder.AlterColumn<int>(
                name: "PostedByAccountID",
                table: "JobPosts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Accounts_PostedByAccountID",
                table: "JobPosts",
                column: "PostedByAccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Accounts_PostedByAccountID",
                table: "JobPosts");

            migrationBuilder.AlterColumn<int>(
                name: "PostedByAccountID",
                table: "JobPosts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FufilledByAccountID",
                table: "JobPosts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_FufilledByAccountID",
                table: "JobPosts",
                column: "FufilledByAccountID");

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
    }
}
