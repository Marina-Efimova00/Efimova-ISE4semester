using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMebelBusinessLogic.BindingModels
{
    public class ProductMebelBindingModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int MebelId { get; set; }
        public int Count { get; set; }
    }
}
