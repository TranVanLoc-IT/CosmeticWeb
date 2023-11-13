using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebCosmetic.Models
{
    public class PayingModel
    {
        [Display(Name = "Nhập mã khách hàng: ")]
        [DataType(dataType:DataType.Password)]
        [Required(ErrorMessage = "Phải nhập mã")]
        public string _makh { get; set; }
        [Display(Name = "Nhập tên khách hàng: ")]
        [DataType(dataType: DataType.Text)]
        [Required(ErrorMessage = "Phải nhập tên")]
        public string _tenkh { get; set; }
        [Display(Name = "Nhập số điện thoại khách hàng: ")]
        [MaxLength(11, ErrorMessage = "Số điện thoại không hợp lệ")]
        [MinLength(10, ErrorMessage = "Số điện thoại không hợp lệ")]
        [Required(ErrorMessage = "Phải nhập số điện thoai")]
        public string _phone { get; set; }
        [Display(Name = "Nhập địa chỉ khách hàng: ")]
        [DataType(dataType: DataType.Text)]
        [Required(ErrorMessage = "Phải nhập địa chỉ")]
        public string _address { get; set; }
        [Display(Name = "Chọn phương thức thanh toán ")]
        [DataType(dataType: DataType.Text)]
        [Required(ErrorMessage = "Phải chọn phương thức thanh toán")]
        public string _payment { get; set; } = "Money";

        [Display(Name = "Chọn ngân hàng thanh toán ")]
        [DataType(dataType: DataType.Text)]
        [Required(ErrorMessage = "Phải chọn ngân hàng thanh toán")]
        public KeyValuePair<string, string> _bankId { get; set; }

        [Display(Name = "Chọn đơn vị vận chuyển ")]
        [DataType(dataType: DataType.Text)]
        [Required(ErrorMessage = "Phải chọn đơn vị vận chuyển")]
        public KeyValuePair<string, string> _shipId { get; set; }

        [Display(Name = "Tổng thanh toán")]
        [DataType(dataType: DataType.Currency)]
        public double _totalMoney { get; set; }
        public Dictionary<string, int> _sanphamMua { get; set; }
    }
}
