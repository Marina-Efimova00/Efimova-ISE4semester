using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractMebelBusinessLogic.BindingModels
{
    [DataContract]
    public class StorageZagotovkaBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int StorageId { get; set; }
        [DataMember]
        public int ZagotovkaId { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
