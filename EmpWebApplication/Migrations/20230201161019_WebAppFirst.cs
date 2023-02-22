using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpWebApplication.Migrations
{
    public partial class WebAppFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "designation",
                columns: table => new
                {
                    DesignationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesgName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_designation", x => x.DesignationId);
                });

            migrationBuilder.CreateTable(
                name: "skill",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skill", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "emps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_emps_department_DeptId",
                        column: x => x.DeptId,
                        principalTable: "department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_emps_designation_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "designation",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employeeSkills",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeSkills", x => new { x.EmployeeId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_employeeSkills_emps_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "emps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employeeSkills_skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_department_DeptName",
                table: "department",
                column: "DeptName",
                unique: true,
                filter: "[DeptName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_designation_DesgName",
                table: "designation",
                column: "DesgName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employeeSkills_SkillId",
                table: "employeeSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_emps_DeptId",
                table: "emps",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_emps_DesignationId",
                table: "emps",
                column: "DesignationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeeSkills");

            migrationBuilder.DropTable(
                name: "emps");

            migrationBuilder.DropTable(
                name: "skill");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "designation");
        }
    }
}
