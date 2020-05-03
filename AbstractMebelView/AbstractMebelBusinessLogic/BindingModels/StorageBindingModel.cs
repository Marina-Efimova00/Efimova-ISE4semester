using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMebelBusinessLogic.BindingModels
{
    public class StorageBindingModel
    {
        public int Id { get; set; }
        public string StorageName { get; set; }
        public List<StorageZagotovkaBindingModel> StorageZagotovkas { get; set; }
    }
}
