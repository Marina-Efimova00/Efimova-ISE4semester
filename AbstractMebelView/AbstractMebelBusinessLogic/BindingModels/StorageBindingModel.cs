using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractMebelBusinessLogic.BindingModels
{
    [DataContract]
    public class StorageBindingModel
    {
        public int? Id { get; set; }
        public string StorageName { get; set; }
        public List<StorageZagotovkaBindingModel> StorageZagotovkas { get; set; }
    }
}
