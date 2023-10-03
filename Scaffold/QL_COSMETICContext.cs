using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebCosmetic.Models;
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

        public virtual DbSet<Chitiethoadon> Chitiethoadons { get; set; }
        public virtual DbSet<Congty> Congties { get; set; }
        public virtual DbSet<Cungcap> Cungcaps { get; set; }
        public virtual DbSet<Danhgia> Danhgia { get; set; }
        public virtual DbSet<Dexuatkhuyenmai> Dexuatkhuyenmais { get; set; }
        public virtual DbSet<Dexuatmua> Dexuatmuas { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }
        public virtual DbSet<Hoadonvanchuyen> Hoadonvanchuyens { get; set; }
        public virtual DbSet<Hotrothanhtoan> Hotrothanhtoans { get; set; }
        public virtual DbSet<Hotrovanchuyen> Hotrovanchuyens { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Kiemke> Kiemkes { get; set; }
        public virtual DbSet<Loaisanpham> Loaisanphams { get; set; }
        public virtual DbSet<Nhanthongbao> Nhanthongbaos { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<Sukien> Sukiens { get; set; }
        public virtual DbSet<Thanhtoan> Thanhtoans { get; set; }
        public virtual DbSet<Thekhuyenmai> Thekhuyenmais { get; set; }
        public virtual DbSet<Thongbao> Thongbaos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<Danhgia>(entity =>
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


            modelBuilder.Entity<Kiemke>(entity =>
            {
                entity.HasKey(e => new { e.Masp, e.Maloai })
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

            modelBuilder.Entity<Congty>(entity =>
            {
                entity.HasKey(e => e.Macongty)
                    .HasName("pk_mact");

                entity.Property(e => e.Macongty)
                    .IsUnicode(false)
                    .IsFixedLength(true);
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

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.Manv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
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
            foreach(var table in modelBuilder.Model.GetEntityTypes())
            {
                // loại bỏ tiền tố AspNet
                var tableName = table.GetTableName();
                if(tableName.StartsWith("AspNet"))
                {
                    table.SetTableName(tableName.Substring(6));
                }    
            }
        }
    }

}
