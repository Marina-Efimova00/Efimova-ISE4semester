using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AbstractMebelBusinessLogic.ViewModels
{
    public class ProductMebelViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int MebelId { get; set; }
        [DisplayName("Мебель")]
        public string MebelName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
