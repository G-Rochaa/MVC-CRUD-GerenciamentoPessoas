using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GerenciamentoDePessoas.Migrations
{
    /// <inheritdoc />
    public partial class Implementando_Role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ab6dc1dd-2608-4768-b924-8978ad63a39c", null, "operador", "OPERADOR" },
                    { "b36df00d-c9dd-4e00-be31-8bf524df992b", null, "administrador", "ADMINISTRADOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab6dc1dd-2608-4768-b924-8978ad63a39c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b36df00d-c9dd-4e00-be31-8bf524df992b");
        }
    }
}
