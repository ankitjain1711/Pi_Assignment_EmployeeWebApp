using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpWebApplication.Migrations
{
    public partial class Skill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "skill",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_skill_EmployeeId",
                table: "skill",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_skill_emps_EmployeeId",
                table: "skill",
                column: "EmployeeId",
                principalTable: "emps",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_skill_emps_EmployeeId",
                table: "skill");

            migrationBuilder.DropIndex(
                name: "IX_skill_EmployeeId",
                table: "skill");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "skill");
        }
    }
}
