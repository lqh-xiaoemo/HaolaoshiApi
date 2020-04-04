using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class haolaoshi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Chapter",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_CourseId",
                table: "Chapter",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapter_Course_CourseId",
                table: "Chapter",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapter_Course_CourseId",
                table: "Chapter");

            migrationBuilder.DropIndex(
                name: "IX_Chapter_CourseId",
                table: "Chapter");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Chapter");
        }
    }
}
