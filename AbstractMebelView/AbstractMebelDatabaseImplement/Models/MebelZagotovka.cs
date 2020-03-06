using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbstractMebelDatabaseImplement.Models
{
    public class MebelZagotovka
    {
        public int Id { get; set; }
        public int MebelId { get; set; }
        public int ZagotovkaId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Zagotovka Zagotovka { get; set; }
        public virtual Mebel Mebel { get; set; }
    }
}
