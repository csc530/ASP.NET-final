using Microsoft.EntityFrameworkCore.Migrations;

namespace careerPortals.Data.Migrations
{
    public partial class accountUnSubClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_AspNetUsers_PostedById1",
                table: "JobPosts");

            migrationBuilder.DropIndex(
                name: "IX_JobPosts_PostedById1",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "PostedById",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "PostedById1",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Buisness",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "JobPosts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Buisness = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_AccountId",
                table: "JobPosts",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Accounts_AccountId",
                table: "JobPosts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Accounts_AccountId",
                table: "JobPosts");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_JobPosts_AccountId",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "JobPosts");

            migrationBuilder.AddColumn<int>(
                name: "PostedById",
                table: "JobPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PostedById1",
                table: "JobPosts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Buisness",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_PostedById1",
                table: "JobPosts",
                column: "PostedById1");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_AspNetUsers_PostedById1",
                table: "JobPosts",
                column: "PostedById1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
