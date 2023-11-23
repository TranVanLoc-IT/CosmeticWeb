using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebCosmetic.Models
{
    public class ProductCardModel
    {
        [JsonPropertyName("id")]
        public string masp { get; set; }
        public decimal giaban { get; set; }
        public decimal giabanmoi { get; set; }
        public string tensp { get; set; }
        public int sldaban { get; set; }
        public int slconlai { get; set; }
        public int solantruycap { get; set; }
        public int sosao { get; set; }
        public int sophanhoi { get; set; }
        public string tencongty { get; set; }
        public virtual ICollection<ProductCardModel> ProductCardModels { get; set; }
    }
}
