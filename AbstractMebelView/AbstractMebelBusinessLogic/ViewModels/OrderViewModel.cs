using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using AbstractMebelBusinessLogic.Enums;
using System.Runtime.Serialization;
using AbstractMebelBusinessLogic.Attributes;

namespace AbstractMebelBusinessLogic.ViewModels
{
    [DataContract]
    public class OrderViewModel : BaseViewModel
    {
        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public int MebelId { get; set; }

        [DataMember]
        public int? ImplementerId { get; set; }
        [DisplayName("Клиент")]
        [Column(title: "Клиент", width: 150)]
        [DataMember]
        public string ClientFIO { get; set; }
        [DisplayName("Мебель")]
        [Column(title: "Мебель", width: 150)]
        [DataMember]
        public string MebelName { get; set; }
        [DisplayName("Исполнитель")]
        [Column(title: "Исполнитель", width: 150)]
        [DataMember]
        public string ImplementerFIO { get; set; }
        [DisplayName("Количество")]
        [Column(title: "Количество", width: 100)]
        [DataMember]
        public int Count { get; set; }
        [DisplayName("Сумма")]
        [Column(title: "Сумма", width: 50)]
        [DataMember]
        public decimal Sum { get; set; }
        [DisplayName("Статус")]
        [Column(title: "Статус", width: 100)]
        [DataMember]
        public OrderStatus Status { get; set; }
        [DisplayName("Дата создания")]
        [Column(title: "Дата создания", width: 100)]
        [DataMember]
        public DateTime DateCreate { get; set; }
        [DisplayName("Дата выполнения")]
        [Column(title: "Дата выполнения", width: 100)]
        [DataMember]
        public DateTime? DateImplement { get; set; }

        public override List<string> Properties() => new List<string> { "Id",
"ClientFIO", "MebelName", "ImplementerFIO", "Count", "Sum", "Status", "DateCreate",
"DateImplement" };
    }
}
