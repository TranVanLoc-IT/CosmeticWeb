using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCosmetic.Migrations
{
    public partial class addNgayGiaoDatInHdVanchuyen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ngaydathang",
                table: "HOADONVANCHUYEN",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ngaydathang",
                table: "HOADONVANCHUYEN");
        }
    }
}
