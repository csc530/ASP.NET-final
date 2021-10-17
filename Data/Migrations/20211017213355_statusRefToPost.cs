using Microsoft.EntityFrameworkCore.Migrations;

namespace careerPortals.Data.Migrations
{
    public partial class statusRefToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_JobStatus_JobStatusName",
                table: "JobPosts");

            migrationBuilder.AlterColumn<string>(
                name: "JobStatusName",
                table: "JobPosts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_JobStatus_JobStatusName",
                table: "JobPosts",
                column: "JobStatusName",
                principalTable: "JobStatus",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_JobStatus_JobStatusName",
                table: "JobPosts");

            migrationBuilder.AlterColumn<string>(
                name: "JobStatusName",
                table: "JobPosts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_JobStatus_JobStatusName",
                table: "JobPosts",
                column: "JobStatusName",
                principalTable: "JobStatus",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
