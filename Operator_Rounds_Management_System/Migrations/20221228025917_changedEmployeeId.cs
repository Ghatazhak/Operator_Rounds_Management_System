using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OperatorRoundsManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class changedEmployeeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "AspNetUsers",
                newName: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "AspNetUsers",
                newName: "EmployeeID");
        }
    }
}
