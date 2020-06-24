using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;
using AbstractMebelBusinessLogic.Attributes;
using AbstractMebelBusinessLogic.Enums;

namespace AbstractMebelBusinessLogic.ViewModels
{
    [DataContract]
    public class MebelViewModel : BaseViewModel
    {
        [Column(title: "Название мебели", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string MebelName { get; set; }
        [Column(title: "Цена", width: 50)]
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> MebelZagotovkas { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "MebelName",
            "Price"
        };
    }
}
