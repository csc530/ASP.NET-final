using Microsoft.EntityFrameworkCore.Migrations;

namespace careerPortals.Data.Migrations
{
    public partial class renames2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_JobStatus_JobStatusId",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "JobPosts");

            migrationBuilder.AlterColumn<int>(
                name: "JobStatusId",
                table: "JobPosts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_JobStatus_JobStatusId",
                table: "JobPosts",
                column: "JobStatusId",
                principalTable: "JobStatus",
                principalColumn: "JobStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_JobStatus_JobStatusId",
                table: "JobPosts");

            migrationBuilder.AlterColumn<int>(
                name: "JobStatusId",
                table: "JobPosts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "JobPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_JobStatus_JobStatusId",
                table: "JobPosts",
                column: "JobStatusId",
                principalTable: "JobStatus",
                principalColumn: "JobStatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
