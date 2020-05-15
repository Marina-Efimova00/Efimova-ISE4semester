using AbstractMebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMebelBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<MebelViewModel> Mebels { get; set; }
        public List<StorageViewModel> Storages { get; set; }
    }
}
