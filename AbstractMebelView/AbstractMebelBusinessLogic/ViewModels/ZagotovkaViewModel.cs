using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AbstractMebelBusinessLogic.ViewModels
{
    public class ZagotovkaViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название заготовки")]
        public string ZagotovkaName { get; set; }
    }
}
