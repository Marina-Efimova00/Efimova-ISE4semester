using AbstractMebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractMebelRestApi
{
    public class StorageModel
    {
        public int Id { get; set; }
        public string StorageName { get; set; }
        public List<StorageZagotovkaViewModel> StorageZagotovkas { get; set; }
    }
}
