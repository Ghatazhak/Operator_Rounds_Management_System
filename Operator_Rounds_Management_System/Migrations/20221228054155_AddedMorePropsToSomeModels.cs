using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OperatorRoundsManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedMorePropsToSomeModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_AspNetUsers_AppUserId1",
                table: "Rounds");

            migrationBuilder.RenameColumn(
                name: "AppUserId1",
                table: "Rounds",
                newName: "OperatorsId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Rounds",
                newName: "OperatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Rounds_AppUserId1",
                table: "Rounds",
                newName: "IX_Rounds_OperatorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_AspNetUsers_OperatorsId",
                table: "Rounds",
                column: "OperatorsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_AspNetUsers_OperatorsId",
                table: "Rounds");

            migrationBuilder.RenameColumn(
                name: "OperatorsId",
                table: "Rounds",
                newName: "AppUserId1");

            migrationBuilder.RenameColumn(
                name: "OperatorId",
                table: "Rounds",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Rounds_OperatorsId",
                table: "Rounds",
                newName: "IX_Rounds_AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_AspNetUsers_AppUserId1",
                table: "Rounds",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
