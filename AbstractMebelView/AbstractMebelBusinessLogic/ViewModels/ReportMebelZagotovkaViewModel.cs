using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMebelBusinessLogic.ViewModels
{
    public class ReportMebelZagotovkaViewModel
    {
        public string ZagotovkaName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Mebels { get; set; }
    }
}
