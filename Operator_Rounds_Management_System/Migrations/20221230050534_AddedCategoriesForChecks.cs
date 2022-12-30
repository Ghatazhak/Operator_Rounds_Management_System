using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OperatorRoundsManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategoriesForChecks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CheckCategoryId",
                table: "Checks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CheckCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checks_CheckCategoryId",
                table: "Checks",
                column: "CheckCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checks_CheckCategory_CheckCategoryId",
                table: "Checks",
                column: "CheckCategoryId",
                principalTable: "CheckCategory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checks_CheckCategory_CheckCategoryId",
                table: "Checks");

            migrationBuilder.DropTable(
                name: "CheckCategory");

            migrationBuilder.DropIndex(
                name: "IX_Checks_CheckCategoryId",
                table: "Checks");

            migrationBuilder.DropColumn(
                name: "CheckCategoryId",
                table: "Checks");
        }
    }
}
