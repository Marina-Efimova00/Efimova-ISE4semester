using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMebelBusinessLogic.BindingModels
{
    public class ProductBindingModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public List<ProductMebelBindingModel> ProductMebels { get; set; }
    }
}
