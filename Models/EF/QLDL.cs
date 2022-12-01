using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HaNamSite.Models.EF
{
    public partial class QLDL : DbContext
    {
        public QLDL()
            : base("name=QLDL1")
        {
        }

        public virtual DbSet<DiaDiem> DiaDiems { get; set; }
        public virtual DbSet<ImgDiaDiem> ImgDiaDiems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<TagDiaDiem> TagDiaDiems { get; set; }
        public virtual DbSet<TourDuLich> TourDuLiches { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<LichTrinh> LichTrinhs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImgDiaDiem>()
                .Property(e => e.Img)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.TongGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TourDuLich>()
                .Property(e => e.GiaNguoiLon)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TourDuLich>()
                .Property(e => e.Thumnail)
                .IsUnicode(false);

            modelBuilder.Entity<TourDuLich>()
                .Property(e => e.GiaTreEm)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TourDuLich>()
                .Property(e => e.GiaTreNho)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TourDuLich>()
                .Property(e => e.GiaSoSinh)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TourDuLich>()
                .Property(e => e.SoNgayDiShort)
                .IsFixedLength();

            modelBuilder.Entity<Contact>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.gioiTinh)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.email)
                .IsUnicode(false);

        }
    }
}
