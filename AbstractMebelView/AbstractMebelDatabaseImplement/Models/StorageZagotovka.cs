using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbstractMebelDatabaseImplement.Models
{
    public class StorageZagotovka
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int ZagotovkaId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Zagotovka Zagotovka { get; set; }
        public virtual Storage Storage { get; set; }
    }
}
