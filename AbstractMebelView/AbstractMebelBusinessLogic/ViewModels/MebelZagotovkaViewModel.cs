using AbstractMebelBusinessLogic.Attributes;
using AbstractMebelBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractMebelBusinessLogic.ViewModels
{
    [DataContract]
    public class MebelZagotovkaViewModel : BaseViewModel
    {

        [DataMember]
        public int MebelId { get; set; }

        [DataMember]
        public int ZagotovkaId { get; set; }

        [DataMember]
        [Column(title: "Заготовка", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ZagotovkaName { get; set; }
        [Column(title: "Количество", width: 100)]
        [DataMember]
        public int Count { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "ZagotovkaName",
            "Count",
            "ImplementerFIO",
            "Count",
            "Sum",
            "Status",
            "DateCreate",
            "DateImplement"
        };
    }
}
