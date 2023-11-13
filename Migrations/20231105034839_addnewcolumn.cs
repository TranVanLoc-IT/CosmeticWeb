using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCosmetic.Migrations
{
    public partial class addnewcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         
            migrationBuilder.AddColumn<DateTime>(
                name: "ngaylap",
                table: "THANHTOAN",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ngaylap",
                table: "THANHTOAN");

            
        }
    }
}
