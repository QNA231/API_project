using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThemSuaXoaDuLieu.Migrations
{
    /// <inheritdoc />
    public partial class updatev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_KhachHang_KhachHangId",
                table: "HoaDon");

            migrationBuilder.AlterColumn<int>(
                name: "KhachHangId",
                table: "HoaDon",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_KhachHang_KhachHangId",
                table: "HoaDon",
                column: "KhachHangId",
                principalTable: "KhachHang",
                principalColumn: "KhachHangId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_KhachHang_KhachHangId",
                table: "HoaDon");

            migrationBuilder.AlterColumn<int>(
                name: "KhachHangId",
                table: "HoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_KhachHang_KhachHangId",
                table: "HoaDon",
                column: "KhachHangId",
                principalTable: "KhachHang",
                principalColumn: "KhachHangId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
