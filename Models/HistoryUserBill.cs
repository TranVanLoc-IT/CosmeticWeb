using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public string _mahd { get; set; }
        public string _tenSp { get; set; }
        public double _giaban { get; set; }
        public int _soluong { get; set; }
    }
}
