namespace HaNamSite.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TourDuLich")]
    public partial class TourDuLich
    {
        public int ID { get; set; }

        [StringLength(1000)]
        [DisplayName("Tên tiêu đề")]
        [Required(ErrorMessage = "Bạn chưa nhập tên tiêu đề")]
        public string TieuDe { get; set; }

        [StringLength(50)]
        [DisplayName("Thời gian khởi hành")]
        [Required(ErrorMessage = "Bạn chưa nhập vào thời gian khởi hành")]
        public string ThoiGian { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày khởi hành")]
        [Required(ErrorMessage = "Bạn chưa nhập vào ngày khởi hành")]
        public DateTime? NgayKhoiHanh { get; set; }

        [StringLength(100)]
        [DisplayName("Địa điểm khởi hành")]
        [Required(ErrorMessage = "Bạn chưa nhập vào địa điểm khởi hành")]
        public string DiaDiemKhoiHanh { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Giá người lớn")]
        [Required(ErrorMessage = "Bạn chưa nhập vào giá người lớn")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Bạn phải nhập số")]
        public decimal? GiaNguoiLon { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Chi tiết lịch trình")]
        public string ChiTiet { get; set; }

        [Column(TypeName = "text")]
        [DisplayName("Ảnh đại diện")]
        public string Thumnail { get; set; }

        public bool? Status { get; set; }

        [StringLength(50)]
        [DisplayName("Loại khách sạn")]
        [Required(ErrorMessage = "Bạn chưa nhập vào loại khách sạn")]
        public string LoaiKhachSan { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Giá trẻ em")]
        [Required(ErrorMessage = "Bạn chưa nhập vào giá trẻ em")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Bạn phải nhập số")]
        public decimal? GiaTreEm { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Giá trẻ nhỏ")]
        [Required(ErrorMessage = "Bạn chưa nhập vào giá trẻ nhỏ")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Bạn phải nhập số")]
        public decimal? GiaTreNho { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Giá trẻ sơ sinh")]
        [Required(ErrorMessage = "Bạn chưa nhập vào giá trẻ sơ sinh")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Bạn phải nhập số")]
        public decimal? GiaSoSinh { get; set; }

        [DisplayName("Số khách tối đa")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Bạn phải nhập số")]
        public int? SoKhachToiDa { get; set; }

        public int? LuotXem { get; set; }

        [StringLength(30)]
        [DisplayName("Số ngày đi (VD: 2 ngày 1 đêm)")]
        [Required(ErrorMessage = "Bạn chưa nhập vào số ngày đi")]
        public string SoNgayDi { get; set; }

        [StringLength(10)]
        [DisplayName("Số ngày đi (short - VD: 2D1N)")]
        [Required(ErrorMessage = "Bạn chưa nhập vào số ngày đi (short)")]
        public string SoNgayDiShort { get; set; }

        [DisplayName("Phụ thu phòng riêng")]
        public decimal? PhuThuPhongRieng { get; set; }

        public int? tophop { get; set; }
    }
}
