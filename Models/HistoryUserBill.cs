using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
namespace WebCosmetic.Models
{
    public class HistoryUserBill
    {
        public List<SuccessPayingModel> _billHistoryList { get; set; } 
        public HistoryUserBill()
        {
            this._billHistoryList = new List<SuccessPayingModel>();
        }
    }
    public class HistoryProductBill
    {
        [DisplayName("Mã hóa đơn")]
        public string _mahd { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string _tenSp { get; set; }
        [DisplayName("Giá bán")]
        public double _giaban { get; set; }
        [DisplayName("Số lượng")]
        public int _soluong { get; set; }
    }
}
