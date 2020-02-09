using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AbstractMebelBusinessLogic.ViewModels
{
    public class MebelViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название мебели")]
        public string MebelName { get; set; }
    }
}
