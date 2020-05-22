using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbstractMebelBusinessLogic.ViewModels
{
    [DataContract]
    public class MebelViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [DisplayName("Название мебели")]
        public string MebelName { get; set; }
        [DataMember]
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> MebelZagotovkas { get; set; }
    }
}
