using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class haolaoshi4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Added_time",
                table: "Area",
                newName: "added_time");

            migrationBuilder.AddColumn<DateTime>(
                name: "added_time",
                table: "UsualScoreItem",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "added_time",
                table: "UsualScoreHistory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "added_time",
                table: "UsualScore",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "added_time",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "added_time",
                table: "Teacher",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "added_time",
                table: "Student",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "added_time",
                table: "Score",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "added_time",
                table: "Post",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "added_time",
                table: "OnlineResume",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "added_time",
                table: "Major",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "added_time",
                table: "Interview",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "added_time",
                table: "Images",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "added_time",
                table: "Course",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "added_time",
                table: "Company",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "added_time",
                table: "Classs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "added_time",
                table: "Chapter",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "added_time",
                table: "UsualScoreItem");

            migrationBuilder.DropColumn(
                name: "added_time",
                table: "UsualScoreHistory");

            migrationBuilder.DropColumn(
                name: "added_time",
                table: "UsualScore");

            migrationBuilder.DropColumn(
                name: "added_time",
                table: "User");

            migrationBuilder.DropColumn(
                name: "added_time",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "added_time",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "added_time",
                table: "Score");

            migrationBuilder.DropColumn(
                name: "added_time",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "added_time",
                table: "OnlineResume");

            migrationBuilder.DropColumn(
                name: "added_time",
                table: "Major");

            migrationBuilder.DropColumn(
                name: "added_time",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "added_time",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "added_time",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "added_time",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "added_time",
                table: "Classs");

            migrationBuilder.DropColumn(
                name: "added_time",
                table: "Chapter");

            migrationBuilder.RenameColumn(
                name: "added_time",
                table: "Area",
                newName: "Added_time");
        }
    }
}
