﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AbstractMebelDatabaseImplement.Models
{
    public class Storage
    {
        public int Id { get; set; }
        [Required]
        public string StorageName { get; set; }
        [ForeignKey("StorageId")]
        public virtual List<StorageZagotovka> StorageZagotovkas { get; set; }
    }
}
