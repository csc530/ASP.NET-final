using Microsoft.EntityFrameworkCore.Migrations;

namespace careerPortals.Data.Migrations
{
    public partial class jobStatusClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobStatus",
                table: "JobPosts");

            migrationBuilder.AddColumn<string>(
                name: "JobStatusName",
                table: "JobPosts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JobStatus",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStatus", x => x.Name);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_JobStatus_JobStatusName",
                table: "JobPosts");

            migrationBuilder.DropTable(
                name: "JobStatus");

            migrationBuilder.DropIndex(
                name: "IX_JobPosts_JobStatusName",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "JobStatusName",
                table: "JobPosts");

            migrationBuilder.AddColumn<string>(
                name: "JobStatus",
                table: "JobPosts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
