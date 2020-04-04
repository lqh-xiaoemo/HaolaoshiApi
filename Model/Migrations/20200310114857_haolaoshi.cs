using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class haolaoshi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Expanded = table.Column<bool>(nullable: false),
                    Common = table.Column<bool>(nullable: false),
                    Added_time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Area_Area_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chapter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Pic = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Intro = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapter_Chapter_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Pic = table.Column<string>(nullable: true),
                    Post = table.Column<string>(nullable: true),
                    Salary = table.Column<string>(nullable: true),
                    Num = table.Column<int>(nullable: true),
                    Resume_time = table.Column<DateTime>(nullable: true),
                    Interview_time = table.Column<DateTime>(nullable: true),
                    Interview_way = table.Column<string>(nullable: true),
                    Scale = table.Column<int>(nullable: true),
                    Memo = table.Column<string>(nullable: true),
                    Attachment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Pic = table.Column<string>(nullable: true),
                    Textbook = table.Column<string>(nullable: true),
                    Intro = table.Column<string>(nullable: true),
                    Attach = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: false),
                    Size = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Major",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Pic = table.Column<string>(nullable: true),
                    Intro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Major", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsualScoreItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    Intro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsualScoreItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 20, nullable: false),
                    Pswd = table.Column<string>(maxLength: 40, nullable: false),
                    Realname = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: false),
                    Tel = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    QQ = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    Nation = table.Column<string>(nullable: true),
                    IDCard = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    AreaId = table.Column<int>(nullable: true),
                    Available_balance = table.Column<double>(nullable: true),
                    Integral = table.Column<int>(nullable: false),
                    Gold = table.Column<int>(nullable: false),
                    Friend_num = table.Column<int>(nullable: false),
                    Attention_num = table.Column<int>(nullable: false),
                    Attentioned_num = table.Column<int>(nullable: false),
                    Credit = table.Column<int>(nullable: false),
                    Last_login_date = table.Column<DateTime>(nullable: false),
                    Login_date = table.Column<DateTime>(nullable: false),
                    Last_login_ip = table.Column<string>(nullable: true),
                    Login_ip = table.Column<string>(nullable: true),
                    Login_count = table.Column<int>(nullable: false),
                    IMEI = table.Column<string>(nullable: true),
                    Added_time = table.Column<DateTime>(nullable: false),
                    Sn = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 20, nullable: false),
                    Pswd = table.Column<string>(maxLength: 40, nullable: false),
                    Realname = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: false),
                    Tel = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    QQ = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    Nation = table.Column<string>(nullable: true),
                    IDCard = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    AreaId = table.Column<int>(nullable: true),
                    Available_balance = table.Column<double>(nullable: true),
                    Integral = table.Column<int>(nullable: false),
                    Gold = table.Column<int>(nullable: false),
                    Friend_num = table.Column<int>(nullable: false),
                    Attention_num = table.Column<int>(nullable: false),
                    Attentioned_num = table.Column<int>(nullable: false),
                    Credit = table.Column<int>(nullable: false),
                    Last_login_date = table.Column<DateTime>(nullable: false),
                    Login_date = table.Column<DateTime>(nullable: false),
                    Last_login_ip = table.Column<string>(nullable: true),
                    Login_ip = table.Column<string>(nullable: true),
                    Login_count = table.Column<int>(nullable: false),
                    IMEI = table.Column<string>(nullable: true),
                    Added_time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Interview",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_name = table.Column<string>(nullable: false),
                    Student_class = table.Column<string>(nullable: true),
                    Interviewed = table.Column<bool>(nullable: false),
                    Ask = table.Column<string>(nullable: true),
                    Result = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interview_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Pic = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Classs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Pic = table.Column<string>(nullable: true),
                    Intro = table.Column<string>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classs_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 20, nullable: false),
                    Pswd = table.Column<string>(maxLength: 40, nullable: false),
                    Realname = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: false),
                    Tel = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    QQ = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    Nation = table.Column<string>(nullable: true),
                    IDCard = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    AreaId = table.Column<int>(nullable: true),
                    Available_balance = table.Column<double>(nullable: true),
                    Integral = table.Column<int>(nullable: false),
                    Gold = table.Column<int>(nullable: false),
                    Friend_num = table.Column<int>(nullable: false),
                    Attention_num = table.Column<int>(nullable: false),
                    Attentioned_num = table.Column<int>(nullable: false),
                    Credit = table.Column<int>(nullable: false),
                    Last_login_date = table.Column<DateTime>(nullable: false),
                    Login_date = table.Column<DateTime>(nullable: false),
                    Last_login_ip = table.Column<string>(nullable: true),
                    Login_ip = table.Column<string>(nullable: true),
                    Login_count = table.Column<int>(nullable: false),
                    IMEI = table.Column<string>(nullable: true),
                    Added_time = table.Column<DateTime>(nullable: false),
                    Sn = table.Column<string>(maxLength: 40, nullable: false),
                    ClasssId = table.Column<int>(nullable: false),
                    Father = table.Column<string>(nullable: true),
                    FathertTel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Classs_ClasssId",
                        column: x => x.ClasssId,
                        principalTable: "Classs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnlineResume",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Post = table.Column<string>(nullable: true),
                    Salary = table.Column<string>(nullable: true),
                    num = table.Column<int>(nullable: true),
                    Interview_time = table.Column<DateTime>(nullable: true),
                    Start_time = table.Column<string>(nullable: true),
                    Company_pic = table.Column<string>(nullable: true),
                    Arrival_time = table.Column<string>(nullable: true),
                    Company_addr = table.Column<string>(nullable: true),
                    Interviewer = table.Column<string>(nullable: true),
                    Interviewer_contact = table.Column<string>(nullable: true),
                    Ask = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true),
                    Interviewed_time = table.Column<string>(nullable: true),
                    Result = table.Column<bool>(nullable: false),
                    Resulted_time = table.Column<string>(nullable: true),
                    Memo = table.Column<string>(nullable: true),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineResume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineResume_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: true),
                    Value = table.Column<double>(nullable: false),
                    Intro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Score_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Score_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsualScore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: true),
                    Score = table.Column<double>(nullable: false),
                    Intro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsualScore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsualScore_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsualScore_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsualScoreHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScoreId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    Intro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsualScoreHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsualScoreHistory_UsualScore_ScoreId",
                        column: x => x.ScoreId,
                        principalTable: "UsualScore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Area_ParentId",
                table: "Area",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_ParentId",
                table: "Chapter",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Classs_TeacherId",
                table: "Classs",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_CompanyId",
                table: "Interview",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineResume_StudentId",
                table: "OnlineResume",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_CompanyId",
                table: "Post",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_CourseId",
                table: "Score",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_StudentId",
                table: "Score",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_AreaId",
                table: "Student",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClasssId",
                table: "Student",
                column: "ClasssId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_AreaId",
                table: "Teacher",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_User_AreaId",
                table: "User",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsualScore_CourseId",
                table: "UsualScore",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UsualScore_StudentId",
                table: "UsualScore",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_UsualScoreHistory_ScoreId",
                table: "UsualScoreHistory",
                column: "ScoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chapter");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Interview");

            migrationBuilder.DropTable(
                name: "Major");

            migrationBuilder.DropTable(
                name: "OnlineResume");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UsualScoreHistory");

            migrationBuilder.DropTable(
                name: "UsualScoreItem");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "UsualScore");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Classs");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Area");
        }
    }
}
