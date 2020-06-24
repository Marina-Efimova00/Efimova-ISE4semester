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
    public class ClientViewModel : BaseViewModel
    {
        [Column(title: "ФИО клиента", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string ClientFIO { get; set; }
        [DataMember]
        [Column(title: "Почта", width: 150)]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "ClientFIO",
            "Email"
        };
    }
}
