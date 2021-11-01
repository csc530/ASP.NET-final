using Microsoft.EntityFrameworkCore.Migrations;

namespace careerPortals.Data.Migrations
{
    public partial class StatusToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobStatusId",
                table: "JobPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "JobPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_JobStatusId",
                table: "JobPosts",
                column: "JobStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_JobStatus_JobStatusId",
                table: "JobPosts",
                column: "JobStatusId",
                principalTable: "JobStatus",
                principalColumn: "JobStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_JobStatus_JobStatusId",
                table: "JobPosts");

            migrationBuilder.DropIndex(
                name: "IX_JobPosts_JobStatusId",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "JobStatusId",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "JobPosts");
        }
    }
}
