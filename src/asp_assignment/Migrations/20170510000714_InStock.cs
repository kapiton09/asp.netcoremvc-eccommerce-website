using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace asp_assignment.Migrations
{
    public partial class InStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InStock",
                table: "Products",
                nullable: false,
                defaultValue: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InStock",
                table: "Products");
        }
    }
}
