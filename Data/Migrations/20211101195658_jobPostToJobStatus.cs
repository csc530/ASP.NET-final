using Microsoft.EntityFrameworkCore.Migrations;

namespace careerPortals.Data.Migrations
{
    public partial class jobPostToJobStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_JobStatus_JobStatusName",
                table: "JobPosts");

            migrationBuilder.DropIndex(
                name: "IX_JobPosts_JobStatusName",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "JobStatusName",
                table: "JobPosts");

            migrationBuilder.AddColumn<int>(
                name: "JobStatusID",
                table: "JobPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JobPostJobStatus",
                columns: table => new
                {
                    JobStatusName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    jobPostsJobPostID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPostJobStatus", x => new { x.JobStatusName, x.jobPostsJobPostID });
                    table.ForeignKey(
                        name: "FK_JobPostJobStatus_JobPosts_jobPostsJobPostID",
                        column: x => x.jobPostsJobPostID,
                        principalTable: "JobPosts",
                        principalColumn: "JobPostID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobPostJobStatus_JobStatus_JobStatusName",
                        column: x => x.JobStatusName,
                        principalTable: "JobStatus",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPostJobStatus_jobPostsJobPostID",
                table: "JobPostJobStatus",
                column: "jobPostsJobPostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobPostJobStatus");

            migrationBuilder.DropColumn(
                name: "JobStatusID",
                table: "JobPosts");

            migrationBuilder.AddColumn<string>(
                name: "JobStatusName",
                table: "JobPosts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_JobStatusName",
                table: "JobPosts",
                column: "JobStatusName");

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
