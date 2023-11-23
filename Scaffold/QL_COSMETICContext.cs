using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebCosmetic.Models;

#nullable disable

namespace WebCosmetic.Scaffold
{
    public partial class QL_COSMETICContext : IdentityDbContext<CosmeticModel>
    {
        public QL_COSMETICContext()
        {
        }

        public QL_COSMETICContext(DbContextOptions<QL_COSMETICContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ProductCardModel> ProductCard { get; set; }
        public virtual DbSet<ProfileRoleResult> ProfileRole { get; set; }
        public virtual DbSet<ProfileRoleClaimResult> ProfileClaim { get; set; }
        public virtual DbSet<Chitiethoadon> Chitiethoadons { get; set; }
        public virtual DbSet<Congty> Congties { get; set; }
        public virtual DbSet<Cungcap> Cungcaps { get; set; }
        public virtual DbSet<Danhgium> Danhgia { get; set; }
        public virtual DbSet<Dexuatkhuyenmai> Dexuatkhuyenmais { get; set; }
        public virtual DbSet<Dexuatmua> Dexuatmuas { get; set; }
        public virtual DbSet<GenerateBillCode> GenerateBillCodes { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }
        public virtual DbSet<Hoadonvanchuyen> Hoadonvanchuyens { get; set; }
        public virtual DbSet<Hotrothanhtoan> Hotrothanhtoans { get; set; }
        public virtual DbSet<Hotrovanchuyen> Hotrovanchuyens { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Kiemke> Kiemkes { get; set; }
        public virtual DbSet<Loaisanpham> Loaisanphams { get; set; }
        public virtual DbSet<Loaisp> Loaisps { get; set; }
        public virtual DbSet<Nhanthongbao> Nhanthongbaos { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<Sukien> Sukiens { get; set; }
        public virtual DbSet<Thanhtoan> Thanhtoans { get; set; }
        public virtual DbSet<Thekhuyenmai> Thekhuyenmais { get; set; }
        public virtual DbSet<Thongbao> Thongbaos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MSI;Initial Catalog=QL_COSMETIC;Integrated Security=True; trusted_connection = true; encrypt = false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCardModel>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<ProfileRoleResult>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<ProfileRoleClaimResult>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<Chitiethoadon>(entity =>
            {
                entity.HasKey(e => new { e.Mahd, e.Masp })
                    .HasName("pk_cthd");

                entity.Property(e => e.Mahd)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Masp)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.MahdNavigation)
                    .WithMany(p => p.Chitiethoadons)
                    .HasForeignKey(d => d.Mahd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mahd_cthd");

                entity.HasOne(d => d.MaspNavigation)
                    .WithMany(p => p.Chitiethoadons)
                    .HasForeignKey(d => d.Masp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_masp_cthd");
            });

            modelBuilder.Entity<Congty>(entity =>
            {
                entity.HasKey(e => e.Macongty)
                    .HasName("pk_mact");

                entity.Property(e => e.Macongty)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Cungcap>(entity =>
            {
                entity.HasKey(e => new { e.Macongty, e.Masp, e.Ngaynhap })
                    .HasName("pk_cungcap");

                entity.Property(e => e.Macongty)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Masp)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.MacongtyNavigation)
                    .WithMany(p => p.Cungcaps)
                    .HasForeignKey(d => d.Macongty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mact_cc");

                entity.HasOne(d => d.MaspNavigation)
                    .WithMany(p => p.Cungcaps)
                    .HasForeignKey(d => d.Masp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_masp_cc");
            });

            modelBuilder.Entity<Danhgium>(entity =>
            {
                entity.HasKey(e => new { e.Masp, e.Maloai })
                    .HasName("pk_danhgia");

                entity.Property(e => e.Masp)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Maloai)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.MaspNavigation)
                    .WithMany(p => p.Danhgia)
                    .HasForeignKey(d => d.Masp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_masp_dg");
            });

            modelBuilder.Entity<Dexuatkhuyenmai>(entity =>
            {
                entity.HasKey(e => new { e.Masp, e.Maloai })
                    .HasName("pk_dexuatkk");

                entity.Property(e => e.Masp)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Maloai)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.Dexuatkhuyenmais)
                    .HasForeignKey(d => d.Maloai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_maloai_dxkm");

                entity.HasOne(d => d.MaspNavigation)
                    .WithMany(p => p.Dexuatkhuyenmais)
                    .HasForeignKey(d => d.Masp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_masp_dxkm");
            });

            modelBuilder.Entity<Dexuatmua>(entity =>
            {
                entity.HasKey(e => e.Masp)
                    .HasName("pk_dxm");

                entity.Property(e => e.Masp)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.MaspNavigation)
                    .WithOne(p => p.Dexuatmua)
                    .HasForeignKey<Dexuatmua>(d => d.Masp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_masp_dxm");
            });

            modelBuilder.Entity<GenerateBillCode>(entity =>
            {
                entity.ToView("generateBillCode");

                entity.Property(e => e.NewId).IsUnicode(false);
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.Mahd)
                    .HasName("pk_mahd");

                entity.Property(e => e.Mahd)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Makh)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Manv)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Ngaylap).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.Manv)
                    .HasConstraintName("fk_manv_hd");
            });

