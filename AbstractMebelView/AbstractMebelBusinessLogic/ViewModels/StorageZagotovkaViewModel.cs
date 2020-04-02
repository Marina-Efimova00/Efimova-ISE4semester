using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractMebelBusinessLogic.ViewModels
{
    public class StorageZagotovkaViewModel
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int ZagotovkaId { get; set; }
        [DisplayName("Название заготовки")]
        public string ZagotovkaName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
