using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractMebelBusinessLogic.ViewModels
{
    [DataContract]
    public class MebelZagotovkaViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int MebelId { get; set; }

        [DataMember]
        public int ZagotovkaId { get; set; }

        [DataMember]
        [DisplayName("Заготовка")]
        public string ZagotovkaName { get; set; }

        [DataMember]
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
