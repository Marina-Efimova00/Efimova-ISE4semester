﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMebelFileImplement.Models
{
    public class StorageZagotovka
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int ZagotovkaId { get; set; }
        public int Count { get; set; }
    }
}
