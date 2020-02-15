using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AbstractMebelBusinessLogic.ViewModels
{
    public class MebelZagotovkaViewModel
    {
        public int Id { get; set; }
        public int MebelId { get; set; }
        public int ZagotovkaId { get; set; }
        [DisplayName("Заготовка")]
        public string ZagotovkaName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
