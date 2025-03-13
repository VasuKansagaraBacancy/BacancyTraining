using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_CORE_Day4.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Human Resources" },
                    { 2, "Information Technology" },
                    { 3, "Finance" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "ProjectName", "StartDate" },
                values: new object[,]
                {
                    { 1, "HR Onboarding System", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Website Redesign", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Financial Audit Automation", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DepartmentId", "Email", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Vasu.kansagara@bacancy.com", "Vasu Kansagara" },
                    { 2, 2, "bob.smith@example.com", "Bob Smith" },
                    { 3, 2, "charlie.brown@example.com", "Charlie Brown" },
                    { 4, 3, "diana.prince@example.com", "Diana Prince" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeProjects",
                columns: new[] { "EmployeeId", "ProjectId", "Role" },
                values: new object[,]
                {
                    { 1, 1, "Project Manager" },
                    { 2, 2, "Lead Developer" },
                    { 2, 3, "Data Engineer" },
                    { 3, 2, "UI/UX Designer" },
                    { 4, 3, "Financial Analyst" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3);
        }
    }
}
