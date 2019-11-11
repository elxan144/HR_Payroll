using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_Payroll_App.Migrations
{
    public partial class ColumnName_Exit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Exit",
                table: "WorkPlaces",
                newName: "ExitDate");

            migrationBuilder.RenameColumn(
                name: "Entry",
                table: "WorkPlaces",
                newName: "EntryDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExitDate",
                table: "WorkPlaces",
                newName: "Exit");

            migrationBuilder.RenameColumn(
                name: "EntryDate",
                table: "WorkPlaces",
                newName: "Entry");
        }
    }
}
