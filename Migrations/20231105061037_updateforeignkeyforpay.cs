using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCosmetic.Migrations
{
    public partial class updateforeignkeyforpay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "mahd",
                table: "THANHTOAN",
                type: "char(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_THANHTOAN_mahd",
                table: "THANHTOAN",
                column: "mahd");

            migrationBuilder.AddForeignKey(
                name: "FK_THANHTOAN_HOADON_mahd",
                table: "THANHTOAN",
                column: "mahd",
                principalTable: "HOADON",
                principalColumn: "mahd",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_THANHTOAN_HOADON_mahd",
                table: "THANHTOAN");

            migrationBuilder.DropIndex(
                name: "IX_THANHTOAN_mahd",
                table: "THANHTOAN");

            migrationBuilder.DropColumn(
                name: "mahd",
                table: "THANHTOAN");
        }
    }
}
