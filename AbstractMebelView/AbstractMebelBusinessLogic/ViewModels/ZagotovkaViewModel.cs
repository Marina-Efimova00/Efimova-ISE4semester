using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using AbstractMebelBusinessLogic.Attributes;
using AbstractMebelBusinessLogic.Enums;

namespace AbstractMebelBusinessLogic.ViewModels
{
    public class ZagotovkaViewModel : BaseViewModel
    {
        [Column(title: "Заготовка", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ZagotovkaName { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "ZagotovkaName"
        };
    }
}
