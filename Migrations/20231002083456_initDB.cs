using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCosmetic.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CONGTY",
                columns: table => new
                {
                    macongty = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    tencongty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    diachi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mact", x => x.macongty);
                });

            migrationBuilder.CreateTable(
                name: "HOTROTHANHTOAN",
                columns: table => new
                {
                    manganhang = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    tennganhang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    diachi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_manganhang", x => x.manganhang);
                });

            migrationBuilder.CreateTable(
                name: "HOTROVANCHUYEN",
                columns: table => new
                {
                    madichvu = table.Column<string>(type: "char(4)", unicode: false, fixedLength: true, maxLength: 4, nullable: false),
                    tendichvu = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    chiphi = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ma_dv", x => x.madichvu);
                });

            migrationBuilder.CreateTable(
                name: "KHACHHANG",
                columns: table => new
                {
                    makh = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: false),
                    tenkh = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    sdt = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: true),
                    email = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    ngaysinh = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_makh", x => x.makh);
                });

            migrationBuilder.CreateTable(
                name: "KIEMKE",
                columns: table => new
                {
                    masp = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    maloai = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    slconlai = table.Column<int>(type: "int", nullable: true),
                    sldaban = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    ngaykiemke = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    tinhtrang = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, defaultValueSql: "(N'Ổn định')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_kiemke", x => new { x.masp, x.maloai });
                });

            migrationBuilder.CreateTable(
                name: "NHANVIEN",
                columns: table => new
                {
                    manv = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: false),
                    tennv = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ngaysinh = table.Column<DateTime>(type: "date", nullable: true),
                    diachi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    kinhnghiem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_manv", x => x.manv);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LOAISANPHAM",
                columns: table => new
                {
                    maloai = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    tenloai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    macongty = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_maloai", x => x.maloai);
                    table.ForeignKey(
                        name: "fk_mact_lsp",
                        column: x => x.macongty,
                        principalTable: "CONGTY",
                        principalColumn: "macongty",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NHANTHONGBAO",
                columns: table => new
                {
                    makh = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: false),
                    ngaydk = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_nhantb", x => x.makh);
                    table.ForeignKey(
                        name: "fk_makh_ntb",
                        column: x => x.makh,
                        principalTable: "KHACHHANG",
                        principalColumn: "makh",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "THANHTOAN",
                columns: table => new
                {
                    magiaodich = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: false),
                    manganhang = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    makh = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: false),
                    trangthai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "(N'Chưa thanh toán')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_thanhtoan", x => x.magiaodich);
                    table.ForeignKey(
                        name: "fk_makh_thanhtoan",
                        column: x => x.makh,
                        principalTable: "KHACHHANG",
                        principalColumn: "makh",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_nh_thanhtoan",
                        column: x => x.manganhang,
                        principalTable: "HOTROTHANHTOAN",
                        principalColumn: "manganhang",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HOADON",
                columns: table => new
                {
                    mahd = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    makh = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: false),
                    tongtien = table.Column<decimal>(type: "money", nullable: true),
                    manv = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mahd", x => x.mahd);
                    table.ForeignKey(
                        name: "fk_manv_hd",
                        column: x => x.manv,
                        principalTable: "NHANVIEN",
                        principalColumn: "manv",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SUKIEN",
                columns: table => new
                {
                    mask = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: false),
                    ngaybd = table.Column<DateTime>(type: "date", nullable: true),
                    ngaykt = table.Column<DateTime>(type: "date", nullable: true),
                    tensk = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    manv = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sukien", x => x.mask);
                    table.ForeignKey(
                        name: "fk_msnv_sk",
                        column: x => x.manv,
                        principalTable: "NHANVIEN",
                        principalColumn: "manv",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SANPHAM",
                columns: table => new
                {
                    masp = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    tensp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    maloai = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    giaban = table.Column<decimal>(type: "money", nullable: true),
                    nsx = table.Column<DateTime>(type: "date", nullable: true),
                    hsd = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_masp", x => x.masp);
                    table.ForeignKey(
                        name: "fk_maloai_sp",
                        column: x => x.maloai,
                        principalTable: "LOAISANPHAM",
                        principalColumn: "maloai",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HOADONVANCHUYEN",
                columns: table => new
                {
                    magiaovan = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: false),
                    madichvu = table.Column<string>(type: "char(4)", unicode: false, fixedLength: true, maxLength: 4, nullable: false),
                    mahd = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    khoangcach = table.Column<double>(type: "float", nullable: true),
                    tongthanhtoan = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hdvc", x => x.magiaovan);
                    table.ForeignKey(
                        name: "fk_mahd",
                        column: x => x.mahd,
                        principalTable: "HOADON",
                        principalColumn: "mahd",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "THEKHUYENMAI",
                columns: table => new
                {
                    mathe = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: false),
                    trangthai = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    giatri = table.Column<double>(type: "float", nullable: true),
                    mask = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: true),
                    makh = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_thekm", x => x.mathe);
                    table.ForeignKey(
                        name: "fk_makh_tkm",
                        column: x => x.makh,
                        principalTable: "KHACHHANG",
                        principalColumn: "makh",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_mask_tkm",
                        column: x => x.mask,
                        principalTable: "SUKIEN",
                        principalColumn: "mask",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "THONGBAO",
                columns: table => new
                {
                    mask = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: false),
                    makh = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: false),
                    trangthai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "(N'Chưa thông báo')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_thongbao", x => new { x.mask, x.makh });
                    table.ForeignKey(
                        name: "fk_makh_tb",
                        column: x => x.makh,
                        principalTable: "KHACHHANG",
                        principalColumn: "makh",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_mask_tb",
                        column: x => x.mask,
                        principalTable: "SUKIEN",
                        principalColumn: "mask",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CHITIETHOADON",
                columns: table => new
                {
                    mahd = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    masp = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    soluong = table.Column<int>(type: "int", nullable: true),
                    thanhtien = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cthd", x => new { x.mahd, x.masp });
                    table.ForeignKey(
                        name: "fk_mahd_cthd",
                        column: x => x.mahd,
                        principalTable: "HOADON",
                        principalColumn: "mahd",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_masp_cthd",
                        column: x => x.masp,
                        principalTable: "SANPHAM",
                        principalColumn: "masp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CUNGCAP",
                columns: table => new
                {
                    macongty = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    masp = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    ngaynhap = table.Column<DateTime>(type: "date", nullable: false),
                    soluongcc = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cungcap", x => new { x.macongty, x.masp, x.ngaynhap });
                    table.ForeignKey(
                        name: "fk_mact_cc",
                        column: x => x.macongty,
                        principalTable: "CONGTY",
                        principalColumn: "macongty",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_masp_cc",
                        column: x => x.masp,
                        principalTable: "SANPHAM",
                        principalColumn: "masp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DANHGIA",
                columns: table => new
                {
                    masp = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    maloai = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    sophanhoi = table.Column<int>(type: "int", nullable: true),
                    sosao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_danhgia", x => new { x.masp, x.maloai });
                    table.ForeignKey(
                        name: "fk_masp_dg",
                        column: x => x.masp,
                        principalTable: "SANPHAM",
                        principalColumn: "masp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DEXUATKHUYENMAI",
                columns: table => new
                {
                    masp = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    maloai = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dexuatkk", x => new { x.masp, x.maloai });
                    table.ForeignKey(
                        name: "fk_maloai_dxkm",
                        column: x => x.maloai,
                        principalTable: "LOAISANPHAM",
                        principalColumn: "maloai",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_masp_dxkm",
                        column: x => x.masp,
                        principalTable: "SANPHAM",
                        principalColumn: "masp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DEXUATMUA",
                columns: table => new
                {
                    masp = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dxm", x => x.masp);
                    table.ForeignKey(
                        name: "fk_masp_dxm",
                        column: x => x.masp,
                        principalTable: "SANPHAM",
                        principalColumn: "masp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETHOADON_masp",
                table: "CHITIETHOADON",
                column: "masp");

            migrationBuilder.CreateIndex(
                name: "IX_CUNGCAP_masp",
                table: "CUNGCAP",
                column: "masp");

            migrationBuilder.CreateIndex(
                name: "IX_DEXUATKHUYENMAI_maloai",
                table: "DEXUATKHUYENMAI",
                column: "maloai");

            migrationBuilder.CreateIndex(
                name: "IX_HOADON_manv",
                table: "HOADON",
                column: "manv");

            migrationBuilder.CreateIndex(
                name: "IX_HOADONVANCHUYEN_mahd",
                table: "HOADONVANCHUYEN",
                column: "mahd");

            migrationBuilder.CreateIndex(
                name: "IX_LOAISANPHAM_macongty",
                table: "LOAISANPHAM",
                column: "macongty");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SANPHAM_maloai",
                table: "SANPHAM",
                column: "maloai");

            migrationBuilder.CreateIndex(
                name: "IX_SUKIEN_manv",
                table: "SUKIEN",
                column: "manv");

            migrationBuilder.CreateIndex(
                name: "IX_THANHTOAN_makh",
                table: "THANHTOAN",
                column: "makh");

            migrationBuilder.CreateIndex(
                name: "IX_THANHTOAN_manganhang",
                table: "THANHTOAN",
                column: "manganhang");

            migrationBuilder.CreateIndex(
                name: "IX_THEKHUYENMAI_makh",
                table: "THEKHUYENMAI",
                column: "makh");

            migrationBuilder.CreateIndex(
                name: "IX_THEKHUYENMAI_mask",
                table: "THEKHUYENMAI",
                column: "mask");

            migrationBuilder.CreateIndex(
                name: "IX_THONGBAO_makh",
                table: "THONGBAO",
                column: "makh");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHITIETHOADON");

            migrationBuilder.DropTable(
                name: "CUNGCAP");

            migrationBuilder.DropTable(
                name: "DANHGIA");

            migrationBuilder.DropTable(
                name: "DEXUATKHUYENMAI");

            migrationBuilder.DropTable(
                name: "DEXUATMUA");

            migrationBuilder.DropTable(
                name: "HOADONVANCHUYEN");

            migrationBuilder.DropTable(
                name: "HOTROVANCHUYEN");

            migrationBuilder.DropTable(
                name: "KIEMKE");

            migrationBuilder.DropTable(
                name: "NHANTHONGBAO");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "THANHTOAN");

            migrationBuilder.DropTable(
                name: "THEKHUYENMAI");

            migrationBuilder.DropTable(
                name: "THONGBAO");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "SANPHAM");

            migrationBuilder.DropTable(
                name: "HOADON");

            migrationBuilder.DropTable(
                name: "HOTROTHANHTOAN");

            migrationBuilder.DropTable(
                name: "KHACHHANG");

            migrationBuilder.DropTable(
                name: "SUKIEN");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "LOAISANPHAM");

            migrationBuilder.DropTable(
                name: "NHANVIEN");

            migrationBuilder.DropTable(
                name: "CONGTY");
        }
    }
}
