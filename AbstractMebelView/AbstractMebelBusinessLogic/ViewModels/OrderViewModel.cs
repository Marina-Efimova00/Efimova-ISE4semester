using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using AbstractMebelBusinessLogic.Enums;

namespace AbstractMebelBusinessLogic.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int MebelId { get; set; }
        [DisplayName("Мебель")]
        public string MebelName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
    }
}
