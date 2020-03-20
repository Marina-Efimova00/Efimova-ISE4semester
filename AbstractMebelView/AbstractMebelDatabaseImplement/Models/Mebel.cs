using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AbstractMebelDatabaseImplement.Models
{
    public class Mebel
    {

        public int Id { get; set; }

        [Required]
        public string MebelName { get; set; }

        [Required]
        public decimal Price { get; set; }
        [ForeignKey("MebelId")]
        public virtual List<MebelZagotovka> MebelZagotovkas { get; set; }
    }
}
