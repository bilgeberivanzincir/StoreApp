using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApp.Migrations
{
    /// <inheritdoc />
    public partial class IdentityRoleSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16d9b953-288b-47eb-9523-f57d8222e5c3", null, "Editor", "EDITOR" },
                    { "6c2eb470-f68d-4517-8115-42e5eb93c74e", null, "Admin", "ADMIN" },
                    { "dd9e7956-8dbc-4689-9ed2-926dbb56d8cb", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16d9b953-288b-47eb-9523-f57d8222e5c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c2eb470-f68d-4517-8115-42e5eb93c74e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd9e7956-8dbc-4689-9ed2-926dbb56d8cb");
        }
    }
}
