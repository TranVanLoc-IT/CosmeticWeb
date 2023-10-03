using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCosmetic.Models
{
    public class ProductCardModel
    {
        public string _srcImg { get; set; }
        public string _currentCost { get; set; }
        public string _oldCost { get; set; }
        public int _salePercent { get; set; }
        public string _productName { get; set; }
        public string _shortDescription { get; set; }
        public double _buyed { get; set; }
        public int _reviewPercent { get; set; }
    }
}
