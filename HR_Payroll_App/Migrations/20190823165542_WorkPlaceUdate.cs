using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_Payroll_App.Migrations
{
    public partial class WorkPlaceUdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkPlaces_EmployeeId",
                table: "WorkPlaces");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OldWorkPlaces",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FireReason",
                table: "OldWorkPlaces",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlaces_EmployeeId",
                table: "WorkPlaces",
                column: "EmployeeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkPlaces_EmployeeId",
                table: "WorkPlaces");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OldWorkPlaces",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FireReason",
                table: "OldWorkPlaces",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlaces_EmployeeId",
                table: "WorkPlaces",
                column: "EmployeeId");
        }
    }
}
