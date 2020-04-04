using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class haolaoshi6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Classs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MajorId",
                table: "Classs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    added_time = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Pic = table.Column<string>(nullable: true),
                    Intro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classs_GradeId",
                table: "Classs",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Classs_MajorId",
                table: "Classs",
                column: "MajorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classs_Grade_GradeId",
                table: "Classs",
                column: "GradeId",
                principalTable: "Grade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Classs_Major_MajorId",
                table: "Classs",
                column: "MajorId",
                principalTable: "Major",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classs_Grade_GradeId",
                table: "Classs");

            migrationBuilder.DropForeignKey(
                name: "FK_Classs_Major_MajorId",
                table: "Classs");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropIndex(
                name: "IX_Classs_GradeId",
                table: "Classs");

            migrationBuilder.DropIndex(
                name: "IX_Classs_MajorId",
                table: "Classs");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Classs");

            migrationBuilder.DropColumn(
                name: "MajorId",
                table: "Classs");
        }
    }
}
