using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace WebCosmetic.Models
{
   
    public class ProductCart
    {

        public List<DetailsCart> _productCart { get; set; }
        public class DetailsCart : ProductCardModel
        {
            private readonly UserManager<CosmeticModel> _userManager;

            public int soLuongMua { get; set; }
            public string _userId { get; set; }
            public DetailsCart()
            {
                soLuongMua = 0;
            }
        }
        public ProductCart()
        {
            this._productCart = new List<DetailsCart>();
        }
    }
    public class ProductTypeId
    {
        // bỏ "producttypeid"{}
        [JsonPropertyName("")]
        public Dictionary<string, List<ProductDataJson>> _productObjectIdType { get; set; }
        public ProductTypeId()
        {
            this._productObjectIdType = new Dictionary<string, List<ProductDataJson>>();
        }
    }
    public class ProductDataJson
    {
        public string masp { get; set; }
        public string mota { get; set; }
        public string imgUrl { get; set; }
        public string anhQuaTang { get; set; }
        public string tenQua { get; set; }
        public Dictionary<string, string> thanhphan { get; set; }
        public Dictionary<string, string> thongtin { get; set; }
        public Dictionary<string, string> xuatXu { get; set; }
        public string huongdan { get; set; }
        public ProductDataJson()
        {
            this.masp = string.Empty;
            this.tenQua = string.Empty;
            this.mota = string.Empty;
            this.huongdan = string.Empty;
            this.imgUrl = string.Empty;
            this.anhQuaTang = string.Empty;
        }
    }
}
