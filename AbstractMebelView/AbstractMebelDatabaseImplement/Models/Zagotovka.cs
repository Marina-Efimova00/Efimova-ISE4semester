using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AbstractMebelDatabaseImplement.Models
{
    public class Zagotovka
    {
        public int Id { get; set; }
        [Required]
        public string ZagotovkaName { get; set; }
        [ForeignKey("ZagotovkaId")]
        public virtual List<MebelZagotovka> MebelZagotovkas { get; set; }
    }
}
