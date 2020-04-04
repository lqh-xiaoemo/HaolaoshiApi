using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class haolaoshi9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    added_time = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Pic = table.Column<string>(nullable: true),
                    Intro = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    Attach = table.Column<string>(nullable: true),
                    Tag = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Article_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Article_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Article_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseRes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    added_time = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Pic = table.Column<string>(nullable: true),
                    Intro = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    Attach = table.Column<string>(nullable: true),
                    Tag = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseRes_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseRes_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseRes_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseRes_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_CategoryId",
                table: "Article",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_StudentId",
                table: "Article",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_TeacherId",
                table: "Article",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_UserId",
                table: "Article",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRes_CategoryId",
                table: "CourseRes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRes_StudentId",
                table: "CourseRes",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRes_TeacherId",
                table: "CourseRes",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRes_UserId",
                table: "CourseRes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "CourseRes");
        }
    }
}
