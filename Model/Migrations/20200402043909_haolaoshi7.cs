using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class haolaoshi7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Chapter",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Chapter",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Chapter",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    added_time = table.Column<DateTime>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Pic = table.Column<string>(nullable: true),
                    Intro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_CategoryId",
                table: "Course",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_StudentId",
                table: "Course",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_TeacherId",
                table: "Course",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_UserId",
                table: "Course",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_StudentId",
                table: "Chapter",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_TeacherId",
                table: "Chapter",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_UserId",
                table: "Chapter",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                table: "Category",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapter_Student_StudentId",
                table: "Chapter",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chapter_Teacher_TeacherId",
                table: "Chapter",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chapter_User_UserId",
                table: "Chapter",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Category_CategoryId",
                table: "Course",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Student_StudentId",
                table: "Course",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Teacher_TeacherId",
                table: "Course",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_User_UserId",
                table: "Course",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapter_Student_StudentId",
                table: "Chapter");

            migrationBuilder.DropForeignKey(
                name: "FK_Chapter_Teacher_TeacherId",
                table: "Chapter");

            migrationBuilder.DropForeignKey(
                name: "FK_Chapter_User_UserId",
                table: "Chapter");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Category_CategoryId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Student_StudentId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Teacher_TeacherId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_User_UserId",
                table: "Course");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Course_CategoryId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_StudentId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_TeacherId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_UserId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Chapter_StudentId",
                table: "Chapter");

            migrationBuilder.DropIndex(
                name: "IX_Chapter_TeacherId",
                table: "Chapter");

            migrationBuilder.DropIndex(
                name: "IX_Chapter_UserId",
                table: "Chapter");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Chapter");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Chapter");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Chapter");
        }
    }
}
