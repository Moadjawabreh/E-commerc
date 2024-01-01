using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalTools.Migrations
{
    /// <inheritdoc />
    public partial class editSomeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ImageUrl", "phoneNumber" },
                values: new object[] { "/Image/mo'men.jpg", "0796959979" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ImageUrl", "phoneNumber" },
                values: new object[] { "/Image/mo'men.jpg", "0796959979" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ImageUrl", "phoneNumber" },
                values: new object[] { "/Image/mo'men.png", null });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ImageUrl", "phoneNumber" },
                values: new object[] { "/Image/mo'men.png", null });
        }
    }
}
