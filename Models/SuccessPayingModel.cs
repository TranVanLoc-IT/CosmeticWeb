using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCosmetic.Scaffold;
using System.ComponentModel.DataAnnotations;
namespace WebCosmetic.Models
{
    public class SuccessPayingModel
    {
        public ClientInfo _clientInfo { get; set; }
        public BillInfo _bill { get; set; }
        public string _khId { get; set; }
        public SuccessPayingModel()
        {
            this._clientInfo = new ClientInfo();
            this._bill = new BillInfo();
        }
        public class ClientInfo
        {
            [Display(Name = "Tên khách hàng: ")]
            [DataType(dataType:DataType.Text)]
            [Editable(false)]
            public string _clienName { get; set; }

            [Display(Name = "Địa chỉ khách hàng: ")]
            [DataType(dataType: DataType.Text)]
            [Editable(false)]
            public string _clientAddress { get; set; }

            [Display(Name = "Số điện thoại: ")]
            [DataType(dataType: DataType.Text)]
            [Editable(false)]
            public string _phone { get; set; }

        }

        public class BillInfo
        {

            [Display(Name = "Mã hóa đơn: ")]
            [DataType(dataType: DataType.Text)]
            [Editable(false)]
            public string _billCode { get; set; }

            [Display(Name = "Mã giao dịch: ")]
            [DataType(dataType: DataType.Text)]
            [Editable(false)]
            public string _transactionCode { get; set; }

            [Display(Name = "Ngày lập: ")]
            [DataType(dataType: DataType.Date)]
            [Editable(false)]
            public DateTime _dateSet { get; set; }

            [Display(Name = "Phương thức thanh toán: ")]
            [DataType(dataType: DataType.Text)]
            [Editable(false)]
            public string _methodPayment { get; set; }

            public double _totalMoney { get; set; }

        }
    }
}
