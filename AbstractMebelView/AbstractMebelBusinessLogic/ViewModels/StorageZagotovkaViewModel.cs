using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractMebelBusinessLogic.ViewModels
{
    [DataContract]
    public class StorageZagotovkaViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int StorageId { get; set; }
        [DataMember]
        public int ZagotovkaId { get; set; }
        [DisplayName("Название заготовки")]
        [DataMember]
        public string StorageName { get; set; }
        [DisplayName("Название склада")]
        [DataMember]
        public string ZagotovkaName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
