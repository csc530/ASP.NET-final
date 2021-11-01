using Microsoft.EntityFrameworkCore.Migrations;

namespace careerPortals.Data.Migrations
{
    public partial class renames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Accounts_AccountId",
                table: "JobPosts");

            migrationBuilder.DropTable(
                name: "JobPostJobStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobStatus",
                table: "JobStatus");

            migrationBuilder.DropIndex(
                name: "IX_JobPosts_AccountId",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "JobStatusID",
                table: "JobPosts");

            migrationBuilder.RenameColumn(
                name: "JobPostID",
                table: "JobPosts",
                newName: "JobPostId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "JobStatus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "JobStatusId",
                table: "JobStatus",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobStatus",
                table: "JobStatus",
                column: "JobStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobStatus",
                table: "JobStatus");

            migrationBuilder.DropColumn(
                name: "JobStatusId",
                table: "JobStatus");

            migrationBuilder.RenameColumn(
                name: "JobPostId",
                table: "JobPosts",
                newName: "JobPostID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "JobStatus",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "JobPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobStatusID",
                table: "JobPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobStatus",
                table: "JobStatus",
                column: "Name");

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
                name: "IX_JobPosts_AccountId",
                table: "JobPosts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPostJobStatus_jobPostsJobPostID",
                table: "JobPostJobStatus",
                column: "jobPostsJobPostID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Accounts_AccountId",
                table: "JobPosts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