            modelBuilder.Entity<Hoadonvanchuyen>(entity =>
            {
                entity.HasKey(e => e.Magiaovan)
                    .HasName("pk_hdvc");

                entity.Property(e => e.Magiaovan)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Madichvu)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Mahd)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Ngaydathang).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.Ngaygiaohang).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.HasOne(d => d.MahdNavigation)
                    .WithMany(p => p.Hoadonvanchuyens)
                    .HasForeignKey(d => d.Mahd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mahd");
            });

            modelBuilder.Entity<Hotrothanhtoan>(entity =>
            {
                entity.HasKey(e => e.Manganhang)
                    .HasName("pk_manganhang");

                entity.Property(e => e.Manganhang)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Hotrovanchuyen>(entity =>
            {
                entity.HasKey(e => e.Madichvu)
                    .HasName("pk_ma_dv");

                entity.Property(e => e.Madichvu)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Makh)
                    .HasName("pk_makh");

                entity.Property(e => e.Makh)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Sdt)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Kiemke>(entity =>
            {
                entity.HasKey(e => new { e.Masp, e.Maloai, e.Ngaykiemke })
                    .HasName("pk_kiemke");

                entity.Property(e => e.Masp)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Maloai)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Ngaykiemke).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sldaban).HasDefaultValueSql("((0))");

                entity.Property(e => e.Tinhtrang).HasDefaultValueSql("(N'Ổn định')");
            });

            modelBuilder.Entity<Loaisanpham>(entity =>
            {
                entity.HasKey(e => e.Maloai)
                    .HasName("pk_maloai");

                entity.Property(e => e.Maloai)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Macongty)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.MacongtyNavigation)
                    .WithMany(p => p.Loaisanphams)
                    .HasForeignKey(d => d.Macongty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mact_lsp");
            });

            modelBuilder.Entity<Nhanthongbao>(entity =>
            {
                entity.HasKey(e => e.Makh)
                    .HasName("pk_nhantb");

                entity.Property(e => e.Makh)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.MakhNavigation)
                    .WithOne(p => p.Nhanthongbao)
                    .HasForeignKey<Nhanthongbao>(d => d.Makh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_makh_ntb");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Manv)
                    .HasName("pk_manv");

                entity.Property(e => e.Manv)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.Masp)
                    .HasName("pk_masp");

                entity.Property(e => e.Masp)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Maloai)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.Maloai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_maloai_sp");
            });

            modelBuilder.Entity<Sukien>(entity =>
            {
                entity.HasKey(e => e.Mask)
                    .HasName("pk_sukien");

                entity.Property(e => e.Mask)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Manv)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Sukiens)
                    .HasForeignKey(d => d.Manv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_msnv_sk");
            });

            modelBuilder.Entity<Thanhtoan>(entity =>
            {
                entity.HasKey(e => e.Magiaodich)
                    .HasName("pk_thanhtoan");

                entity.Property(e => e.Magiaodich)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Mahd)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Makh)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Manganhang)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Trangthai).HasDefaultValueSql("(N'Chưa thanh toán')");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Thanhtoans)
                    .HasForeignKey(d => d.Makh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_makh_thanhtoan");

                entity.HasOne(d => d.ManganhangNavigation)
                    .WithMany(p => p.Thanhtoans)
                    .HasForeignKey(d => d.Manganhang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_nh_thanhtoan");
            });

            modelBuilder.Entity<Thekhuyenmai>(entity =>
            {
                entity.HasKey(e => e.Mathe)
                    .HasName("pk_thekm");

                entity.Property(e => e.Mathe)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Makh)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Mask)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Trangthai).IsFixedLength(true);

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Thekhuyenmais)
                    .HasForeignKey(d => d.Makh)
                    .HasConstraintName("fk_makh_tkm");

                entity.HasOne(d => d.MaskNavigation)
                    .WithMany(p => p.Thekhuyenmais)
                    .HasForeignKey(d => d.Mask)
                    .HasConstraintName("fk_mask_tkm");
            });

            modelBuilder.Entity<Thongbao>(entity =>
            {
                entity.HasKey(e => new { e.Mask, e.Makh })
                    .HasName("pk_thongbao");

                entity.Property(e => e.Mask)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Makh)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Trangthai).HasDefaultValueSql("(N'Chưa thông báo')");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Thongbaos)
                    .HasForeignKey(d => d.Makh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_makh_tb");

                entity.HasOne(d => d.MaskNavigation)
                    .WithMany(p => p.Thongbaos)
                    .HasForeignKey(d => d.Mask)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mask_tb");
            });
            base.OnModelCreating(modelBuilder); // forgot this cause of error for Identity table structure
            foreach (var table in modelBuilder.Model.GetEntityTypes())
            {
                // loại bỏ tiền tố AspNet
                var tableName = table.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    table.SetTableName(tableName.Substring(6));
                }
            }
            // fluent API
        }
        public Khachhang GetUserInfoProcedure(string makh)
        {
            // gọi storeprocedure
            return Set<Khachhang>().FromSqlRaw("exec prc_DisplayCustomerInfo {0}", makh).ToList().FirstOrDefault();
        }
        public List<ProfileRoleResult> GetProfileRolesProcedure(string manv)
        {
            return Set<ProfileRoleResult>().FromSqlRaw("exec prc_GetProfileRoles {0}", manv).ToList();
        }
        public List<ProfileRoleClaimResult> GetProfileRoleClaimsProcedure(string manv)
        {
            return Set<ProfileRoleClaimResult>().FromSqlRaw("exec prc_GetProfileRoleClaims {0}", manv).ToList();
        }
        public List<ProductCardModel> GetProductCardData()
        {
            return Set<ProductCardModel>().FromSqlRaw("exec prc_CollectProductInfo").ToList();
        }
        public string GenerateBillCode()
        {
            var success = new SqlParameter("@billcode", SqlDbType.Char, 10)
            {
                Direction = ParameterDirection.Output
            };

            string sql = "exec prc_GenerateBillCode 1, @billcode out";

            Database.ExecuteSqlRaw(sql, success);

            if (success.Value != DBNull.Value)
            {
                return success.Value.ToString();
            }
            else
            {
                return null;
            }
        }
        public string UpdateAccessTimes(string masp)
        {
            var success = new SqlParameter("@success", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter fparam = new SqlParameter();
            fparam.ParameterName = "@masp";
            fparam.Value = masp;
            string sql = "exec prc_UpdateAccessTimes @masp, @success out";

            Database.ExecuteSqlRaw(sql, fparam, success);

            if (success.Value != DBNull.Value)
            {
                return success.Value.ToString();
            }
            else
            {
                return null;
            }
        }
        public string UpdateStaffConfirmed(string _billcode, string _manv)
        {
            var success = new SqlParameter("@success", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter fparam = new SqlParameter("@manv", SqlDbType.Char, 36);
            fparam.Value = _manv;

            SqlParameter sparam = new SqlParameter("@billcode", SqlDbType.Char, 10);
            sparam.Value = _billcode;
            string sql = "exec prc_UpdateStaffConfirm @billcode, @manv,  @success out";

            Database.ExecuteSqlRaw(sql, new SqlParameter[]{ sparam,fparam, success });

            if (success.Value != DBNull.Value)
            {
                return "Thành công";
            }
            else
            {
                return "Thất bại";
            }
        }
        public string GetKhidByUID(string uid)
        {
            var makh = new SqlParameter("@makh", SqlDbType.Char, 7)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter fparam = new SqlParameter("@uid", SqlDbType.Char, 36);
            fparam.Value = uid;
            string sql = "exec prc_GetKhIdByUID @uid, @makh out";

            Database.ExecuteSqlRaw(sql, new SqlParameter[] { fparam, makh });

            if (makh.Value != DBNull.Value)
            {
                return makh.Value.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
