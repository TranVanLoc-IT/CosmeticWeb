using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCosmetic.Models
{
    public class ProductDetailsModel
    {
        public ProductCardModel productModel { get; set; }
        public string tietKiem { get; set; }
        public string imgQua { get; set; }
        public string quaTang { get; set; }
        public ProductDetailsModel(ProductCardModel product)
        {
            this.productModel = product;
            double chenhLech = ((double)this.productModel.giaban - (double)this.productModel.giabanmoi);
            this.tietKiem = chenhLech.ToString("N2").Substring(0, chenhLech.ToString("N2").Length - 3);
            this.imgQua = "Combo-3-bong-tay-trang-dinh-kem.jpg";
            this.quaTang = "Combo 3 bông tẩy trang";
        }
        public ProductDetailsModel()
        {

        }
    }
}
