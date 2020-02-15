﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMebelBusinessLogic.BindingModels
{
    public class MebelBindingModel
    {
        public int Id { get; set; }
        public string MebelName { get; set; }
        public decimal Price { get; set; }
        public List<MebelZagotovkaBindingModel> MebelZagotovkas { get; set; }
    }
}
