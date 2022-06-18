using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Learning.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Classdetail",
                table: "Class");

            migrationBuilder.DropIndex(
                name: "IX_Class_Idclassdetail",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "Idclassdetail",
                table: "Class");

            migrationBuilder.AddColumn<int>(
                name: "Idclass",
                table: "ClassDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClassDetail_Idclass",
                table: "ClassDetail",
                column: "Idclass",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Classdetail",
                table: "ClassDetail",
                column: "Idclass",
                principalTable: "Class",
                principalColumn: "Idclass",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Classdetail",
                table: "ClassDetail");

            migrationBuilder.DropIndex(
                name: "IX_ClassDetail_Idclass",
                table: "ClassDetail");

            migrationBuilder.DropColumn(
                name: "Idclass",
                table: "ClassDetail");

            migrationBuilder.AddColumn<int>(
                name: "Idclassdetail",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Class_Idclassdetail",
                table: "Class",
                column: "Idclassdetail",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Classdetail",
                table: "Class",
                column: "Idclassdetail",
                principalTable: "ClassDetail",
                principalColumn: "Idclassdetail",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
