using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebCosmetic.Models
{
    public class PayForm
    {
        [Display(Name = "Tên khách hàng: ")]
        [Editable(false)]
        public string _name { get; set; }
        [Display(Name ="Số điện thoại liên hệ: ")]
        [Editable(false)]
        public string _sdt { get; set; }
        [Display(Name = "Địa chỉ: ")]
        [Editable(false)]
        public string _diaChi { get; set; }
        [Display(Name = "Chọn ngân hàng: ")]
        public List<string> _paymentSupport { get; set; }
        [Display(Name = "Nhập thẻ ngân hàng:  ")]
        public string _cardNumber { get; set; }

        public PayForm(string name, string sdt,string dc)
        {
            this._name = name;
            this._sdt = sdt;
            this._diaChi = dc;
        }
    }
}
