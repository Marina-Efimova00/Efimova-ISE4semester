using AbstractMebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMebelBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportMebelZagotovkaViewModel> MebelZagotovkas { get; set; }
        public List<ReportStorageZagotovkaViewModel> StorageZagotovkas { get; set; }
    }
}
