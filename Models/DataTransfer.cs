using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCosmetic.Scaffold;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
namespace WebCosmetic.Models
{
    public class DataTransfer
    {
        private readonly QL_COSMETICContext _cosmeticContext;
        private readonly IConfiguration _config;
        private List<ProductCardModel> _cleanserList { get; set; }
        public DataTransfer(QL_COSMETICContext cosmeticContext, IConfiguration config)
        {
            this._cosmeticContext = cosmeticContext;
            this._config = config;
        }
        
        private void transferDbToJson()
        {
            var collectAllProduct = this._cosmeticContext.Sanphams.ToList();
            var jsonData = JsonConvert.SerializeObject(collectAllProduct);

            string productFilePath = "../json_product.json";
            File.WriteAllText(productFilePath, jsonData);
        }
        public List<ProductCardModel> getCleanser()
        {
            _cleanserList = new List<ProductCardModel>();
            var get = this._cosmeticContext.Sanphams.Where(sp => sp.Masp.Contains("SPSR")).ToList();

            return _cleanserList;
        }
    }
}
