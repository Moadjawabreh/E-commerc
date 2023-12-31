﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalTools.Migrations
{
    /// <inheritdoc />
    public partial class addCostToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "orders");
        }
    }
}
