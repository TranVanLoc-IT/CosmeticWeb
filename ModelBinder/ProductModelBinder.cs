using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCosmetic.Models;

namespace WebCosmetic.ModelBinder
{
    public class ProductModelBinder:IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // giải mã query
            if (bindingContext == null) throw new Exception(nameof(bindingContext));
            var model = bindingContext.ModelName;
            var dataQuery = bindingContext.ValueProvider.GetValue(model).ToString();

            var decodeDataQuery = Encoding.UTF8.GetString(Convert.FromBase64String(dataQuery));

            if(bindingContext.ModelName == "productModel")
            {
                var productModel = JsonConvert.DeserializeObject<ProductCardModel>(decodeDataQuery);
                bindingContext.Result = ModelBindingResult.Success(productModel);
            }
            else
            {
                var productCart = JsonConvert.DeserializeObject<ProductCart.DetailsCart>(decodeDataQuery);
                bindingContext.Result = ModelBindingResult.Success(productCart);
            }
            return Task.CompletedTask;
        }
    }
}
