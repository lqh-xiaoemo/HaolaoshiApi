using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class haolaoshi1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Attach",
                table: "Chapter",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attach",
                table: "Chapter");
        }
    }
}
