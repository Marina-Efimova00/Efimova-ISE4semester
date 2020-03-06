using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbstractMebelDatabaseImplement.Models
{
    public class Mebel
    {

public int Id { get; set; }

        [Required]
        public string MebelName { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public virtual MebelZagotovka MebelZagotovka { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
