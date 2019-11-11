using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_Payroll_App.Migrations
{
    public partial class Workplace_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkPlaces_EmployeeId",
                table: "WorkPlaces");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlaces_EmployeeId",
                table: "WorkPlaces",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkPlaces_EmployeeId",
                table: "WorkPlaces");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlaces_EmployeeId",
                table: "WorkPlaces",
                column: "EmployeeId",
                unique: true);
        }
    }
}
