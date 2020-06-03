using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractMebelBusinessLogic.ViewModels
{
    [DataContract]
    public class StorageViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [DisplayName("Название склада")]
        public string StorageName { get; set; }
        [DataMember]
        public List<StorageZagotovkaViewModel> StorageZagotovkas { get; set; }
    }
}
