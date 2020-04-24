﻿using AbstractMebelBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMebelFileImplement.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int MebelId { get; set; }
        public int? ImplementerId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
