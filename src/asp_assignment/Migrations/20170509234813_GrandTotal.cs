using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace asp_assignment.Migrations
{
    public partial class GrandTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "GrandTotal",
                table: "Orders",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GrandTotal",
                table: "Orders");
        }
    }
}
