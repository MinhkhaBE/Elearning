using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Learning.Migrations
{
    public partial class AddDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Idaccount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Createdate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Idaccount);
                });

            migrationBuilder.CreateTable(
                name: "ClassDetail",
                columns: table => new
                {
                    Idclassdetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Passwordclass = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Teacher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lesson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Studytime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Schedule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassDetail", x => x.Idclassdetail);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Idsubject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namesubject = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Idsubject);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Idadmin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nameadmin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Idaccount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Idadmin);
                    table.ForeignKey(
                        name: "fk_admin_account",
                        column: x => x.Idaccount,
                        principalTable: "Account",
                        principalColumn: "Idaccount",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Idteacher = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nameteacher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Idaccount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Idteacher);
                    table.ForeignKey(
                        name: "FK_Teacher_Account",
                        column: x => x.Idaccount,
                        principalTable: "Account",
                        principalColumn: "Idaccount",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Idclass = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nameclass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Semester = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idclassdetail = table.Column<int>(type: "int", nullable: false),
                    Idsubject = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Idclass);
                    table.ForeignKey(
                        name: "FK_Class_Classdetail",
                        column: x => x.Idclassdetail,
                        principalTable: "ClassDetail",
                        principalColumn: "Idclassdetail",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Class_Subject",
                        column: x => x.Idsubject,
                        principalTable: "Subject",
                        principalColumn: "Idsubject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Idtest = table.Column<int>(type: "int", nullable: false),
                    Nametest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Createdate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Score = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idsubject = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Idtest);
                    table.ForeignKey(
                        name: "FK_Test_Subject",
                        column: x => x.Idtest,
                        principalTable: "Subject",
                        principalColumn: "Idsubject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Idstudent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namestudent = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Idaccount = table.Column<int>(type: "int", nullable: false),
                    ClassIdclass = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Idstudent);
                    table.ForeignKey(
                        name: "FK_Student_account",
                        column: x => x.Idaccount,
                        principalTable: "Account",
                        principalColumn: "Idaccount",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Class_ClassIdclass",
                        column: x => x.ClassIdclass,
                        principalTable: "Class",
                        principalColumn: "Idclass",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Scorelearning",
                columns: table => new
                {
                    Idscore = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scorediligence = table.Column<double>(type: "float", nullable: false),
                    Scoreoral = table.Column<double>(type: "float", nullable: false),
                    Score15min = table.Column<double>(type: "float", nullable: false),
                    Scorecorfficient2 = table.Column<double>(type: "float", nullable: false),
                    Scorecorfficient3 = table.Column<double>(type: "float", nullable: false),
                    Mediumscore = table.Column<double>(type: "float", nullable: false),
                    Totalscore = table.Column<double>(type: "float", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updatedate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Idstudent = table.Column<int>(type: "int", nullable: false),
                    Idsubject = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scorelearning", x => x.Idscore);
                    table.ForeignKey(
                        name: "FK_Score_Student",
                        column: x => x.Idstudent,
                        principalTable: "Student",
                        principalColumn: "Idstudent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Score_Subject",
                        column: x => x.Idsubject,
                        principalTable: "Subject",
                        principalColumn: "Idsubject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Idaccount",
                table: "Admin",
                column: "Idaccount",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Class_Idclassdetail",
                table: "Class",
                column: "Idclassdetail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Class_Idsubject",
                table: "Class",
                column: "Idsubject");

            migrationBuilder.CreateIndex(
                name: "IX_Scorelearning_Idstudent",
                table: "Scorelearning",
                column: "Idstudent",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scorelearning_Idsubject",
                table: "Scorelearning",
                column: "Idsubject");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassIdclass",
                table: "Student",
                column: "ClassIdclass");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Idaccount",
                table: "Student",
                column: "Idaccount",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_Idaccount",
                table: "Teacher",
                column: "Idaccount",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Scorelearning");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "ClassDetail");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
