using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMebelBusinessLogic.BindingModels
{
    public class MebelZagotovkaBindingModel
    {
        public int Id { get; set; }
        public int MebelId { get; set; }
        public int ZagotovkaId { get; set; }
        public int Count { get; set; }
    }
}
