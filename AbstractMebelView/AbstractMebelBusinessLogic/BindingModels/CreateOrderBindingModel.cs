using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMebelBusinessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int MebelId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
