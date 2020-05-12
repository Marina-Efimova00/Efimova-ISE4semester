using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractMebelBusinessLogic.BindingModels
{
    [DataContract]
    public class StorageZagotovkaBindingModel
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int ZagotovkaId { get; set; }
        public int Count { get; set; }
    }
}
