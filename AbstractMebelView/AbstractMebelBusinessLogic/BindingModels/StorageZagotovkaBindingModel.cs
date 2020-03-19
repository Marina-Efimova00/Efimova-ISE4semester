using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMebelBusinessLogic.BindingModels
{
    public class StorageZagotovkaBindingModel
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int ZagotovkaId { get; set; }
        public int Count { get; set; }
    }
}
