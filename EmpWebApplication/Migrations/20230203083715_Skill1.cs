using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpWebApplication.Migrations
{
    public partial class Skill1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "EmployeeSkill",
                columns: table => new
                {
                    employeesId = table.Column<int>(type: "int", nullable: false),
                    skillsSkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkill", x => new { x.employeesId, x.skillsSkillId });
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_emps_employeesId",
                        column: x => x.employeesId,
                        principalTable: "emps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_skill_skillsSkillId",
                        column: x => x.skillsSkillId,
                        principalTable: "skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_skillsSkillId",
                table: "EmployeeSkill",
                column: "skillsSkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSkill");

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
    }
}
