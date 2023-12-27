using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalTools.Migrations
{
    /// <inheritdoc />
    public partial class editTableProductToAddCostForEachOneAndAddDateinTableforOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "users",
                newName: "location");

            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "users",
                newName: "City");
        }
    }
}
